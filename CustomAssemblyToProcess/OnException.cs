using System;
using System.Diagnostics;
using EventLogger;

public class OnException
{

    [LogToErrorOnException]
    public object MethodThatReturns(string param1, int param2)
    {
        return "a";
    }
    [LogToErrorOnException]
    public void ToError(string param1, int param2)
    {
        throw new Exception("Foo");
    }

    [LogToErrorOnException]
    public object ToErrorWithReturn(string param1, int param2)
    {
        throw new Exception("Foo");
    }
    [LogToErrorOnException]
    public void WithRefs(
        ref string param1,
        ref int param2,
        ref short param3,
        ref long param4,
        ref uint param5,
        ref ushort param6,
        ref ulong param7,
        ref bool param8,
        ref double param9,
        ref decimal param10,
        ref int? param11,
        ref object param12,
        ref char param13,
        ref DateTime param14,
        ref float param15,
        ref IntPtr param16,
        ref ushort param17,
        ref uint param18,
        ref ulong param19,
        ref UIntPtr param20
        )
    {
        throw new Exception("Foo");
    }

    [LogToErrorOnException]
    public object WithRefsWithReturn(
        ref string param1,
        ref int param2,
        ref short param3,
        ref long param4,
        ref uint param5,
        ref ushort param6,
        ref ulong param7,
        ref bool param8,
        ref double param9,
        ref decimal param10,
        ref int? param11,
        ref object param12,
        ref char param13,
        ref DateTime param14,
        ref float param15,
        ref IntPtr param16,
        ref ushort param17,
        ref uint param18,
        ref ulong param19,
        ref UIntPtr param20
        )
    {
        throw new Exception("Foo");
    }
}