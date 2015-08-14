using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HR.MongoDB;

namespace HR
{
    class Program
    {

        static void Main(String[] args)
        {
            YouTube yt = new YouTube();
            yt.FindLink("");

            //MongoTest mt = new MongoTest();
            //mt.MakeConnection();

            //Console.WriteLine("Start: ");
            //ThoughtWorks m = new ThoughtWorks();

            //int[] A = new int[10];
            ////RandomData(A);
            //int[] B = (int[])A.Clone();
            ////Shuffle(B);
            //Thread.Sleep(10);
            //RandomData(B);
            ////Print(A);
            ////Print(B);
            //Stopwatch w = new Stopwatch();
            //w.Start();

            //Console.WriteLine(ThoughtWorks.partiescompare(A, B));
            //double sec = w.ElapsedMilliseconds;
            //w.Stop();
            //Console.WriteLine("Total Time 1 (in ms):" + sec);
            //w.Reset();
            //w.Start();
            //Console.WriteLine(ThoughtWorks.partiescompare1(A, B));
            //sec = w.ElapsedMilliseconds;
            //w.Stop();
            //Console.WriteLine("Total Time 1 (in ms):" + sec);

            //Console.WriteLine(ThoughtWorks.ThirstyCrowProblem(A, 10, 4));
            //Array.Sort(A);
            //Print(A);
            //Array.Sort(B);
            //Print(B);
            Console.Read();
        }

        static void Main_HR(String[] args)
        {
            int[] res;

            int _A_size = Convert.ToInt32(Console.ReadLine());
            int[] _A = new int[_A_size];
            int _A_item;
            for (int _A_i = 0; _A_i < _A_size; _A_i++)
            {
                _A_item = Convert.ToInt32(Console.ReadLine());
                _A[_A_i] = _A_item;
            }

            res = coprimeCount(_A);
            for (int res_i = 0; res_i < res.Length; res_i++)
            {
                Console.WriteLine(res[res_i]);
            }
            Console.Read();

        }

        static int[] coprimeCount(int[] A)
        {
            int[] B = new int[A.Length];


            for (int i = 0; i < A.Length; i++)
            {
                int result = 0;

                if (A[i] == 1)
                {
                    B[i] = 1;
                }
                else
                {
                    for (int j = 1; j < A[i]; j++)
                    {
                        int a = A[i];
                        int b = j;
                        if (a < 0)
                            a = a * -1;
                        int gcd = findMe(a, b, 1);

                        if (gcd == 1)
                            result++;
                    }
                    B[i] = result;
                }
            }
            return B;
        }
        public static int findMe(int a, int b, int res)
        {
            if (a == b)
                return res * a;
            if (a % 2 == 0 && b % 2 == 0)
                return findMe(a / 2, b / 2, 2 * res);
            else if (a % 2 == 0)
                return findMe(a / 2, b, res);
            else if (b % 2 == 0)
                return findMe(a, b / 2, res);
            else if (a > b)
                return findMe(a - b, b, res);
            else
                return findMe(a, b - a, res);
        }

        public static void RandomData(int[] A)
        {
            int Min = 0;
            int Max = 10;

            Random R = new Random();
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = R.Next(Min, Max);
            }
        }

        public static void Print(int[] A)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < A.Length; i++)
            {
                sb.Append(A[i] + ",");
            }
            Console.WriteLine(sb.ToString());
        }

        public static void Shuffle(IList<Int32> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Int32 value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
