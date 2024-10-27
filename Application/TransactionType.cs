namespace ConsoleCustom;

public enum TransactionType
{
    Credit,
    /// <summary>
    /// Generic debit
    /// </summary>
    Debit,
    /// <summary>
    /// Interest earned or paid. Depends on signage of amount.
    /// </summary>
    Interest,
    Dividend,
    FinancialInstitutionFee,
    ServiceCharge,
    Deposit,
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
    Other
}