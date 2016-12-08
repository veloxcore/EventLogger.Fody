using Mono.Cecil;

public partial class ModuleWeaver
{
    public void Init()
    {
        var loggerTypeDefinition = GetLoggerMethod.ReturnType.Resolve();

        IsErrorEnabledMethod = new Lazy<MethodReference>(() => ModuleDefinition.ImportReference(loggerTypeDefinition.FindMethod("get_IsErrorEnabled")));
        EventNameMethod = new Lazy<MethodReference>(() => ModuleDefinition.ImportReference(loggerTypeDefinition.FindMethod("set_EventName", "String")));

        ErrorMethod = new Lazy<MethodReference>(() => ModuleDefinition.ImportReference(loggerTypeDefinition.FindMethod("Error", "String", "String", "Exception")));
        InfoMethod = new Lazy<MethodReference>(() => ModuleDefinition.ImportReference(loggerTypeDefinition.FindMethod("Info", "String", "String", "Exception")));

        LoggerType = ModuleDefinition.ImportReference(loggerTypeDefinition);
    }

	public TypeReference LoggerType;
    public Lazy<MethodReference> EventNameMethod;
    public Lazy<MethodReference> IsErrorEnabledMethod;
    public Lazy<MethodReference> ErrorMethod;
    public Lazy<MethodReference> InfoMethod;
}