using EventLogger;

public class ClassWithExistingField
{
// ReSharper disable NotAccessedField.Local
    static MyLogger existingLogger;

    static ClassWithExistingField()
    {
        existingLogger = MyLoggerFactory.GetLogger < ClassWithExistingField>();
    }

    public void Debug()
    {
    }
}