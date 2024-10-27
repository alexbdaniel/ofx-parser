using System.Threading.Tasks;
using ConsoleCustom;
using JetBrains.Annotations;
using Xunit;

namespace ConsoleCustom.Tests;

[TestSubject(typeof(Parser))]
public class ParserTest
{

    [Fact]
    public async Task ParserNotNull()
    {
        OpenFinancialExchange result = await Parser.ParseAsync();

        Assert.NotNull(result);
    }
}