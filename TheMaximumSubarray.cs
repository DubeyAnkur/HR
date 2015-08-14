using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR
{
    class TheMaximumSubarray
    {
        public void solution(int[] A)
        {
            int nonCont = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > 0)
                    nonCont += A[i];
            }
            int maxSum = 0;
            int runSum = 0;
            for (int i = 0; i < A.Length; i++)
            {
                runSum += A[i];
                if (runSum < 0)
                    runSum = 0;

                if (runSum > maxSum)
                    maxSum = runSum;
            }

        }

        public void StockMaximize()
        {
            int T = Convert.ToInt32(Console.ReadLine());
            for (int t = 0; t < T; t++)
            {
                Convert.ToInt32(Console.ReadLine()); // N
                string s = Console.ReadLine();
                int[] A = s.Split().Select(str => int.Parse(str)).ToArray();


                double profit = 0;
                int j = 0;
                while (j < A.Length)
                {
                    int maxI = j;
                    for (int i = j; i < A.Length; i++)
                    {
                        if (A[maxI] < A[i])
                            maxI = i;
                    }
                    int days = 0;
                    double expense = 0;
                    while (j < maxI)
                    {
                        days++;
                        expense += A[j];
                        j++;
                    }
                    profit = profit + ((double)A[maxI]) * days - expense;

                    j++;
                }
                Console.WriteLine(profit);
            }
        }

        public void FairyChess()
        {
            int T = Convert.ToInt32(Console.ReadLine());
            for (int t = 0; t < T; t++)
            {
                string s = Console.ReadLine();
                int[] A = s.Split().Select(str => int.Parse(str)).ToArray();
                int N = A[0];
                int M = A[1];
                int S = A[2];

                int[,] DP = new int[N, N];
                int LX = 0, LY = 0;
                for (int i = 0; i < N; i++)
                {
                    char[] row = Console.ReadLine().ToCharArray();
                    for (int j = 0; j < N; j++)
                    {
                        if (row[j] == 'P')
                            DP[i, j] = -1;
                        else if (row[j] == 'L')
                        {
                            LX = i;
                            LY = j;
                        }
                    }
                }

                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        int count = 5;
                        if (DP[i, j] != -1)
                        {
                            if (i == 0) count--; else if (DP[i - 1, j] == -1) count--;
                            if (i == N - 1) count--; else if (DP[i + 1, j] == -1) count--;
                            if (j == 0) count--; else if (DP[i, j - 1] == -1) count--;
                            if (j == N - 1) count--; else if (DP[i, j + 1] == -1) count--;

                            DP[i, j] = count;
                        }
                    }
                }

                double total = 0;
                globalS = S;
                total = BetterRec(LX, LY, M - 1, DP, N, S-1);
                //total = total % 1000000007;
                Console.WriteLine(total);
            }
            Console.ReadLine();
        }
        public int globalS;
        public double SomeRec(int i, int j, int m, int[,] DP, int N, int S)
        {
            double total = 0; //= DP[i , j];
            if (m == 0)
                return DP[i, j];

            for (int f = 1; f < S + 1; f++)
            {
                total = (total + SomeRec(i, j, m - 1, DP, N, S)) % 1000000007;
                if (i - f >= 0 && DP[i - 1, j] != -1) total = (total + SomeRec(i - f, j, m - 1, DP, N, S)) % 1000000007;
                if (i + f <= N - 1 && DP[i + 1, j] != -1) total = (total + SomeRec(i + f, j, m - 1, DP, N, S)) % 1000000007;
                if (j - f >= 0 && DP[i, j - 1] != -1) total = (total + SomeRec(i, j - f, m - 1, DP, N, S)) % 1000000007;
                if (j + f <= N - 1 && DP[i, j + 1] != -1) total = (total + SomeRec(i, j + f, m - 1, DP, N, S)) % 1000000007;
            }
            return total % 1000000007;
        }
        public double BetterRec(int i, int j, int m, int[,] DP, int N, int S)
        {
            double total = 0; //= DP[i , j];
            if (m == 0)
                return DP[i, j];

            if (S > 0)
            {
                total = (total + BetterRec(i, j, m - 1, DP, N, S - 1)) % 1000000007;
                if (i != 0 && DP[i - 1, j] != -1) total = (total + BetterRec(i - 1, j, m, DP, N, S - 1)) % 1000000007;
                if (i < N - 1 && DP[i + 1, j] != -1) total = (total + BetterRec(i + 1, j, m, DP, N, S - 1)) % 1000000007;
                if (j != 0 && DP[i, j - 1] != -1) total = (total + BetterRec(i, j - 1, m, DP, N, S - 1)) % 1000000007;
                if (j < N - 1 && DP[i, j + 1] != -1) total = (total + BetterRec(i, j + 1, m, DP, N, S - 1)) % 1000000007;
            }
            else
            {
                total = (total + BetterRec(i, j, m - 1, DP, N, S - 1)) % 1000000007;
                if (i != 0 && DP[i - 1, j] != -1) total = (total + BetterRec(i - 1, j, m - 1, DP, N, globalS-1)) % 1000000007;
                if (i < N - 1 && DP[i + 1, j] != -1) total = (total + BetterRec(i + 1, j, m - 1, DP, N, globalS-1)) % 1000000007;
                if (j != 0 && DP[i, j - 1] != -1) total = (total + BetterRec(i, j - 1, m - 1, DP, N, globalS-1)) % 1000000007;
                if (j < N - 1 && DP[i, j + 1] != -1) total = (total + BetterRec(i, j + 1, m - 1, DP, N, globalS-1)) % 1000000007;
            }

            return total % 1000000007;
        }
    }
}
