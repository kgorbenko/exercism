public static class SavingsAccount
{
    public static float InterestRate(decimal balance) =>
        balance switch {
            < 0     => 3.213f,
            < 1000  => 0.5f,
            < 5000  => 1.621f,
            >= 5000 => 2.475f
        };

    public static decimal Interest(decimal balance) =>
        (decimal)InterestRate(balance) * balance / 100;

    public static decimal AnnualBalanceUpdate(decimal balance)
        => balance + Interest(balance);

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
        => CalculateYears(balance, targetBalance, years: 0);

    private static int CalculateYears(decimal balance, decimal targetBalance, int years) =>
        balance >= targetBalance
            ? years
            : CalculateYears(AnnualBalanceUpdate(balance), targetBalance, years + 1);
}
