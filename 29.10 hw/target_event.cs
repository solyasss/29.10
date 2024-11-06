using System;

public delegate void target_event_handler(decimal current_balance);

public class target_event
{
    public event target_event_handler target_balance;

    public void target_balance_up(decimal current_balance)
    {
        target_balance?.Invoke(current_balance);
    }
}