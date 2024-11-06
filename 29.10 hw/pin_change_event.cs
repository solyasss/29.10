using System;

public delegate void pin_change_event_handler();

public class pin_change_event
{
    public event pin_change_event_handler pin_changed;

    public void pin_change()
    {
        pin_changed?.Invoke();
    }
}