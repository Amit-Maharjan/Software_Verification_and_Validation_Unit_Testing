using BankAccountLibrary;

namespace BankAccountTests;

public class ABankAccount
{
    // Constructor
    [Test]
    public void ShouldSetBalanceAndAnnualInterestRateWhenConstructed()
    {
        // Arrange
        decimal initialBalance = 100m;
        double annualInterestRate = 0.05;

        // Act
        var sut = new BankAccount(initialBalance, annualInterestRate);

        // Assert
        Assert.That(sut.Balance, Is.EqualTo(initialBalance));
        Assert.That(sut.AnnualInterestRate, Is.EqualTo(annualInterestRate));
    }

    // Deposit Method
    [Test]
    public void ShouldIncreaseBalanceAfterDeposit()
    {
        // Arrange
        decimal initialBalance = 100m;
        double annualInterestRate = 0.05;
        decimal depositAmount = 100m;
        var sut = new BankAccount(initialBalance, annualInterestRate);

        // Act
        sut.DepositAmount(depositAmount);

        // Assert
        Assert.That(sut.Balance, Is.EqualTo(initialBalance+depositAmount));
    }

    [Test]
    public void ShouldIncreaseNumberOfDepositsBy1()
    {
        // Arrange
        decimal initialBalance = 100m;
        double annualInterestRate = 0.05;
        var sut = new BankAccount(initialBalance, annualInterestRate);
        var preNumberOfDeposits = sut.NumberOfDeposits;

        // Act
        sut.IncrementNumberOfDeposits();

        // Assert
        Assert.That(sut.NumberOfDeposits, Is.EqualTo(preNumberOfDeposits + 1));
    }

    // Withdraw Method
    [Test]
    public void ShouldDecreaseBalanceAfterWithdraw()
    {
        decimal initialBalance = 100m;
        double annualInterestRate = 0.05;
        decimal withdrawAmount = 10m;
        var sut = new BankAccount(initialBalance, annualInterestRate);

        sut.WithdrawAmount(withdrawAmount);

        Assert.That(sut.Balance, Is.EqualTo(initialBalance - withdrawAmount));
    }

    [Test]
    public void ShouldIncreaseNumberOfWithdrawalsBy1()
    {
        decimal initialBalance = 100m;
        double annualInterestRate = 0.05;
        var sut = new BankAccount(initialBalance, annualInterestRate);
        var preNumberOfWithdrawals = sut.NumberOfWithdrawals;

        sut.IncrementNumberOfWithdrawals();

        Assert.That(sut.NumberOfWithdrawals, Is.EqualTo(preNumberOfWithdrawals + 1));
    }

    // Calculate Interest Method
    [Test]
    public void ShouldCalculateMonthlyInterestAndUpdateBalance()
    {
        decimal initialBalance = 100m;
        double annualInterestRate = 0.12;
        var sut = new BankAccount(initialBalance, annualInterestRate);

        sut.UpdateBalanceMonthly();

        Assert.That(sut.Balance, Is.EqualTo(101m));
    }

    // Monthly Process Method
    [Test]
    public void ShouldSubtractMonthlyServiceChargeCallUpdateBalanceMonthlyMethodAndResetNumberOfDepositsNumberOfWithdrawalsAndMonthlyServiceCharge()
    {
        decimal initialBalance = 101m;
        double annualInterestRate = 0.12;
        var sut = new BankAccount(initialBalance, annualInterestRate);
        sut.MonthlyServiceCharge = 1m;

        sut.MonthlyProcess();

        Assert.That(sut.Balance, Is.EqualTo(101m));
        Assert.That(sut.NumberOfDeposits, Is.EqualTo(0));
        Assert.That(sut.NumberOfWithdrawals, Is.EqualTo(0));
        Assert.That(sut.MonthlyServiceCharge, Is.EqualTo(0));
    }

    // Edge Cases
    [Test]
    public void ShouldNotChangeBalanceAfterDepositOfZeroAmount()
    {
        decimal initialBalance = 100m;
        double annualInterestRate = 0.05;
        var sut = new BankAccount(initialBalance, annualInterestRate);

        sut.DepositAmount(0m);

        Assert.That(sut.Balance, Is.EqualTo(100m));
    }

    [Test]
    public void ShouldNotChangeBalanceAfterDepositOfNegativeAmount()
    {
        decimal initialBalance = 100m;
        double annualInterestRate = 0.05;
        var sut = new BankAccount(initialBalance, annualInterestRate);

        sut.DepositAmount(-10m);

        Assert.That(sut.Balance, Is.EqualTo(100m));
    }

    [Test]
    public void ShouldNotChangeBalanceAfterWithdrawalOfZeroAmount()
    {
        decimal initialBalance = 100m;
        double annualInterestRate = 0.05;
        var sut = new BankAccount(initialBalance, annualInterestRate);

        sut.WithdrawAmount(0m);

        Assert.That(sut.Balance, Is.EqualTo(100m));
    }

    [Test]
    public void ShouldNotChangeBalanceAfterWithdrawalOfNegativeAmount()
    {
        decimal initialBalance = 100m;
        double annualInterestRate = 0.05;
        var sut = new BankAccount(initialBalance, annualInterestRate);

        sut.WithdrawAmount(-10m);

        Assert.That(sut.Balance, Is.EqualTo(100m));
    }

    [Test]
    public void ShouldCalculateMonthlyInterestAndUpdateBalanceForDifferentCombination()
    {
        decimal initialBalance = 200m;
        double annualInterestRate = 0.24;
        var sut = new BankAccount(initialBalance, annualInterestRate);

        sut.UpdateBalanceMonthly();

        Assert.That(sut.Balance, Is.EqualTo(204m));
    }

    [Test]
    public void ShouldSubtractMonthlyServiceChargeCallUpdateBalanceMonthlyMethodAndResetNumberOfDepositsNumberOfWithdrawalsAndMonthlyServiceChargeForDifferentCombination()
    {
        decimal initialBalance = 201m;
        double annualInterestRate = 0.24;
        var sut = new BankAccount(initialBalance, annualInterestRate);
        sut.MonthlyServiceCharge = 1m;

        sut.MonthlyProcess();

        Assert.That(sut.Balance, Is.EqualTo(204m));
        Assert.That(sut.NumberOfDeposits, Is.EqualTo(0));
        Assert.That(sut.NumberOfWithdrawals, Is.EqualTo(0));
        Assert.That(sut.MonthlyServiceCharge, Is.EqualTo(0));
    }
}