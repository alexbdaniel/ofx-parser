using System.Xml;
using System.Xml.Serialization;
using OFXParser.Models;

namespace OFXParser;

public class Parser
{
    /// <summary>
    /// Parses containing OFX content.
    /// </summary>
    /// <param name="filePath">Full or relative path to the file.</param>
    /// <returns>Class with information from the file.</returns>
    public static OpenFinancialExchange? Parse(string filePath)
    {
        var serializer = new XmlSerializer(typeof(OpenFinancialExchange));
        using var reader = XmlReader.Create(filePath);
        
        OpenFinancialExchange? ofx = (OpenFinancialExchange?)serializer.Deserialize(reader);
        
        return ofx;
    }
}