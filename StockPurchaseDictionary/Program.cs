using System;
using System.Collections.Generic;
using System.Linq;

namespace StockPurchaseDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> stocks = new Dictionary<string, string>();
            stocks.Add("AAPL", "Apple");
            stocks.Add("GM", "General Motors");
            stocks.Add("GME", "GameStop");
            stocks.Add("GOOGL", "Google");
            stocks.Add("AMZN", "Amazon");

            List<(string ticker, int shares, double price)> purchases = new List<(string, int, double)>();

            purchases.Add((ticker: "GM", shares: 15, price: 10.34));
            purchases.Add((ticker: "GM", shares: 5, price: 15.12));
            purchases.Add((ticker: "AAPL", shares: 20, price: 200.41));
            purchases.Add((ticker: "GME", shares: 800, price: 15.61));
            purchases.Add((ticker: "GME", shares: 100, price: 20.99));
            purchases.Add((ticker: "GME", shares: 5, price: 100.01));
            purchases.Add((ticker: "GOOGL", shares: 10, price: 150.17));
            purchases.Add((ticker: "AMZN", shares: 10, price: 50.84));

            Console.WriteLine("Total Ownership Report\n------------------------");
            var report = new Dictionary<string, double>();
            foreach (var purchase in purchases)
            {
                var value = Math.Round(purchase.shares * purchase.price, 2);
                    if (report.ContainsKey(purchase.ticker))
                    {
                        report[purchase.ticker] += value;
                    }
                    else
                    {
                        report.Add(purchase.ticker, value);
                    }

            }
            foreach (var line in report)
            {
                 foreach(var stock in stocks)
                {
                    if (line.Key == stock.Key)
                    {
                        Console.WriteLine($"{stock.Value}: {String.Format("{0:C}",line.Value)}");
                    }
                }
            }
        }
    }
}
