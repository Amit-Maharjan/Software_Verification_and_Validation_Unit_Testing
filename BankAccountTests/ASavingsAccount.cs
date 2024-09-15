using BankAccountLibrary;

namespace BankAccountTests;

class ASavingsAccount
{
    [Test]
    public void ShouldSetBalanceAnnualInterestRateAndAccountStatusToActiveWhenConstructed()
    {
        decimal initialBalance = 100m;
        double annualInterestRate = 0.05;

        var sut = new SavingsAccount(initialBalance, annualInterestRate);

        Assert.That(sut.Balance, Is.EqualTo(initialBalance));
        Assert.That(sut.AnnualInterestRate, Is.EqualTo(annualInterestRate));
        Assert.That(sut.Status, Is.EqualTo(AccountStatus.Active));
    }

    [Test]
    public void ShouldSetBalanceAnnualInterestRateAndAccountStatusToInActiveWhenConstructed()
    {
        decimal initialBalance = 25m;
        double annualInterestRate = 0.05;

        var sut = new SavingsAccount(initialBalance, annualInterestRate);

        Assert.That(sut.Balance, Is.EqualTo(initialBalance));
        Assert.That(sut.AnnualInterestRate, Is.EqualTo(annualInterestRate));
        Assert.That(sut.Status, Is.EqualTo(AccountStatus.Inactive));
    }

    [Test]
    public void ShouldNotChangeBalanceAfterWithdrawalWhenInactive()
    {
        decimal initialBalance = 25m;
        double annualInterestRate = 0.05;
        var sut = new SavingsAccount(initialBalance, annualInterestRate);

        sut.WithdrawAmount(10m);

        Assert.That(sut.Balance, Is.EqualTo(initialBalance));
    }

    [Test]
    public void ShouldChangeBalanceAfterWithdrawalWhenActive()
    {
        decimal initialBalance = 100m;
        double annualInterestRate = 0.05;
        var sut = new SavingsAccount(initialBalance, annualInterestRate);

        sut.WithdrawAmount(10m);

        Assert.That(sut.Balance, Is.EqualTo(90m));
    }

    [Test]
    public void ShouldNotChangeStatusAfterDepositWhenResultantBalanceIsLessThan25()
    {
        decimal initialBalance = 10m;
        double annualInterestRate = 0.05;
        var sut = new SavingsAccount(initialBalance, annualInterestRate);

        sut.DepositAmount(10m);

        Assert.That(sut.Balance, Is.EqualTo(20m));
        Assert.That(sut.Status, Is.EqualTo(AccountStatus.Inactive));
    }

    [Test]
    public void ShouldChangeStatusAfterDepositWhenResultantBalanceIsMoreThan25()
    {
        decimal initialBalance = 10m;
        double annualInterestRate = 0.05;
        var sut = new SavingsAccount(initialBalance, annualInterestRate);

        sut.DepositAmount(20m);

        Assert.That(sut.Balance, Is.EqualTo(30m));
        Assert.That(sut.Status, Is.EqualTo(AccountStatus.Active));
    }

    [Test]
    public void ShouldAddMonthlyServiceChargeIfNumberOfWithdrawsIsGreaterThan4AndChangeAccountStatusToInactiveWhenResultantBalanceIsLessThan25()
    {
        decimal initialBalance = 10m;
        double annualInterestRate = 0.12;
        var sut = new SavingsAccount(initialBalance, annualInterestRate);
        sut.IncrementNumberOfWithdrawals();
        sut.IncrementNumberOfWithdrawals();
        sut.IncrementNumberOfWithdrawals();
        sut.IncrementNumberOfWithdrawals();
        sut.IncrementNumberOfWithdrawals();
        sut.MonthlyServiceCharge = 1m;

        sut.MonthlyProcess();

        Assert.That(sut.Balance, Is.EqualTo(8.08m));
        Assert.That(sut.NumberOfDeposits, Is.EqualTo(0));
        Assert.That(sut.NumberOfWithdrawals, Is.EqualTo(0));
        Assert.That(sut.MonthlyServiceCharge, Is.EqualTo(0));
        Assert.That(sut.Status, Is.EqualTo(AccountStatus.Inactive));
    }

    [Test]
    public void ShouldNotAddMonthlyServiceChargeIfNumberOfWithdrawsIsLessThan4AndChangeAccountStatusToActiveWhenResultantBalanceIsGreaterThan25()
    {
        decimal initialBalance = 101m;
        double annualInterestRate = 0.12;
        var sut = new SavingsAccount(initialBalance, annualInterestRate);
        sut.IncrementNumberOfWithdrawals();
        sut.MonthlyServiceCharge = 1m;

        sut.MonthlyProcess();

        Assert.That(sut.Balance, Is.EqualTo(101m));
        Assert.That(sut.NumberOfDeposits, Is.EqualTo(0));
        Assert.That(sut.NumberOfWithdrawals, Is.EqualTo(0));
        Assert.That(sut.MonthlyServiceCharge, Is.EqualTo(0));
        Assert.That(sut.Status, Is.EqualTo(AccountStatus.Active));
    }
}
