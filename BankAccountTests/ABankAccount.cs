using BankAccountLibrary;

namespace BankAccountTests;

public class ABankAccount
{
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
}