using System;

class Program
{
    static void Main(string[] args)
    {
        string text_01 = "HELLOWORLD";
        string text_02 = "OHELOD";
        int n = text_01.Length;
        int m = text_02.Length;

        // Add a space at the beginning of each string
        text_01 = " " + text_01;
        text_02 = " " + text_02;

        // Initialize a 2D array to store the dynamic programming values
        int[,] dp = new int[m + 1, n + 1];

        // Fill in the dp array
        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (text_02[i] == text_01[j])
                {
                    dp[i, j] = 1 + dp[i - 1, j - 1];
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i, j - 1], dp[i - 1, j]);
                }
            }
        }

        // Backtrack through the dp array to construct the LCS string
        string lcs_str = "";
        int x = m, y = n;
        while (x > 0 && y > 0)
        {
            if (dp[x, y] > dp[x, y - 1])
            {
                if (dp[x, y] == dp[x - 1, y])
                {
                    x--;
                }
                else
                {
                    lcs_str = text_02[x] + lcs_str;
                    x--;
                    y--;
                }
            }
            else
            {
                y--;
            }
        }

        // Output the length of the LCS and the LCS string
        Console.WriteLine(dp[m, n]);
        Console.WriteLine(lcs_str);
    }
}

