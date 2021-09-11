using System;

public class BankAccount
{
    private bool isAccountOpen;
    private float balance;

    public void Open()
    {
        isAccountOpen = true;
    }

    public void Close()
    {
        isAccountOpen = false;
    }

    public float Balance
    {
        get
        {
            if (isAccountOpen)
                return balance;

            throw new InvalidOperationException();
        }
    }

    public void UpdateBalance(float change)
    {
        if (isAccountOpen)
            balance += change;
    }
}