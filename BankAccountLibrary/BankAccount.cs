
namespace BankAccountLibrary;

public class BankAccount
{
    public decimal Balance { get; private set; }
    public double AnnualInterestRate { get; }
    public int NumberOfDeposits { get; private set; }

    public BankAccount(decimal initialBalance, double annualInterestRate)
    {
        Balance = initialBalance;
        AnnualInterestRate = annualInterestRate;
    }

    public void DepositAmount(decimal depositAmount)
    {
        Balance += depositAmount;
    }

    public void IncrementNumberOfDeposits()
    {
        NumberOfDeposits++;
    }
}
