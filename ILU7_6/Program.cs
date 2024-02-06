using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Fråga användaren att skriva in namnen på produkterna
        Console.WriteLine("Skriv in namn på matvaror:");
        string[] products = Console.ReadLine().Split();

        // Fråga användaren att skriva in priserna för varje matvara
        Console.WriteLine("Skriv in matvarornas priser:");
        int[] prices = Console.ReadLine().Split().Select(int.Parse).ToArray();

        // Skapa en dictionary för att hålla priserna för varje matvara
        var priceDict = new Dictionary<string, int>();
        for (int i = 0; i < products.Length; i++)
        {
            priceDict[products[i]] = prices[i];
        }

        // Fråga användaren att skriva in handlingslistan
        Console.WriteLine("Skriv in din handlingslista:");
        string[] shoppingList = Console.ReadLine().Split();

        // Beräkna den totala kostnaden för handlingslistan
        int totalCost = CalculateTotalCost(shoppingList, priceDict);

        // Skriv ut den totala kostnaden
        Console.WriteLine($"Priset för handlingslistan är {totalCost}");
    }

    static int CalculateTotalCost(string[] shoppingList, Dictionary<string, int> priceDict)
    {
        int totalCost = 0;

        foreach (string product in shoppingList)
        {
            // Kontrollera om produkten finns i prislistan
            if (priceDict.ContainsKey(product))
            {
                // Lägg till priset för produkten till den totala kostnaden
                totalCost += priceDict[product];
            }
            else
            {
                Console.WriteLine($"Produkten {product} saknas i prislistan och ignoreras.");
            }
        }

        return totalCost;
    }
}