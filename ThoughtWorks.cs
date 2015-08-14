using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace HR
{
    class ThoughtWorks
    {
        public static string partiescompare1(int[] input1, int[] input2)
        {
            //Write code here
            if (input1.Length != input2.Length)
                return "Invalid";

            Array.Sort(input1);
            Array.Sort(input2);

            if (input1[0] < 0 || input2[0] < 0)
                return "Invalid";

            for (int i = 0; i < input1.Length; i++)
            {
                if (input1[i] != input2[i])
                    return "Unequal";
            }
            return "Equal";
        }

        public static string partiescompare(int[] input1, int[] input2)
        {
            //Write code here
            Hashtable ht1 = new Hashtable();
            Hashtable ht2 = new Hashtable();

            if(input1.Length != input2.Length)
                return "Invalid";

            for (int i = 0; i < input1.Length; i++)
            {

                if (input1[i] < 0 || input2[i] < 0)
                    return "Invalid";

                if (!ht1.Contains(input1[i]))
                    ht1.Add(input1[i], 1);
                else
                    ht1[input1[i]] = Convert.ToInt32(ht1[input1[i]]) + 1;

                if (!ht2.Contains(input2[i]))
                    ht2.Add(input2[i], 1);
                else
                    ht2[input2[i]] = Convert.ToInt32(ht2[input2[i]]) + 1;
            }

            foreach (var key in ht1.Keys)
            {
                if (!ht2.Contains(key))
                    return "Unequal";

                if (Convert.ToInt32(ht1[key]) == Convert.ToInt32(ht2[key]))
                {
                    ht2.Remove(key);
                }
                else
                    return "Unequal";
            }
            if (ht2.Count == 0)
                return "Equal";
            else
                return "Unequal";
        }

        public static int ThirstyCrowProblem1(int[] input1, int input2, int input3)
        {
            int index = kthSmallest(input1, 0, input2 - 1, input3);
            return input2 * index;
        }

        public static int kthSmallest(int[] arr, int l, int r, int k)
        {
            // If k is smaller than number of elements in array
            if (k > 0 && k <= r - l + 1)
            {
                // Partition the array around last element and get
                // position of pivot element in sorted array
                int pos = partition(arr, l, r);

                // If position is same as k
                if (pos - l == k - 1)
                    return arr[pos];
                if (pos - l > k - 1)  // If position is more, recur for left subarray
                    return kthSmallest(arr, l, pos - 1, k);

                // Else recur for right subarray
                return kthSmallest(arr, pos + 1, r, k - pos + l - 1);
            }

            // If k is more than number of elements in array
            return Int32.MaxValue;
        }

        public static int partition(int[] arr, int l, int r)
        {
            int x = arr[r], i = l;
            int temp;
            for (int j = l; j <= r - 1; j++)
            {
                if (arr[j] <= x)
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    //swap(&arr[i], &arr[j]);
                    i++;
                }
            }
            temp = arr[i];
            arr[i] = arr[r];
            arr[r] = temp;

            return i;
        }


        public static int ThirstyCrowProblem(int[] input1, int input2, int input3)
        {
            Array.Sort(input1);
            if (input1[0] < 0)
                return -1;

            int result = input1[0] * input2;
            int j = 1;
            while (j < input2 && input1[0] == input1[j])
            {
                j++;
            }
            if (j == input3)
                return result;
            for (int i = j; i < input3 - 1; i++)
            {
                result = result + (input1[i] - input1[i - 1]) * (input2 - i);
            }
            j = input3 - 1;
            int x = j;
            int temp = input1[j];

            while (j < input2 && temp == input1[j])
            {
                j++;
            }
            if (input3 > 1)
                result = result + (input2 - j + 1);
            return result;
        }
    }
}
