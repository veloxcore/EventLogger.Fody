using System.Collections.Generic;

public class MyLoggerFactory
{

    public static List<LogEntry> ErrorEntries = new List<LogEntry>();
    public static List<LogEntry> InformationEntries = new List<LogEntry>();

    public static MyLogger GetLogger<T>()
    {
        return new MyLogger
               {
                   ErrorEntries = ErrorEntries,
                   InformationEntries = InformationEntries
               };
    }

    public static void Clear()
    {
        ErrorEntries.Clear();
        InformationEntries.Clear();
    }
}