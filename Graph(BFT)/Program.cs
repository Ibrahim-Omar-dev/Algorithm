using System.Collections;

namespace Graph_BFT_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution1();
        }
        public static void Solution1()
        {
            int v = 9;
            Hashtable graph = new Hashtable(v);
            graph.Add('A', new char[] { 'B', 'C' });
            graph.Add('B', new char[] { 'E', 'D', 'A' });
            graph.Add('C', new char[] { 'A', 'D', 'F' });
            graph.Add('D', new char[] { 'B', 'C', 'F', 'E' });
            graph.Add('E', new char[] { 'B', 'F' });
            graph.Add('F', new char[] { 'D', 'C', 'E', 'H' });
            graph.Add('G', new char[] { 'H', 'I' });
            graph.Add('H', new char[] { 'G', 'F' });
            graph.Add('I', new char[] { 'G', 'H' });

            Queue<char>q=new Queue<char>(v);
            Hashtable visited= new Hashtable(v);
            q.Enqueue('A');
            visited.Add('A',true);

            char current_vertex;
            char[] destinations;
            while(q.Count > 0)
            {
                current_vertex = q.Dequeue();
                destinations = (char[])graph[current_vertex];
                for (int i = 0; i < destinations.Length; i++) 
                {
                    if (!visited.ContainsKey(destinations[i]))
                    {
                        q.Enqueue(destinations[i]);
                        visited.Add(destinations[i],true);
                        Console.WriteLine(current_vertex + " -> " + destinations[i]);
                    }
                }
            }
        }
    }
}
