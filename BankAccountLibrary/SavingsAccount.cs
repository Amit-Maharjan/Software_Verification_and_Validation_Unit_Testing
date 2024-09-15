namespace BankAccountLibrary;

public enum AccountStatus
{
    Active,
    Inactive
}

public class SavingsAccount : BankAccount
{
    public AccountStatus Status { get; set; }

    public SavingsAccount(decimal initialBalance, double annualInterestRate) : base(initialBalance, annualInterestRate)
    {
        Status = (Balance > 25) ? AccountStatus.Active : AccountStatus.Inactive; 
    }

    public override void WithdrawAmount(decimal withdrawAmount)
    {
        if (AccountStatus.Active.Equals(Status)) base.WithdrawAmount(withdrawAmount);
    }

    public override void DepositAmount(decimal depositAmount)
    { 
        base.DepositAmount(depositAmount);

        if (AccountStatus.Inactive.Equals(Status) && Balance > 25)
        {
            Status = AccountStatus.Active;
        }
    }

    public override void MonthlyProcess()
    {
        if (NumberOfWithdrawals > 4)
        {
            MonthlyServiceCharge += NumberOfWithdrawals - 4;
        }

        base.MonthlyProcess();

        Status = (Balance > 25) ? AccountStatus.Active : AccountStatus.Inactive;
    }
}
