namespace SortData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region insertion sorted
            //int[] array = { 5, 4, 8, 9, 1, 2 };
            //Console.Write("Before sorted data : ");
            //foreach (int i in array) 
            //    Console.Write(i + " ");
            //Console.WriteLine();
            //Console.Write("After sorted data : ");
            //InsertionSort(array);
            //foreach(int i in array)
            //    Console.Write(i+ " ");
            #endregion

            #region Merge sort 
            //int[] array = { 5, 4, 8, 9, 1, 2 };
            //Console.Write("Before sorted data : ");
            //Console.Write(string.Join(",",array));
            //Console.WriteLine();
            //MergeSort(array,0,array.Length-1);
            //Console.Write("After sorted data : ");
            //Console.Write(string.Join(",", array));
            //Console.WriteLine();
            //Console.WriteLine(BinarySearch(array,5));
            #endregion

            #region segregat
            int[] array = { -5, 1, -6, -8, 0, 8, -7, 5, 2, 3 };
            Console.WriteLine("Array before Segregat : " + string.Join(",", array));
            SegregatMerge(array, 0, array.Length -1);
            Console.WriteLine("Array After Segregat : " + string.Join(",", array));
            #endregion
        }
        public static int[] InsertionSort(int[] array)
        {
            int value = 0;
            for (int i = 1; i < array.Length; i++)
            {
                value = array[i];
                int j = 0;
                for (j = i - 1; j >= 0; j--)
                {
                    if (array[j] > value)
                        array[j + 1] = array[j];
                    else
                        break;
                }
                array[j + 1] = value;
            }

            return array;
        }

        public static void MergeSort(int[] array, int start, int end)
        {
            if ((end <= start)) return;
            int midPoint = (start + end) / 2;
            MergeSort(array, start, midPoint);
            MergeSort(array, midPoint + 1, end);
            Merge(array, start, midPoint, end);
        }

        public static void Merge(int[] array, int start, int midPoint, int end)
        {
            int i, j, k;
            int length = array.Length;
            int[] left_array = new int[midPoint - start + 1];
            int[] right_array = new int[end - midPoint];

            for (i = 0; i < left_array.Length; i++)
                left_array[i] = array[i + start];
            for (i = 0; i < right_array.Length; i++)
                right_array[i] = array[i + 1 + midPoint];

            i = j = 0;
            k = start;
            while (i < left_array.Length && j < right_array.Length)
            {
                if (left_array[i] <= right_array[j])
                {
                    array[k] = left_array[i];
                    i++;
                }
                else
                {
                    array[k] = right_array[j];
                    j++;
                }
                k++;
            }
            while (i < left_array.Length)
            {
                array[k] = left_array[i];
                i++;
                k++;
            } while (j < right_array.Length)
            {
                array[k] = right_array[j];
                j++;
                k++;
            }
        }

        public static int BinarySearch(int[] soredArray, int key)
        {
            int start = 0;
            int midPoint = 0;
            int end = soredArray.Length - 1;
            while (start <= end)
            {
                midPoint = (start + end) / 2;
                if (soredArray[midPoint] == key)
                    return midPoint;
                else
                {
                    if (key > soredArray[midPoint])
                        start = midPoint + 1;
                    else
                        end = midPoint - 1;
                }
            }
            return -1;
        }

        public static void Segregat(int[] array, int start, int midPoint, int end)
        {
            int i, j, k;

            int[] left_side = new int[midPoint - start + 1];
            int[] right_side = new int[end - midPoint];

            for (i = 0; i < left_side.Length; i++)
                left_side[i] = array[start + i];
            for (j = 0; j < right_side.Length; j++)
                right_side[j] = array[midPoint + 1 + j];

            j = i = 0;
            k = start;

            while (i < left_side.Length && left_side[i] < 0)
                array[k++] = left_side[i++];
            while (j < right_side.Length && right_side[j] < 0)
                array[k++] = right_side[j++];

            while (i < left_side.Length)
                array[k++] = left_side[i++];
            while (j < right_side.Length)
                array[k++] = right_side[j++];
        }
        public static void SegregatMerge(int[] array, int start, int end)
        {
            if (start >= end) return;
            int midPoint = (start + end) / 2;
            SegregatMerge(array, start, midPoint);
            SegregatMerge(array, midPoint+1, end);
            Segregat(array, start, midPoint, end);

        }
    }
}
