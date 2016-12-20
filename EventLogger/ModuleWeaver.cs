using System;
using System.Linq;
using Mono.Cecil;

public partial class ModuleWeaver
{
    public Action<string> LogInfo { get; set; }
    public IAssemblyResolver AssemblyResolver { get; set; }
    public Action<string> LogWarning { get; set; }
    public Action<string> LogError { get; set; }
    public ModuleDefinition ModuleDefinition { get; set; }

    public ModuleWeaver()
    {
        LogInfo = s => { };
        LogWarning = s => { };
        LogError = s => { };
    }

    public void Execute()
    {
        FindGetLoggerMethod();
        LoadSystemTypes();
        Init();
        foreach (var type in ModuleDefinition
            .GetTypes()
            .Where(x => (x.BaseType != null) && !x.IsEnum && !x.IsInterface && !x.IsSealed))
        {
            bool excludeForLogging = false;
            foreach (CustomAttribute attribute in type.CustomAttributes)
            {
                if (attribute.AttributeType.FullName.Equals("EventLogger.ExcludeFromLoggingAttribute"))
                {
                    excludeForLogging = true;
                    type.CustomAttributes.Remove(attribute);
                    break;
                }
            }

            if (!excludeForLogging && type.FullName != LoggerType.FullName)
                ProcessType(type);
        }

        //TODO: ensure attributes don't exist on interfaces
        RemoveReference();
    }

}