using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges
{
    public class HackerRank
    {
        public int jumpingOnClouds(List<int> c)
        {
            int jumps = -1;
            int numberofzero = 0;

            foreach (int cloud in c)
            {
                if (cloud == 0)
                {
                    jumps += 1;
                    numberofzero += 1;
                }
                else
                {
                    numberofzero = 0;
                }

                if (numberofzero >= 3)
                {
                    numberofzero = 1;
                    jumps -= 1;
                }
            }
            return jumps;
        }
    }
}
