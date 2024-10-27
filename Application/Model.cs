using System.Xml.Serialization;

namespace ConsoleCustom;

// using System.Xml.Serialization;
// XmlSerializer serializer = new XmlSerializer(typeof(OFX));
// using (StringReader reader = new StringReader(xml))
// {
//    var test = (OFX)serializer.Deserialize(reader);
// }

[XmlRoot(ElementName="STATUS")]
public class STATUS { 

	[XmlElement(ElementName="CODE")] 
	public int CODE; 

	[XmlElement(ElementName="SEVERITY")] 
	public required string Severity; 
}

[XmlRoot(ElementName="SONRS")]
public class SONRS { 

	[XmlElement(ElementName="STATUS")] 
	public required STATUS Status; 

	[XmlElement(ElementName="DTSERVER")] 
	public required double DateTimeServer; 

	[XmlElement(ElementName="LANGUAGE")] 
	public string Language; 
}

[XmlRoot(ElementName="SIGNONMSGSRSV1")]
public class SIGNONMSGSRSV1 { 

	[XmlElement(ElementName="SONRS")] 
	public SONRS SONRS; 
}

[XmlRoot(ElementName="CCACCTFROM")]
public class CCACCTFROM { 

	[XmlElement(ElementName="ACCTID")] 
	public double AccountId; 
}

[XmlRoot(ElementName="STMTTRN")]
public class STMTTRN { 

	
	[XmlElement(ElementName="TRNTYPE")] 
	public required string TransactionType; 

	[XmlElement(ElementName="DTPOSTED")] 
	public required double PostedToAccountOn; 

	/// <summary>
	/// When the user initiated transaction, if known
	/// </summary>
	[XmlElement(ElementName="DTUSER")] 
	public double? UserInitiatedTransactionOn; 

	[XmlElement(ElementName="TRNAMT")] 
	public double TRNAMT; 

	[XmlElement(ElementName="FITID")] 
	public double FITID; 

	[XmlElement(ElementName="MEMO")] 
	public string? Memo; 
}

[XmlRoot(ElementName="BANKTRANLIST")]
public class BANKTRANLIST { 

	[XmlElement(ElementName="DTSTART")] 
	public int DTSTART; 

	[XmlElement(ElementName="DTEND")] 
	public int DTEND; 

	[XmlElement(ElementName="STMTTRN")] 
	public List<STMTTRN> STMTTRN; 
}

[XmlRoot(ElementName="LEDGERBAL")]
public class LEDGERBAL { 

	[XmlElement(ElementName="BALAMT")] 
	public double BALAMT; 

	[XmlElement(ElementName="DTASOF")] 
	public double DTASOF; 
}

[XmlRoot(ElementName="AVAILBAL")]
public class AVAILBAL { 

	[XmlElement(ElementName="BALAMT")] 
	public double BALAMT; 

	[XmlElement(ElementName="DTASOF")] 
	public double DTASOF; 
}

[XmlRoot(ElementName="CCSTMTRS")]
public class CCSTMTRS { 

	[XmlElement(ElementName="CURDEF")] 
	public string CURDEF; 

	[XmlElement(ElementName="CCACCTFROM")] 
	public CCACCTFROM CCACCTFROM; 

	[XmlElement(ElementName="BANKTRANLIST")] 
	public BANKTRANLIST BANKTRANLIST; 

	[XmlElement(ElementName="LEDGERBAL")] 
	public LEDGERBAL LEDGERBAL; 

	[XmlElement(ElementName="AVAILBAL")] 
	public AVAILBAL AVAILBAL; 
}

[XmlRoot(ElementName="CCSTMTTRNRS")]
public class CCSTMTTRNRS { 

	[XmlElement(ElementName="TRNUID")] 
	public int TRNUID; 

	[XmlElement(ElementName="STATUS")] 
	public STATUS STATUS; 

	[XmlElement(ElementName="CCSTMTRS")] 
	public CCSTMTRS CCSTMTRS; 
}

[XmlRoot(ElementName="CREDITCARDMSGSRSV1")]
public class CREDITCARDMSGSRSV1 { 

	[XmlElement(ElementName="CCSTMTTRNRS")] 
	public CCSTMTTRNRS CCSTMTTRNRS; 
}

[Serializable]
[XmlRoot(ElementName="OFX")]
public class OpenFinancialExchange { 

	[XmlElement(ElementName="SIGNONMSGSRSV1")] 
	public required SIGNONMSGSRSV1 SIGNONMSGSRSV1; 

	[XmlElement(ElementName="CREDITCARDMSGSRSV1")] 
	public required CREDITCARDMSGSRSV1 CREDITCARDMSGSRSV1; 
}

