namespace DynamicPrograming_stageCoach_
{
    class Program
    {
        const int MAX = 10;
        // Define the labels and data for the graph
        static List<string> labels = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
        static int[,] _data = {
        {0, 2, 4, 3, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 7, 4, 6, 0, 0, 0},
        {0, 0, 0, 0, 3, 2, 4, 0, 0, 0},
        {0, 0, 0, 0, 4, 1, 5, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 1, 4, 0},
        {0, 0, 0, 0, 0, 0, 0, 6, 3, 0},
        {0, 0, 0, 0, 0, 0, 0, 3, 3, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 4},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
    };

        struct State
        {
            public string From;
            public string To;
            public int Cost;
        }

        static void Main()
        {
            int n = _data.GetLength(0);
            // Initialize the states array to store the minimum cost and path to each node
            State[] states = new State[n];
            // Set the last element of the states array to have a cost of 0
            states[n - 1] = new State { From = "", To = "", Cost = 0 };

            // Iterate through each node, starting from the second to last node
            for (int i = n - 2; i >= 0; i--)
            {
                // Initialize the current state with a very large cost and no path
                states[i] = new State { From = labels[i], To = "", Cost = int.MaxValue };
                // Iterate through each neighbor of the current node
                for (int j = i + 1; j < n; j++)
                {
                    // If there is no edge between the current node and the neighbor, continue to the next neighbor
                    if (_data[i, j] == 0) continue;
                    // Calculate the new cost to reach the neighbor and add it to the cost of the neighbor's minimum path
                    int newCost = _data[i, j] + states[j].Cost;
                    // If the new cost is smaller than the current minimum cost for the current node, update the current state
                    if (newCost < states[i].Cost)
                    {
                        states[i].To = labels[j];
                        states[i].Cost = newCost;
                    }
                }
            }

            List<string> path = new List<string> { "A" };
            int idx = 0;

            // Build the path using the states array
            while (idx < states.Length && states[idx].To != "")
            {
                path.Add(states[idx].To);
                idx = labels.IndexOf(states[idx].To);
            }

            // Output the results
            Console.WriteLine("Minimum Cost: " + states[0].Cost);
            Console.WriteLine("Minimum path: " + string.Join(" ", path));
        }
    }

