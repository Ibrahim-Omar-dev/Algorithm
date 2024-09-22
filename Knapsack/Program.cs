using System.Runtime.CompilerServices;

namespace Knapsack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float[] values = { 4, 9, 12, 11, 6, 5 };
            float[] weights = { 1, 2, 10, 4, 3, 5 };

            // Creating an array of Item objects
            Item[] items = new Item[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                items[i] = new Item(values[i], weights[i], "#"+i);
            }

            // Sorting the array of Item objects based on the ratio of value to weight
            MergeSort.Sort(items, 0, items.Length - 1);

            // Printing the sorted array of Item objects
            PrintHelper.PrintArray(items);

            // Creating a Knapsack object
            knapsack bag = new knapsack(12);

            // Adding items to the knapsack until its current capacity reaches the maximum capacity
            int j = 0;
            while (bag.currentWeight < bag.maxWeight && j < items.Length)
            {
                bag.Add_item(items[j]);
                j++;
            }

            // Printing the items in the Knapsack object
            PrintHelper.PrintItems(bag);
        }
    }

    class Item
    {
        public float weight;
        public float value;
        public float ratio;
        public string name;
        public Item(float value, float weight, string name)
        {
            this.value = value;
            this.weight = weight;
            this.name = name;
            this.ratio = weight != 0 ? value / weight : 0;
        }
    }

    class knapsack
    {
        public float maxWeight { get; private set; }
        public float currentWeight { get; private set; }
        public float totalValue { get; private set; }
        public List<Item> Items { get; private set; }

        public knapsack(float maxWeight)
        {
            this.maxWeight = maxWeight;
            this.currentWeight = 0;
            this.totalValue = 0;
            Items = new List<Item>();
        }
        public void Add_item(Item newItem)
        {
            if (newItem.weight > maxWeight - currentWeight)
            {
                float diff = maxWeight - currentWeight;
                newItem.weight = diff;
                newItem.value = diff * newItem.ratio;
            }
            Items.Add(newItem);
            currentWeight += newItem.weight;
            totalValue += newItem.value;
        }
    }

    class MergeSort
    {
        public static void Sort(Item[] array, int start, int end)
        {
            if (end <= start)
                return;

            int midpoint = (end + start) / 2;
            Sort(array, start, midpoint);
            Sort(array, midpoint + 1, end);
            Merge(array, start, midpoint, end);
        }

        private static void Merge(Item[] array, int start, int midpoint, int end)
        {
            int leftLength = midpoint - start + 1;
            int rightLength = end - midpoint;

            Item[] leftArray = new Item[leftLength];
            Item[] rightArray = new Item[rightLength];

            Array.Copy(array, start, leftArray, 0, leftLength);
            Array.Copy(array, midpoint + 1, rightArray, 0, rightLength);

            int i = 0, j = 0, k = start;
            while (i < leftLength && j < rightLength)
            {
                if (leftArray[i].ratio > rightArray[j].ratio)
                {
                    array[k] = leftArray[i];
                    i++;
                }
                else
                {
                    array[k] = rightArray[j];
                    j++;
                }
                k++;
            }

            while (i < leftLength)
            {
                array[k] = leftArray[i];
                i++;
                k++;
            }

            while (j < rightLength)
            {
                array[k] = rightArray[j];
                j++;
                k++;
            }
        }
    }


    class PrintHelper
    {
        public static void PrintItems(knapsack bag)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Total Value: {bag.totalValue}");
            Console.WriteLine($"Current Capacity: {bag.currentWeight}");
            Console.WriteLine("Items:");
            Console.WriteLine("n\tv\tw");

            foreach (var item in bag.Items)
            {
                Console.WriteLine($"{item.name}\t{item.value}\t{item.weight}");
            }
        }

        public static void PrintArray(Item[] items)
        {
            Console.WriteLine("n\tv\tw\tr");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.name}\t{item.value}\t{item.weight}\t{item.ratio}");
            }
        }
    }
}

