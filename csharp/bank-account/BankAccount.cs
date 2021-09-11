using System;

public class BankAccount
{
    private decimal balance;
    private readonly object balanceLock = new();
    private bool isAccountOpen;

    public void Open() => isAccountOpen = true;

    public void Close() => isAccountOpen = false;

    public decimal Balance
        => isAccountOpen
            ? balance
            : throw new InvalidOperationException("Cannot get balance of closed account.");

    public void UpdateBalance(decimal change)
    {
        if (!isAccountOpen)
        {
            throw new InvalidOperationException("Cannot update balance of closed account.");
        }

        lock (balanceLock)
        {
            balance += change;
        }
    }
}