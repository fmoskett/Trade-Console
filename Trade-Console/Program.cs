using System.Globalization;
using TradeCategorizer.Domain.Entities;

class Program
{
    static void Main()
    {
        List<Trade> trades = new List<Trade>();
        TradeService tradeService = new TradeService();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Trade Categorizer Application");
            Console.WriteLine("1. Add Trade");
            Console.WriteLine("2. Categorize Trades");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");
            string option = Console.ReadLine();

            if (option == "1")
            {
                AddTrade(trades);
            }
            else if (option == "2")
            {
                CategorizeTrades(trades, tradeService);
            }
            else if (option == "3")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid option. Press any key to continue...");
                Console.ReadKey();
            }
        }
    }

    static void AddTrade(List<Trade> trades)
    {
        Console.Clear();
        Console.WriteLine("Add a New Trade");

        Console.Write("Value: ");
        string inputValue = Console.ReadLine();
        if (!double.TryParse(inputValue, NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out double value))
        {
            Console.WriteLine("Invalid input. Please enter a valid number. Press any key to continue...");
            Console.ReadKey();
            return;
        }

        Console.Write("Client Sector (Public/Private): ");
        string clientSector = Console.ReadLine();

        Console.Write("Next Payment Date (MM/dd/yyyy): ");
        if (!DateTime.TryParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime nextPaymentDate))
        {
            Console.WriteLine("Invalid date format. Please enter a date in the format MM/dd/yyyy. Press any key to continue...");
            Console.ReadKey();
            return;
        }

        Trade trade = new Trade(value, clientSector, nextPaymentDate);
        trades.Add(trade);

        Console.WriteLine("Trade added successfully. Press any key to continue...");
        Console.ReadKey();
    }

    static void CategorizeTrades(List<Trade> trades, TradeService tradeService)
    {
        Console.Clear();
        Console.WriteLine("Categorize Trades");

        if (trades.Count == 0)
        {
            Console.WriteLine("No trades available to categorize. Press any key to continue...");
            Console.ReadKey();
            return;
        }

        Console.Write("Reference Date (MM/dd/yyyy): ");
        if (!DateTime.TryParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime referenceDate))
        {
            Console.WriteLine("Invalid date format. Please enter a date in the format MM/dd/yyyy. Press any key to continue...");
            Console.ReadKey();
            return;
        }

        var categorizedTrades = tradeService.CategorizeTrades(trades, referenceDate);

        Console.WriteLine("Categorized Trades:");
        foreach (var item in categorizedTrades)
        {
            Console.WriteLine($"Value: {item.Trade.Value:C}, Client Sector: {item.Trade.ClientSector}, Next Payment Date: {item.Trade.NextPaymentDate:MM/dd/yyyy}, Category: {item.Category}");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
