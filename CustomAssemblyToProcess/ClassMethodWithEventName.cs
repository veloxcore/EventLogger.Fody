using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ClassMethodWithEventName
{

    [EventLogger.LogToErrorOnException]
    [EventLogger.EventName("Event Started")]
    public void StartEvent()
    {
        System.Diagnostics.Debug.WriteLine("This is message ");
    }
}
