using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAllocation
{
    public class Solution
    {
        public int MinimumTimeRequired(int[] jobs, int k)
        {
            if (k == 1)
            {
                return jobs.Sum();
            }

            var orderedJobs = jobs
                .OrderByDescending(job => job)
                .ToArray();

            List<int>[] buckets = new List<int>[k];

            for (int i = 0; i < k; i++)
            {
                buckets[i] = new List<int>();
            }
            
            int bucketId = 0;
            int delta = -1;
            bool changeDirection = true;

            int jobsCount = jobs.Length;
            int leftOvers = jobsCount % k;
            int balancedFills = jobsCount - leftOvers;

            for (int i = 0; i < balancedFills; i++)
            {
                buckets[bucketId].Add(orderedJobs[i]);

                if ((bucketId == k - 1) || (bucketId == 0))
                {
                    if (changeDirection)
                    {
                        delta = -delta;
                        bucketId += delta;
                    }

                    changeDirection = !changeDirection;
                }
                else
                {
                    bucketId += delta;
                }
            }

            var leftOverJobs = orderedJobs
                .Skip(balancedFills)
                .ToArray();

            var bucketSums = buckets
                .Select(bucket => bucket.Sum())
                .OrderBy(sum => sum)
                .ToArray();

            for (int i = 0; i < leftOvers; i++)
            {
                bucketSums[i] += leftOverJobs[i];
            }

            return bucketSums.Max();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var input1 = new int[] { 3, 2, 3 };
            var output1 = solution.MinimumTimeRequired(input1, 3);

            var input2 = new int[] { 1, 2, 4, 7, 8 };
            var output2 = solution.MinimumTimeRequired(input2, 2);

            var input3 = new int[] { 1, 2, 4, 7, 8 };
            var output3 = solution.MinimumTimeRequired(input3, 3);

            var input4 = new int[] { 1, 2, 6, 7, 8 };
            var output4 = solution.MinimumTimeRequired(input4, 2);

            var input5 = new int[] { 8, 8, 6, 4, 2, 1, 1 };
            var output5 = solution.MinimumTimeRequired(input5, 2);

            var input6 = new int[] { 8, 8, 6, 4, 2, 1, 1 };
            var output6 = solution.MinimumTimeRequired(input6, 3);

            var input7 = new int[] { 11, 2, 4 };
            var output7 = solution.MinimumTimeRequired(input7, 1);

            var input8 = new int[] { 4345079, 7190302, 6957449, 5605110 };
            var output8 = solution.MinimumTimeRequired(input8, 1);

            var input9 = new int[] { 2, 9, 17, 6 };
            var output9 = solution.MinimumTimeRequired(input9, 2); // Expected: 17
        }
    }
}
