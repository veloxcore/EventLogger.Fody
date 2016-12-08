using System;
using Anotar.Custom;
#pragma warning disable 1998

public class ClassWithException
{
    public async void AsyncMethod()
    {
        try
        {
            System.Diagnostics.Trace.WriteLine("Foo");
        }
        catch
        {
        }
    }
    public void Debug()
    {
        try
        {
        }
        catch
        {
        }
    }
    public void DebugString()
    {
        try
        {
           LogTo.Debug("TheMessage");
        }
        catch 
        {
        }
    }
    public void DebugStringParams()
    {
        try
        {
        LogTo.Debug("TheMessage {0}",1);
        }
        catch
        {
        }
    }
    public void DebugStringException()
    {
        try
        {
        LogTo.Debug(new Exception(), "TheMessage");
        }
        catch
        {
        }
    }
    public void Information()
    {
        try
        {
        }
        catch
        {
        }
    }
    public void InformationString()
    {
        try
        {
        LogTo.Information("TheMessage");
        }
        catch
        {
        }
    }
    public void InformationStringParams()
    {
        try
        {
        LogTo.Information("TheMessage {0}", 1);
        }
        catch
        {
        }
    }
    public void InformationStringException()
    {
        try
        {
        LogTo.Information(new Exception(), "TheMessage");
        }
        catch
        {
        }
    }
    public void Warning()
    {
        try
        {
        }
        catch
        {
        }
    }
    public void WarningString()
    {
        try
        {
            LogTo.Warning("TheMessage");
        }
        catch
        {
        }
    }
    public void WarningStringParams()
    {
        try
        {
        LogTo.Warning("TheMessage {0}", 1);
        }
        catch
        {
        }
    }
    public void WarningStringException()
    {
        try
        {
        LogTo.Warning(new Exception(), "TheMessage");
        }
        catch
        {
        }
    }
    public void Error()
    {
        try
        {
        }
        catch
        {
        }
    }
    public void ErrorString()
    {
        try
        {
        LogTo.Error("TheMessage");
        }
        catch
        {
        }
    }
    public void ErrorStringParams()
    {
        try
        {
        LogTo.Error("TheMessage {0}", 1);
        }
        catch
        {
        }
    }
    public void ErrorStringException()
    {
        try
        {
        LogTo.Error(new Exception(), "TheMessage");
        }
        catch
        {
        }
    }
    public void Fatal()
    {
        try
        {
        }
        catch
        {
        }
    }
    public void FatalString()
    {
        try
        {
        LogTo.Fatal("TheMessage");
        }
        catch
        {
        }
    }
    public void FatalStringParams()
    {
        try
        {
        LogTo.Fatal("TheMessage {0}", 1);
        }
        catch
        {
        }
    }
    public void FatalStringException()
    {
        try
        {
        LogTo.Fatal(new Exception(), "TheMessage");
        }
        catch
        {
        }
    }
}