using System;

public delegate void money_spent_event_handler(decimal amount, decimal new_balance);

public class money_spent_event
{
    public event money_spent_event_handler money_spent;

    public void money_spent_amount(decimal amount, decimal new_balance)
    {
        money_spent?.Invoke(amount, new_balance);
    }
}