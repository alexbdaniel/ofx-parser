using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using ConsoleCustom;
using JetBrains.Annotations;
using Xunit;

namespace ConsoleCustom.Tests;

[TestSubject(typeof(Parser))]
public class ParserTest
{

    [Theory]
    [InlineData(@"C:\Users\alex.daniel\Downloads\ANZ.ofx.xml")]
    public async Task ParserNotNull(string ofxFilePath)
    {
        OpenFinancialExchange result = await Parser.ParseAsync(ofxFilePath);

        Assert.NotNull(result);
    }


}