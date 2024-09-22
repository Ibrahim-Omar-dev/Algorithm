using System.Collections;

namespace Sorted_Characters_Frequencies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ASCIIMethod(" Hello Ibrahim ");
            Console.WriteLine("================================");
            AnyMethodCode(" Hello Ibrahim ");
        }
        public static void ASCIIMethod(string message)
        {
            int[] freq = new int[127];
            for (int i = 0; i < message.Length; i++)
            {
                int current_code = (int)message[i];
                freq[current_code]++;
            }
            for (int i = 0; i < freq.Length; i++)
            {
                if (freq[i] > 0)
                {
                    char c = (char)i;
                    Console.Write(c + " ");
                    Console.WriteLine(freq[i]);
                }

            }
        }

        public static void AnyMethodCode(string message)
        {
            Hashtable freq = new Hashtable();
            for (int i = 0; i < message.Length; i++)
            {
                if (freq[message[i]] == null)
                    freq[message[i]] = 1;
                else
                    freq[message[i]] = (int)freq[message[i]] + 1;
            }
            foreach (char k in freq.Keys)
            {
                Console.Write(k + " ");
                Console.WriteLine(freq[k]);
            }
            sortHash(freq);
        }
        public static void sortHash(Hashtable freq)
        {
            int[,] array = new int[freq.Count, 2];
            int i = 0;
            foreach (char k in freq.Keys)
            {
                array[i, 0] = (int)k;
                array[i, 1] = (int)freq[k];
                i++;
            }
            sort(array,0,freq.Count - 1);
            Console.WriteLine("Print Sorted data ...");
            for (i = 0; i < freq.Count; i++)
            {
                Console.Write((char)array[i, 0] + " ");
                Console.WriteLine(array[i, 1]);
            }
        }
        public static void sort(int[,] array, int start, int end)
        {
            if (end >= start) return;
            int midPoint = (start + end) / 2;
            sort(array, start, midPoint);
            sort(array, midPoint + 1, end);
            merge(array,start,midPoint,end);
        }
        public static void merge(int[,] array, int start, int midPoint, int end)
        {
            int i, j, k;
            int left_length = midPoint - start + 1;
            int right_length = end - midPoint;
            int[,] left_side = new int[left_length, 2];
            int[,] right_side = new int[right_length, 2];

            for (i = 0; i < left_length; i++)
            {
                left_side[i, 0] = array[i + start, 0];
                left_side[i, 1] = array[i + start, 1];
            }
            for (j = 0; j < left_length; j++)
            {
                right_side[j, 0] = array[j + midPoint + 1, 0];
                right_side[j, 1] = array[j + midPoint + 1, 1];
            }

            j = i = 0;
            k = start;
            while (i < left_length && j < right_length)
            {
                if (left_side[i, 1] <= right_side[j, 1])
                {
                    array[k, 0] = left_side[i, 0];
                    array[k, 1] = left_side[i, 1];
                    i++;
                }
                else
                {
                    array[k, 0] = right_side[i, 0];
                    array[k, 1] = right_side[i, 1];
                    j++;
                }
                k++;
            }
            while (i < left_length)
            {
                array[k, 0] = left_side[i, 0];
                array[k, 1] = left_side[i, 1];
                i++;
                k++;
            }
            while (j < right_length)
            {
                array[k, 0] = right_side[j, 0];
                array[k, 1] = right_side[j, 1];
                j++;
                k++;
            }
        }

    }
}
