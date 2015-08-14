using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR
{
    class TimeInString
    {
        static void MainTest(String[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
            int H = Convert.ToInt32(Console.ReadLine());
            int M = Convert.ToInt32(Console.ReadLine());
            string Hour = ConvertStr(H);
            string Minutes = ConvertStr(M);
            string result = "";

            if (M == 0)
                result = Hour + " o' clock";
            else if (M <= 30)
                result = Minutes + " minutes past " + Hour;

            if (M > 30)
            {
                if (M == 45)
                {
                    Console.WriteLine("quarter to " + ConvertStr(H + 1));
                    return;
                }
                int tempM = 60 - M;
                string tempMin = ConvertStr(tempM);


                result = tempMin + " minutes to " + ConvertStr(H + 1);
            }

            Console.WriteLine(result);
        }

        public static string ConvertStr(int i)
        {
            switch (i)
            {
                case 0: return "";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                case 10: return "ten";
                case 11: return "eleven";
                case 12: return "twelve";
                case 13: return "thirteen";
                case 14: return "fourteen";
                case 15: return "fifteen";
                case 16: return "sixteen";
                case 17: return "seventeen";
                case 18: return "eighteen";
                case 19: return "nineteen";
                case 20: return "twenty";
                case 21: return "twenty one";
                case 22: return "twenty two";
                case 23: return "twenty three";
                case 24: return "twenty four";
                case 25: return "twenty five";
                case 26: return "twenty six";
                case 27: return "twenty seven";
                case 28: return "twenty eight";
                case 29: return "twenty nine";
                case 30: return "half";
                case 45: return "quarter";
            }
            return "";
        }

    }
}
