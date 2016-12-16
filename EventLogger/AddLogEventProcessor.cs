using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class AddLogEventProcessor
{
    public MethodDefinition Method;
    public Action FoundUsageInType;
    public FieldReference LoggerField;
    public ModuleWeaver ModuleWeaver;

    public void Process()
    {
        if (Method.Body.Instructions.Count > 0)
        {
            var ilProcessor = Method.Body.GetILProcessor();
            var body = Method.Body;
            FoundUsageInType();
            string eventName = string.Empty;
            foreach (var attribute in Method.CustomAttributes)
            {
                if (attribute.AttributeType.FullName.Equals("EventLogger.EventNameAttribute"))
                {
                    eventName = attribute.ConstructorArguments[0].Value.ToString();
                    Method.CustomAttributes.Remove(attribute);
                    break;
                }
            }

            Instruction firstInstruction = Method.Body.Instructions.FirstOrDefault();
            var returnFixer = new ReturnFixer
            {
                Method = Method
            };
            returnFixer.MakeLastStatementReturn();

            List<Instruction> startingInstructions = new List<Instruction>();
            List<Instruction> endingInstructions = new List<Instruction>();

            endingInstructions.AddRange(GetEventInstruction("Method calling Finished."));

            if (!string.IsNullOrEmpty(eventName))
            {
                startingInstructions.AddRange(SetEventNameInstruction(eventName));
                endingInstructions.AddRange(SetEventNameInstruction(""));
            }

            //endingInstructions.Add(Instruction.Create(OpCodes.Nop));
            //endingInstructions.Add(Instruction.Create(OpCodes.Endfinally));
            startingInstructions.AddRange(GetEventInstruction("Method calling started."));

            var tryLeaveInstructions = Instruction.Create(OpCodes.Leave_S, returnFixer.NopBeforeReturn);
            var finallyInstructions = Instruction.Create(OpCodes.Endfinally);
            ilProcessor.InsertBefore(firstInstruction, startingInstructions);

            ilProcessor.InsertBefore(returnFixer.NopBeforeReturn, tryLeaveInstructions);
            ilProcessor.InsertBefore(returnFixer.NopBeforeReturn, endingInstructions);
            ilProcessor.InsertBefore(returnFixer.NopBeforeReturn, finallyInstructions);

            var beforeReturn = Instruction.Create(OpCodes.Nop);
            var handler = new ExceptionHandler(ExceptionHandlerType.Finally)
            {
                TryStart = firstInstruction,
                TryEnd = tryLeaveInstructions.Next,
                HandlerStart = endingInstructions.FirstOrDefault(),
                HandlerEnd = finallyInstructions.Next
            };

            body.ExceptionHandlers.Add(handler);
            body.InitLocals = true;
            body.OptimizeMacros();
        }
    }

    List<Instruction> GetEventInstruction(string message)
    {
        var result = new List<Instruction>();
        result.Add(Instruction.Create(OpCodes.Nop));
        result.Add(Instruction.Create(OpCodes.Ldsfld, LoggerField));
        result.Add(Instruction.Create(OpCodes.Ldstr, message));
        result.Add(Instruction.Create(OpCodes.Ldstr, Method.DeclaringType.ToString() + "." + Method.Name));
        result.Add(Instruction.Create(OpCodes.Ldnull));
        result.Add(Instruction.Create(OpCodes.Callvirt, ModuleWeaver.InfoMethod));
        result.Add(Instruction.Create(OpCodes.Nop));
        return result;
    }

    List<Instruction> SetEventNameInstruction(string eventName)
    {
        var result = new List<Instruction>();
        result.Add(Instruction.Create(OpCodes.Nop));
        result.Add(Instruction.Create(OpCodes.Ldsfld, LoggerField));
        result.Add(Instruction.Create(OpCodes.Ldstr, eventName));
        result.Add(Instruction.Create(OpCodes.Callvirt, ModuleWeaver.EventNameMethod));
        result.Add(Instruction.Create(OpCodes.Nop));

        return result;
    }
}
