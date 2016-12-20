using System.Diagnostics;
using EventLogger;

[ExcludeFromLogging]
public class ClassWithWhileMethod
{
    public void MethodWithWhile()
    {
        while (true)
        {
            Trace.WriteLine("aString");
            break;
        }
    }
}