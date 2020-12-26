using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageWaitingTime
{
    public class Solution
    {
        public double AverageWaitingTime(int[][] customers)
        {
            int[] waitingTimes = new int[customers.Length];

            int chefStartingTime = 1;

            for (int i = 0; i < customers.Length; i++)
            {
                int customerArrivalTime = customers[i][0];
                int preparationTime = customers[i][1];

                int waitingForStartPreparation = 0;

                if (customerArrivalTime < chefStartingTime)
                {
                    // customer earlier than chef
                    waitingForStartPreparation = chefStartingTime - customerArrivalTime;
                }
                else
                {
                    // chef idle
                    chefStartingTime = customerArrivalTime;
                }

                waitingTimes[i] = waitingForStartPreparation + preparationTime;
                chefStartingTime += preparationTime;
            }

            return waitingTimes.Average();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var input1 = new int[][]
            {
                new int[]{ 1, 2 },
                new int[]{ 2,5 },
                new int[]{ 4,3 },
            };

            var output1 = solution.AverageWaitingTime(input1);

            var input2 = new int[][]
            {
                new int[]{ 5, 2 },
                new int[]{ 5,4 },
                new int[]{ 10,3 },
                new int[]{ 20,1 },
            };

            var output2 = solution.AverageWaitingTime(input2);
        }
    }
}
