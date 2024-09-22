public class Item
{
    public string Name { get; set; }
    public int Weight { get; set; }
    public int Profit { get; set; }

    public Item(string name, int weight, int profit)
    {
        Name = name;
        Weight = weight;
        Profit = profit;
    }
}

public class KnapsackProblem
{
    public static int Knapsack(List<Item> items, int maxWeight, out List<string> solution)
    {
        // Add a dummy item to the beginning of the list to simplify the dynamic programming algorithm
        items.Insert(0, new Item("#0", 0, 0));

        int n = items.Count;
        solution = new List<string>();

        // Initialize the dynamic programming table with zeros
        int[,] dp = new int[n, maxWeight + 1];

        // Compute the maximum profit that can be obtained for each item and weight limit combination
        for (int i = 1; i < n; i++)
        {
            for (int j = 1; j <= maxWeight; j++)
            {
                if (items[i].Weight <= j)
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], items[i].Profit + dp[i - 1, j - items[i].Weight]);
                }
                else
                {
                    dp[i, j] = dp[i - 1, j];
                }
            }
        }

        // Backtrack through the dynamic programming table to determine the solution
        int remain = maxWeight;
        for (int i = n - 1, j = maxWeight; i > 0 && remain > 0; i--)
        {
            if (dp[i, j] > dp[i - 1, j])
            {
                solution.Add(items[i].Name);
                remain -= items[i].Weight;
                j = remain;
            }
        }

        // Return the maximum profit that can be obtained
        return dp[n - 1, maxWeight];
    }

    public static void Main(string[] args)
    {
        /*
        The time complexity of the dynamic programming algorithm used in this code is O(nW),
        where n is the number of items and W is the maximum weight that can be carried.
        The space complexity of the algorithm is also O(nW).
        */

        List<Item> items = new List<Item>
        {
            new Item("#1", 1, 4),
            new Item("#2", 3, 9),
            new Item("#3", 5, 12),
            new Item("#4", 4, 11)
        };

        int maxWeight = 8;

        // Compute the maximum profit that can be obtained and determine the solution
        List<string> solution;
        int maxProfit = Knapsack(items, maxWeight, out solution);

        // Print the maximum profit and the solution
        Console.WriteLine("Max Profit: " + maxProfit);
        Console.Write("Solution: ");
        foreach (string itemName in solution)
        {
            Console.Write(itemName + " ");
        }
        Console.WriteLine();
    }
}


