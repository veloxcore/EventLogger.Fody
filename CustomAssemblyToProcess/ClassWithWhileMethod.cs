using System.Diagnostics;
using EventLogger;

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