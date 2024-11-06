using System;

public class credit_card
{
    public string card_number { get; set; }
    public string card_holder_name { get; set; }
    public DateTime expiration_date { get; set; }
    public string pin { get; private set; }
    public decimal credit_limit { get; set; }
    public decimal balance { get; private set; }
    public decimal target_balance { get; set; } 

    public balance_event balance_event = new balance_event();
    public credit_event credit_event = new credit_event();
    public money_spent_event money_spent_event = new money_spent_event();
    public pin_change_event pin_change_event = new pin_change_event();
    public target_event target_event = new target_event();

    public credit_card(string card_number, string card_holder_name, DateTime expiration_date, string pin, decimal credit_limit, decimal initial_balance, decimal target_balance)
    {
        this.card_number = card_number;
        this.card_holder_name = card_holder_name;
        this.expiration_date = expiration_date;
        this.pin = pin;
        this.credit_limit = credit_limit;
        this.balance = initial_balance;
        this.target_balance = target_balance;
    }

    public void top_up_balance(decimal amount)
    {
        balance += amount;
        balance_event.balance_up(amount, balance);
        check_target_balance(); 
    }

    public void spend_money(decimal amount)
    {
        if (amount > balance + credit_limit)
        {
            Console.WriteLine("Not enough money and credit money to spend");
            return;
        }

        balance -= amount;
        money_spent_event.money_spent_amount(amount, balance);

        if (balance < 0)
        {
            credit_event.credit_start(balance);
        }
    }

    public void change_pin(string new_pin)
    {
        pin = new_pin;
        pin_change_event.pin_change();
    }

    private void check_target_balance()
    {
        if (balance >= target_balance)
        {
            target_event.target_balance_up(balance);
        }
    }
}
