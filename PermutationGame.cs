using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR
{
    class PermutationGame
    {
        public void solution(int[] A)
        {
            bool AFlag = false;
            if (A.Length % 2 == 1)
                AFlag = true;

            for (int i = 0; i < A.Length; i++)
                for (int j = 0; j < A.Length; j++)
                {
                    if (A[i] > A[j])
                        ContinueGame(i, j);
                }
        }
        public void ContinueGame(int i, int j)
        {
 
        }
    }
}
