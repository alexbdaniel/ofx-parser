using System.Text;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace ConsoleCustom;

public class Parser
{
    public static async Task<OpenFinancialExchange?> ParseAsync()
    {
        const string path = @"C:\Users\alex.daniel\Downloads\ANZ.ofx.xml";
        
        XmlDocument document = new XmlDocument();
        document.Load(path);

        var serializer = new XmlSerializer(typeof(OpenFinancialExchange));
        using var reader = XmlReader.Create(path);
        
        OpenFinancialExchange? ofx = (OpenFinancialExchange?)serializer.Deserialize(reader);

        return ofx;

    }
}