using System;

public delegate void credit_event_handler(decimal balance);

public class credit_event
{
    public event credit_event_handler credit_usage;

    public void credit_start(decimal balance)
    {
        credit_usage?.Invoke(balance);
    }
}