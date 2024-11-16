using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace ConsoleCustom;

public class Parser
{
    public static async Task<OpenFinancialExchange?> ParseAsync(string filePath)
    {
        // const string path = @"C:\Users\alex.daniel\Downloads\ANZ.ofx.xml";
        
        // XmlDocument document = new XmlDocument();
        // document.Load(path);

        var serializer = new XmlSerializer(typeof(OpenFinancialExchange));
        using var reader = XmlReader.Create(filePath);
        
        OpenFinancialExchange? ofx = (OpenFinancialExchange?)serializer.Deserialize(reader);

        // ofx.SignonResponseMessageSetV1.SignonResponse.Raw_ResponseCreatedAt

        // OpenFinancialExchange? ofx2 = (OpenFinancialExchange?)serializer2.ReadObject(reader);

        var thing = ofx?.SignonResponseMessageSetV1.SignonResponse.ResponseCreatedAt;

        
        return ofx;

    }
}