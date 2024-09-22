namespace Graph_MST_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] labels = new char[] { '1', '2', '3', '4', '5', '6' };
            double[,] graph = new double[,] {
               { 0, 6.7, 5.2, 2.8, 5.6, 3.6 },
               { 6.7, 0, 5.7, 7.3, 5.1, 3.2 },
               { 5.2, 5.7, 0, 3.4, 8.5, 4.0 },
               { 2.8, 7.3, 3.4, 0, 8, 4.4 },
               { 5.6, 5.1, 8.5, 8, 0, 4.6 },
               { 3.6, 3.2, 4, 4.4, 4.6, 0 }
            };
            int v =labels.Length;
            int selected_edges_count = 0;
            bool[] selected=new bool[v];
            selected[0] = true;
            while (selected_edges_count < v - 1)
            {
                double minValue = double.MaxValue;
                int temp_from = -1;
                int temp_to = -1;
                for (int i = 0; i < v; i++)
                {
                    if (selected[i])
                    {
                        for(int j = 0; j < v; j++)
                        {
                            if (!selected[j] && graph[i,j] < minValue && graph[i,j] > 0)
                            {
                                minValue =graph[i,j];
                                temp_from = i;
                                temp_to =j;
                                
                            }
                        }
                    }
                }
                
                selected_edges_count++;
                selected[temp_to] = true;
                Console.Write(labels[temp_from] + "->");
                Console.Write(labels[temp_to] + " : ");
                Console.WriteLine(graph[temp_from,temp_to]);
            }

        }
    }
}
