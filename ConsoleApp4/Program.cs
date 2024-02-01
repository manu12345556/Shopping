using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<string> shoppingBasket = new List<string> { "Apple", "Apple", "Banana", "Melon", "Melon", "Lime", "Lime", "Lime" };

        decimal totalCost = CalculateTotalCost(shoppingBasket);

        Console.WriteLine($"Total cost of the shopping basket: {totalCost:C}");
        Console.ReadLine();
    }

    static decimal CalculateTotalCost(List<string> shoppingBasket)
    {
        decimal totalCost = 0;

        
        var itemCounts = shoppingBasket.GroupBy(item => item)
                                       .ToDictionary(group => group.Key, group => group.Count());

        
        foreach (var item in itemCounts)
        {
            switch (item.Key)
            {
                case "Apple":
                    totalCost += item.Value * 0.35m;
                    break;

                case "Banana":
                    totalCost += item.Value * 0.20m;
                    break;

                case "Melon":
                    totalCost += (item.Value / 2 + item.Value % 2) * 0.50m; // Buy one get one free
                    break;

                case "Lime":
                    totalCost += (item.Value / 3 * 2 + item.Value % 3) * 0.15m; // Three for the price of two
                    break;

                default:
                    Console.WriteLine($"Unknown item: {item.Key}");
                    break;
            }
        }

        return totalCost;
    }
}
