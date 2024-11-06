using System;

public delegate void balance_event_handler(decimal amount, decimal new_balance);

public class balance_event
{
    public event balance_event_handler balance_top;

    public void balance_up(decimal amount, decimal new_balance)
    {
        balance_top?.Invoke(amount, new_balance);
    }
}