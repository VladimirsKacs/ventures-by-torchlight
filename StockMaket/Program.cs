using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace StockMarket
{
    class Program
    {
        private static Stats stats;
        static readonly Random _random = new Random();

        static void Main(string[] args)
        {
            if ( File.Exists("stocks.dat"))
            {
                var file = File.OpenText("stocks.dat");
                stats = JsonConvert.DeserializeObject<Stats>(file.ReadToEnd());
                file.Close();
            }
            if (stats == null)
            {
                stats = new Stats
                {
                    Ccc = 1.0,
                    Cmm = 0.5
                };
            }

            Console.WriteLine(@"Dividends?
1.CCC
2.CMM");
            var c = Console.ReadKey();
            switch (c.KeyChar)
            {
                case '1':
                    Console.WriteLine("amount (pf per share)");
                    var amount = Console.ReadLine();
                    stats.Ccc -= double.Parse(amount) * 0.01;
                    break;
                case '2':
                    Console.WriteLine("amount (pf per share)");
                    amount = Console.ReadLine();
                    stats.Cmm -= double.Parse(amount) * 0.01;
                    break;
            }


            stats.Ccc*=1.04+(_random.NextDouble()*0.02);
            stats.Cmm *= 0.95 + (_random.NextDouble() * 0.2);
            Console.WriteLine(@$"[spoiler=stock market]
Charmark Coal Corporation:
Buy:
{_random.Next(1,5)} shares @{stats.Ccc - 0.005:F2}F by general public
{_random.Next(5, 15)} shares @{stats.Ccc - 0.015:F2}F by general public
100 shares @{stats.Ccc * 0.95:F2}F by CCC buyback

Sell:
{_random.Next(1, 5)} shares @{stats.Ccc + 0.005:F2}F by general public
{_random.Next(5, 15)} shares @{stats.Ccc + 0.015:F2}F by general public
{_random.Next(10, 20)} shares @{stats.Ccc * 1.05:F2}F by general public

Charmark Market Maker:
Buy:
{_random.Next(1, 5)} shares @{stats.Cmm - 0.005:F2}F by general public
{_random.Next(5, 15)} shares @{stats.Cmm - 0.015:F2}F by general public
100 shares @{stats.Cmm * 0.95:F2}F by CMM buyback

Sell:
{_random.Next(1, 5)} shares @{stats.Cmm + 0.005:F2}F by general public
{_random.Next(5, 15)} shares @{stats.Cmm + 0.015:F2}F by general public
{_random.Next(10, 20)} shares @{stats.Cmm * 1.05:F2}F by general public
[/spoiler]");
File.WriteAllText("stocks.dat",JsonConvert.SerializeObject(stats));
Console.ReadKey();
        }





    }

    class Stats
    {
        public double Ccc {get ; set;}
        public double Cmm {get ; set;}
    }
}
