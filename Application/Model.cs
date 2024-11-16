using System.Xml;
using System.Xml.Serialization;

namespace ConsoleCustom;

[XmlRoot(ElementName = "STATUS")]
public class Status
{
    [XmlElement(ElementName = "CODE")]
    public int Code;

    [XmlElement(ElementName = "SEVERITY")]
    public required string Severity;
}

[XmlRoot(ElementName = "SONRS")]
public class SignonResponse
{
    [XmlElement(ElementName = "STATUS")]
    public required Status Status;
    
    [XmlElement(ElementName = "DTSERVER")]
    public DateTime ResponseCreatedAt { get; set; }
    
    
    
    
    // private string? _responseCreatedAt;
    //
    // [XmlElement("DTSERVER")]
    // public string _su_responseCreatedAt
    // {
    //     private get => _responseCreatedAt ?? $"{nameof(_responseCreatedAt)} == null.";
    //     init => ResponseCreatedAt = Utilities.ParseOfxDateTime(value);
    // }
    //
    // [XmlIgnore]
    // public required DateTime ResponseCreatedAt { get; init; }
    
    [XmlElement(ElementName = "LANGUAGE")]
    public string Language = "English";
}



#region MyRegion

//SIGNONMSGSRQV1 = SignonRequestMessgeSetV1
[XmlRoot(ElementName = "SIGNONMSGSRSV1")]
public class SignonResponseMessageSetV1
{
    [XmlElement(ElementName = "SONRS")]
    public required SignonResponse SignonResponse;
}

[XmlRoot(ElementName = "CCACCTFROM")] 
public class CreditCardAccountFrom
{
    [XmlElement(ElementName = "ACCTID")]
    public double AccountId;
}

[XmlRoot(ElementName = "STMTTRN")]
public class StatementTransaction
{
    [XmlElement(ElementName = "TRNTYPE")]
    public required string TransactionType;

    // private double _postedToAccountOn;
    //
    // [XmlElement(ElementName = "DTPOSTED")]
    // public double _su_PostedToAccountOn
    // {
    //     private get => _postedToAccountOn;
    //     init => PostedToAccountOn = Utilities.ParseOfxDateTime(value);
    // }
    //
    // [XmlIgnore]
    // public required DateTime PostedToAccountOn { get; init; }


    /// <summary>
    /// When the user initiated transaction, if known
    /// </summary>
    [XmlElement(ElementName = "DTUSER")]
    public double? UserInitiatedTransactionOn;

    [XmlElement(ElementName = "TRNAMT")]
    public double TRNAMT;

    [XmlElement(ElementName = "FITID")]
    public double FITID;

    [XmlElement(ElementName = "MEMO")]
    public string? Memo;
}

[XmlRoot(ElementName = "BANKTRANLIST")]
public class BankTransactions
{
    private UInt64 _start;
    
    [XmlElement(ElementName = "DTSTART")]
    public UInt64 _su_Start
    {
        get => _start;
        init => Start = Utilities.ParseOfxDateTime(value);
    }
    
    [XmlIgnore]
    public DateTime? Start { get; init; }

    private UInt64 _end;

    [XmlElement(ElementName = "DTEND")]
    public UInt64 _su_End
    {
        get => _end;
        init => End = Utilities.ParseOfxDateTime(value);
    }
    
    [XmlIgnore]
    public DateTime? End { get; init; }
    
    [XmlElement(ElementName = "STMTTRN")]
    public List<StatementTransaction>? StatementTransaction;
}

[XmlRoot(ElementName = "LEDGERBAL")]
public class LedgerBalance
{
    /// <summary>
    /// Current loan principal balance, amount
    /// </summary>
    [XmlElement(ElementName = "BALAMT")]
    public double LoanPrincipalBalance { get; init; }

    [XmlElement(ElementName = "DTASOF")]
    public string CurrentAt { get; set; }
    
    // private string? _currentAtString;
    // [XmlElement("DTASOF", Type = typeof(string))]
    // public string _su_CurrentAt
    // {
    //     get => _currentAtString ?? $"{nameof(_currentAtString)} == null.";
    //     set => _currentAtString = value; //CurrentAt = Utilities.ParseOfxDateTime(value);
    // }


    private DateTime _currentAt;


    // /// <summary>
    // /// Date and time of the current loan balance.
    // /// = "DTASOF" in specification
    // /// </summary>
    // [XmlIgnore]
    // public DateTime CurrentAt
    // {
    //     get { return _currentAt; }
    //     set { _currentAt = Utilities.ParseOfxDateTime(_su_CurrentAt); }
    // }
}

[XmlRoot(ElementName = "AVAILBAL")]
public class AvailableBalance
{
    [XmlElement(ElementName = "BALAMT")]
    public double Amount;
    
    private UInt64 _currentAt;
    [XmlIgnore]
    public UInt64 _su_CurrentAt
    {
        get => _currentAt;
        init => CurrentAt = Utilities.ParseOfxDateTime(value);
    }
    
    /// <summary>
    /// Date and time of the current loan balance.
    /// = "DTASOF" in specification
    /// </summary>
    [XmlElement(ElementName = "DTASOF")]
    public required DateTime CurrentAt;
}

[XmlRoot(ElementName = "CCSTMTRS")]
public class CreditCardStatementResponse
{
    [XmlElement(ElementName = "CURDEF")]
    public required string RecurringPaymentResponseDefaultCurrency = "AUD";

    [XmlElement(ElementName = "CCACCTFROM")]
    public required CreditCardAccountFrom CreditCardAccountFrom;

    [XmlElement(ElementName = "BANKTRANLIST")]
    public required BankTransactions Transactions;

    [XmlElement(ElementName = "LEDGERBAL")]
    public required LedgerBalance LedgerBalance;

    [XmlElement(ElementName = "AVAILBAL")]
    public required AvailableBalance AvailableBalance;
}

[XmlRoot(ElementName = "CCSTMTTRNRS")]
public class CreditCardStatementTransactionResponse
{
    [XmlElement(ElementName = "TRNUID")]
    public int TRNUID;

    [XmlElement(ElementName = "STATUS")]
    public required Status Status;

    [XmlElement(ElementName = "CCSTMTRS")]
    public required CreditCardStatementResponse CreditCardStatementResponse;
}

[XmlRoot(ElementName = "CREDITCARDMSGSRSV1")]
public class CreditCardResponseMessageSetV1
{
    [XmlElement(ElementName = "CCSTMTTRNRS")]
    public required CreditCardStatementTransactionResponse CreditCardStatementTransactionResponse;
}

[Serializable]
[XmlRoot(ElementName = "OFX")]
public class OpenFinancialExchange
{
    [XmlElement(ElementName = "SIGNONMSGSRSV1")]
    public required SignonResponseMessageSetV1 SignonResponseMessageSetV1;

    [XmlElement(ElementName = "CREDITCARDMSGSRSV1")]
    public required CreditCardResponseMessageSetV1 CreditCardResponseMessageSetV1;
}

#endregion