using System;

public class LogEntry
{
    public int ID { get; set; }
    public string Message { get; set; }
    public DateTime TimeStamp { get; set; }
    public Enums.LogLevel Type { get; set; }
    public string UserName { get; set; }
    public string Location { get; set; }
    public string Event { get; set; }
    public string EventTrace { get; set; }
}

public class Enums
{
    public enum LogLevel
    {
        INFO = 1,
        DEBUG = 2,
        WARN = 3,
        ERROR = 4,
        FATAL = 5
    }
}