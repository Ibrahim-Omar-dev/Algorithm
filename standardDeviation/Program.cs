using System.Transactions;

namespace standardDeviation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(SD());
            //Console.WriteLine(correlation());
        }
        public static double SD()
        {

            Console.WriteLine("Enter number of array : ");
            int N = int.Parse(Console.ReadLine());
            double[] arr = new double[N];
            double sum = 0;
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"Enter element {i + 1} : ");
                arr[i] = int.Parse(Console.ReadLine());
                sum += arr[i];
            }
            double avg = sum / N;
            double sum2 = 0;
            for (int i = 0; i < N; i++)
            {
                sum2 += Math.Pow((arr[i] - avg), 2);
            }
            double b = sum2 / N;
            return Math.Sqrt(b);
        }

        public static double correlation()
        {
            int N;
            double sumx = 0, sumy = 0, sumxPow2 = 0, sumyPow2 = 0, a = 0;

            Console.WriteLine("Enter number of element in array ");
            N = int.Parse(Console.ReadLine());
            double[] arrx = new double[N];
            double[] arry = new double[N];
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"Enter X{i + 1}");
                arrx[i] = double.Parse(Console.ReadLine());
                Console.WriteLine($"Enter Y{i + 1}");
                arry[i] = double.Parse(Console.ReadLine());
                sumx += arrx[i];
                sumy += arry[i];
                a += arrx[i] * arry[i];
                sumxPow2 += Math.Pow(arrx[i], 2);
                sumyPow2 += Math.Pow(arry[i], 2);
            }
            double b = N * a - sumx * sumy;
            double c=Math.Sqrt(N*sumxPow2 -Math.Pow(sumx, 2));
            double d=Math.Sqrt(N*sumyPow2 -Math.Pow(sumy, 2));
            return b / (c * d);


        }
    }
}
