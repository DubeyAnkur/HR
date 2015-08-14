using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR
{
    class DynamicProgramming
    {
        public void TheCoinChangeProblem()
        {
            string s = Console.ReadLine();
            int[] A = s.Split().Select(str => int.Parse(str)).ToArray();
            int N = A[0];
            int M = A[1];
            s = Console.ReadLine().Trim();
            int[] C = s.Split().Select(str => int.Parse(str)).ToArray();

            int[] DP = new int[N + 1];
            DP[0] = 1;
            for (int i = 0; i < C.Length; i++)
            {
                int coin = C[i];
                for (int j = 0; j <= N - coin; j++)
                {
                    if (DP[j] > 0)
                        DP[j + coin] += DP[j];
                }
            }
            Console.WriteLine(DP[N]);
            Console.ReadLine();
        }
        public void RustMurderer()
        {
            int T = Convert.ToInt32(Console.ReadLine());
            for (int t = 0; t < T; t++)
            {
                string s = Console.ReadLine().Trim();
                int[] A = s.Split().Select(str => int.Parse(str)).ToArray();
                int N = A[0];
                int M = A[1];
                List<int>[] ret = new List<int>[N + 1];
                for (int i = 1; i < N + 1; i++)
                    for (int j = 1; j < N + 1; j++)
                        if (i != j) ret[i].Add(j);

                for (int i = 0; i < M; i++)
                {
                    s = Console.ReadLine().Trim();
                    int[] temp = s.Split().Select(str => int.Parse(str)).ToArray();
                    int C1 = temp[0];
                    int C2 = temp[1];
                    ret[C1].Remove(C2);
                    ret[C2].Remove(C1);
                }

                int start = Convert.ToInt32(Console.ReadLine().Trim());
                int[] output = new int[N + 1];


                // While loop from start in output.
                for (int j = 0; j < ret[j].Count; j++)
                {
                    //ret[j] = 1;
                }



                string retStr = "";
                for (int i = 1; i < N + 1; i++)
                {
                    if (i != start)
                        retStr = retStr + output[i] + " ";
                }
                Console.WriteLine(retStr.Trim());
            }
        }
        public void final()
        {
            int N = Convert.ToInt32(Console.ReadLine().Trim());
            string s = Console.ReadLine().Trim();
            int[] A = s.Split().Select(str => int.Parse(str)).ToArray();
            int K = A[0];
            int L = A[1];
            int M = A[2];

            string input = Console.ReadLine().Trim();


        }
        public static int LCS(String A, String B, int index1, int index2)
        {
            int max = 0;
            if (index1 == A.Length)
            {
                //You have reached beyond A and thus no subsequence
                return 0;
            }
            if (index2 == B.Length)
            {   //you may reach end of 2nd string. LCS from that end is 0
                return 0;
            }

            for (int i = index1; i < A.Length; i++)
            {
                int exist = B.IndexOf(A[i], index2);
                if (exist != -1)
                {
                    //   found = true;

                    int temp = 1 + LCS(A, B, i + 1, exist + 1);
                    if (max < temp)
                    {
                        max = temp;
                    }


                }


            }
            return max;

        }

    }
}
