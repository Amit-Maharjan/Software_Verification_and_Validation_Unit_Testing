namespace BankAccountLibrary;

public class BankAccount
{
    public decimal Balance { get; private set; }
    public double AnnualInterestRate { get; }
    public int NumberOfDeposits { get; private set; }
    public int NumberOfWithdrawals { get; private set; }
    public decimal MonthlyServiceCharge { get; set; }

    public BankAccount(decimal initialBalance, double annualInterestRate)
    {
        Balance = initialBalance;
        AnnualInterestRate = annualInterestRate;
    }

    public virtual void DepositAmount(decimal depositAmount)
    {
        Balance += depositAmount;
    }

    public void IncrementNumberOfDeposits()
    {
        NumberOfDeposits++;
    }

    public virtual void WithdrawAmount(decimal withdrawAmount)
    {
        Balance -= withdrawAmount;
    }

    public void IncrementNumberOfWithdrawals()
    {
        NumberOfWithdrawals++;
    }

    public void UpdateBalanceMonthly()
    {
        double monthlyInterestRate = AnnualInterestRate / 12;
        decimal monthlyInterest = Balance * (decimal) monthlyInterestRate;
        Balance += monthlyInterest;
    }

    public virtual void MonthlyProcess()
    {
        Balance -= MonthlyServiceCharge;
        UpdateBalanceMonthly();
        NumberOfDeposits = 0;
        NumberOfWithdrawals = 0;
        MonthlyServiceCharge = 0;
    }
}
