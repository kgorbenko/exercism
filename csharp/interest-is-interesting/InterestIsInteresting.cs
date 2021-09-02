using System;

static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        return balance switch {
            < 0     => -3.213f,
            < 1000  => 0.5f,
            < 5000  => 1.621f,
            >= 5000 => 2.475f
        };
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
        => balance + balance * (decimal)InterestRate(balance) * 0.01m * Math.Sign(balance);

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
        => CalculateYears(balance, targetBalance, years: 0);

    private static int CalculateYears(decimal balance, decimal targetBalance, int years)
    {
        return balance >= targetBalance
            ? years
            : CalculateYears(AnnualBalanceUpdate(balance) , targetBalance, years + 1);
    }
}
