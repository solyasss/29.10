using System;

public class Program
{
    public static void Main()
    {
        credit_card my_card = new credit_card(
            "4441-5678-9012-4060", 
            "Olya", 
            new DateTime(2024, 11, 04), 
            "1234567", 
            20000, 
            5000, 
            8000); 
        
        my_card.balance_event.balance_top += (amount, balance) => Console.WriteLine($"Balance topped up by {amount}. New balance: {balance}");
        my_card.money_spent_event.money_spent += (amount, balance) => Console.WriteLine($"Spent {amount}. New balance: {balance}");
        my_card.credit_event.credit_usage += balance => Console.WriteLine($"You started using credit funds. Current balance: {balance}");
        my_card.pin_change_event.pin_changed += () => Console.WriteLine("PIN has been changed.");
        my_card.target_event.target_balance += balance => Console.WriteLine($"Target balance reached: {balance}");

        bool go = true;
        
        while (go)
        {
            Console.WriteLine("\nSelect your choice:");
            Console.WriteLine("1 - Top up balance");
            Console.WriteLine("2 - Spend money");
            Console.WriteLine("3 - Change pin");
            Console.WriteLine("4 - Check balance");
            Console.WriteLine("5 - Exit");
            Console.Write("Your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter amount to top up: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal top_amount))
                    {
                        my_card.top_up_balance(top_amount);
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount");
                    }
                    break;

                case "2":
                    Console.Write("Enter amount to spend: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal spend_amount))
                    {
                        my_card.spend_money(spend_amount);
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount");
                    }
                    break;

                case "3":
                    Console.Write("Enter new pin: ");
                    string new_pin = Console.ReadLine();
                    my_card.change_pin(new_pin);
                    break;

                case "4":
                    Console.WriteLine($"Current balance: {my_card.balance}");
                    Console.WriteLine($"Available credit limit: {my_card.credit_limit}");
                    Console.WriteLine($"Target balance: {my_card.target_balance}");
                    break;

                case "5":
                    go = false;
                    Console.WriteLine("Exiting");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
