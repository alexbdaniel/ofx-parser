

using System.Xml.Serialization;

namespace OFXParser.Models;

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
    
    [XmlElement("DTSERVER")]
    public required string _Raw_ResponseCreatedAt { init; private get; }
    [XmlIgnore]
    public DateTime ResponseCreatedAt => Utilities.ParseOfxDateTime(_Raw_ResponseCreatedAt);


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
    public required TransactionType TransactionType;

    [XmlElement("DTPOSTED")]
    public required string _Raw_PostedToAccountOn  { init; private get; }
    [XmlIgnore]
    public DateTime PostedToAccountOn  => Utilities.ParseOfxDateTime(_Raw_PostedToAccountOn);
    
    
    [XmlElement("DTUSER", IsNullable = true)]
    public string? _Raw_UserInitiatedTransactionOn  { init; private get; }

    /// <summary>
    /// When the user initiated transaction, if known
    /// </summary>
    // [XmlIgnore]
    public DateTime? UserInitiatedTransactionOn() => 
        _Raw_UserInitiatedTransactionOn == null ? null : Utilities.ParseOfxDateTime(_Raw_UserInitiatedTransactionOn);
    
    /// <summary>
    /// Transaction amount.
    /// </summary>
    [XmlElement(ElementName = "TRNAMT")]
    public decimal Amount;

    /// <summary>
    /// Transaction identifier issued by the finanical institution. Used to detect duplicate transactions.
    /// </summary>
    [XmlElement(ElementName = "FITID")]
    public double Identifier;

    [XmlElement(ElementName = "MEMO")]
    public string? Memo;
}

[XmlRoot(ElementName = "BANKTRANLIST")]
public class BankTransactions
{
    [XmlElement("DTSTART")]
    public required string _Raw_RangeFrom { init; private get; }
    /// <summary>
    /// Range (inclusive) start.
    /// = "DTSTART" in specification
    /// </summary>
    [XmlIgnore]
    public DateTime RangeFrom => Utilities.ParseOfxDateTime(_Raw_RangeFrom);
    
    [XmlElement("DTEND")]
    public required string _Raw_RangeTo { init; private get; }
    /// <summary>
    /// Range (inclusive) end.
    /// = "DTEnd" in specification
    /// </summary>
    [XmlIgnore]
    public DateTime RangeTo => Utilities.ParseOfxDateTime(_Raw_RangeTo);
    
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

    [XmlElement("DTASOF")]
    public required string _Raw_CurrentAt { init; private get; }
    /// <summary>
    /// The point in time for which this loan balance is current.
    /// = "DTASOF" in specification
    /// </summary>
    [XmlIgnore]
    public DateTime CurrentAt => Utilities.ParseOfxDateTime(_Raw_CurrentAt);
}

[XmlRoot(ElementName = "AVAILBAL")]
public class AvailableBalance
{
    /// <summary>
    /// Balance amount.
    /// </summary>
    [XmlElement(ElementName = "BALAMT")]
    public decimal Amount;
    
    
    [XmlElement("DTASOF")]
    public required string _Raw_CurrentAt { init; private get; }
    /// <summary>
    /// The point in time for which this loan balance is current.
    /// = "DTASOF" in specification
    /// </summary>
    [XmlIgnore]
    public DateTime CurrentAt => Utilities.ParseOfxDateTime(_Raw_CurrentAt);
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
    /// <summary>
    /// Sort of like GUID, "Client-Assigned Tranaction UID". Used to identify transactions within transaction wrappers. Spec. 3.2.1.
    /// </summary>
    [XmlElement(ElementName = "TRNUID")]
    public int ClientAssignedTransactionId;

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