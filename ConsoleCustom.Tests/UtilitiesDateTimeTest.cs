using System;
using System.Globalization;
using ConsoleCustom;
using JetBrains.Annotations;
using Xunit;
using Xunit.Abstractions;

namespace ConsoleCustom.Tests;

[TestSubject(typeof(Utilities))]
public class UtilitiesDateTimeTest
{
    private readonly ITestOutputHelper testConsole;

    public UtilitiesDateTimeTest(ITestOutputHelper testConsole) => this.testConsole = testConsole;

    [Theory]
    [InlineData(20240927, DateTimeKind.Utc)]
    [InlineData(20240927000000, DateTimeKind.Utc)]
    [InlineData(20241027225959)]
    public void Uint32DateTimes_Parse_given_valid_input(UInt64 value, DateTimeKind expectedDtKind = DateTimeKind.Utc)
    {
        DateTime result = Utilities.ParseOfxDateTime(value);
        
        Action[] checks =
        [
            () => Assert.Equal(result.Kind, expectedDtKind),
        ];

        Assert.Multiple(checks);
    }
}