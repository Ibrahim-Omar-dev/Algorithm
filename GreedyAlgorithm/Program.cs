namespace GreedyAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] start = { 9, 10, 11, 12, 13, 15 };
            int[] end = { 11, 11, 12, 14, 15, 16 };
            List<int>result=ActivityProblem(start, end);
            foreach (int i in result)
            {
                Console.WriteLine(i);
            }
        }
        public static List<int> ActivityProblem(int[] start, int[] end)
        {
            List<int> list = new List<int>();
            int i = 0;
            int j = 1,k=0;
            list.Add(i);
            for ( i=0;  i< start.Length; i++)
            {
                if (start[i] >= end[j])
                    list.Add(i);
                j = i;
            }
            return list;
        }
    }
}
