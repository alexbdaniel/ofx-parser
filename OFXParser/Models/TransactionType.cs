using System.Xml.Serialization;

namespace OFXParser.Models;

public enum TransactionType
{
    [XmlEnum("CREDIT")]
    Credit,
    /// <summary>
    /// Generic debit
    /// </summary>
    [XmlEnum("DEBIT")]
    Debit,
    /// <summary>
    /// Interest earned or paid. Depends on signage of amount.
    /// </summary>
    [XmlEnum("INT")]
    Interest,
    [XmlEnum("DIV")]
    Dividend,
    [XmlEnum("FEE")]
    FinancialInstitutionFee,
    [XmlEnum("SRVCHG")]
    ServiceCharge,
    [XmlEnum("DEP")]
    Deposit,
    /// <summary>
    /// ATM debit or credit. Depends on signage of amount.
    /// </summary>
    [XmlEnum("ATM")]
    AutomaticTellerMachine,
    PointOfSale,
    Transfer,
    Check,
    ElectronicPayment,
    CashWithdrawal,
    DirectDeposit,
    DirectDebit,
    RepeatPayment,
    Hold,
    [XmlEnum("OTHER")]
    Other
}