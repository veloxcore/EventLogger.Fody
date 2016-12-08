using System;
using System.Collections.Generic;
using System.Linq;

public class MyLogger
{
    public Dictionary<string, string> EventByFrame { get; set; } = new Dictionary<string, string>();

    public string EventName
    {
        set
        {
            var stack = Environment.StackTrace.Split('\n')[3];
            stack = stack.Substring(0, stack.Length - 3);

            if (EventByFrame.ContainsKey(stack))
            {
                if (string.IsNullOrEmpty(value))
                    EventByFrame.Remove(stack);
                else
                    EventByFrame[stack] = value;

            }
            else if (!string.IsNullOrEmpty(value))
                EventByFrame.Add(stack, value);
        }
    }

    public void Info(string message, string location = null, Exception exception = null)
    {
        LogEntry logEvent = new LogEntry
        {
            ID = 0,
            Message = message,
            TimeStamp = DateTime.UtcNow,
            Type = Enums.LogLevel.DEBUG,
            UserName = "username",
            Location = location
        };

        var eventname = Environment.StackTrace.Split('\n').Select(o => o.Substring(0, o.Length - 3)).Where(o => EventByFrame.Keys.Any(k => o.Equals(k)));

        if (eventname.Any())
        {
            logEvent.Event = EventByFrame.Where(o => eventname.Contains(o.Key)).Select(o => o.Value).FirstOrDefault();
            logEvent.EventTrace = string.Join(",", EventByFrame.Where(o => eventname.Contains(o.Key)).Select(o => o.Value).ToArray());
        }

        InformationEntries.Add(logEvent);
    }

    public void Error(string message, string location = null, Exception exception = null)
    {
        LogEntry logEvent = new LogEntry
        {
            ID = 0,
            Message = message,
            TimeStamp = DateTime.UtcNow,
            Type = Enums.LogLevel.DEBUG,
            UserName = "username",
            Location = location
        };

        var eventname = Environment.StackTrace.Split('\n').Select(o => o.Substring(0, o.Length - 3)).Where(o => EventByFrame.Keys.Any(k => o.Equals(k)));

        if (eventname.Any())
        {
            logEvent.Event = EventByFrame.Where(o => eventname.Contains(o.Key)).Select(o => o.Value).FirstOrDefault();
            logEvent.EventTrace = string.Join(",", EventByFrame.Where(o => eventname.Contains(o.Key)).Select(o => o.Value).ToArray());
        }

        ErrorEntries.Add(logEvent);
    }

    public bool IsErrorEnabled => true;
    
    public List<LogEntry> ErrorEntries;
    public List<LogEntry> InformationEntries;
}