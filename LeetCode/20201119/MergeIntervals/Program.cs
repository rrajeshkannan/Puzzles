using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeIntervals
{
    // https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/566/week-3-november-15th-november-21st/3535/

    public class Solution
    {
        public int[][] Merge(int[][] intervals)
        {
            //var mergedIntervals = intervals
            //    .SelectMany(interval => new int[] { interval[0], interval[1] })
            //    .OrderBy(interval => interval)
            //    .Distinct();

            var flatIntervals = intervals
                .SelectMany(interval => new int[] { interval[0], interval[1] })
                .ToArray();

            var flatOrderedIntervals = flatIntervals
                .OrderBy(interval => interval)
                .ToArray();

            var mergedIntervals = flatIntervals
                .Distinct()
                .ToArray();

            var beginIntervals = mergedIntervals.Where((interval, index) => index % 2 == 0);
            var endIntervals = mergedIntervals.Where((interval, index) => index % 2 == 1);

            var result = beginIntervals
                .Zip(endIntervals, (beginInterval, endInterval) => new int[] { beginInterval, endInterval })
                .ToArray();

            return result;

            //return beginIntervals
            //    .Zip(endIntervals, (beginInterval, endInterval) => new int[] { beginInterval, endInterval })
            //    .ToArray();
        }

        public class IntervalsComparer : IComparer<int[]>
        {
            public int Compare(int[] x, int[] y)
            {
                if (x[0] < y[0])
                    return -1;
                
                if (x[0] > y[0])
                    return 1;

                if (x[1] < y[1])
                    return -1;

                if (x[1] > y[1])
                    return 1;

                return 0;
            }
        }

        public int[][] Merge1(int[][] intervals)
        {
            int Merge(int front, int rear)
            {
                if (rear >= intervals.Length)
                {
                    return front;
                }

                var merged = false;

                if (intervals[front][0] >= intervals[rear][0])
                {
                    intervals[front][0] = intervals[rear][0];

                    if (intervals[front][1] < intervals[rear][1])
                    {
                        intervals[front][1] = intervals[rear][1];
                    }

                    merged = true;
                }
                else if (intervals[front][1] >= intervals[rear][0])
                {
                    if (intervals[front][1] < intervals[rear][1])
                    {
                        intervals[front][1] = intervals[rear][1];
                    }

                    merged = true;
                }
                else if (intervals[front][1] > intervals[rear][1])
                {
                    return front;
                }
                
                if (merged)
                {
                    if (front > 0)
                    {
                        // check opportunities for merging of intervals that are already resolved before
                        front = Merge(front - 1, front);
                    }

                    // else, front maintains its position due to the merge
                }
                else
                {
                    // no merge happened, so, front moves ahead
                    front++;

                    // preserve current interval into results at new front
                    intervals[front][0] = intervals[rear][0];
                    intervals[front][1] = intervals[rear][1];
                }

                // rear moves ahead with next interval
                return Merge(front, rear + 1);
            }

            intervals = intervals.OrderBy(interval => interval, new IntervalsComparer()).ToArray();

            var lastMergedPosition = Merge(0, 1);
            return intervals.Take(lastMergedPosition + 1).ToArray();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var intervals1 = new int[][] {
                new int[] { 1, 3 },
                new int[] { 2, 6 },
                new int[] { 8, 10 },
                new int[] { 15, 18 }
            };
            var result1 = solution.Merge(intervals1); // [[1,6],[8,10],[15,18]]

            var intervals9 = new int[][] {
                new int[] { 1, 2 },
                new int[] { 3, 6 },
                new int[] { 8, 10 },
                new int[] { 15, 18 }
            };
            var result9 = solution.Merge(intervals9); // [[1,2],[3,6],[8,10],[15,18]]

            var intervals10 = new int[][]
            {
                new int[] { 1, 4 }
            };
            var result10 = solution.Merge(intervals10); // [[1,4]]

            var intervals2 = new int[][]
            {
                new int[] { 1, 4 },
                new int[] { 4, 5 }
            };
            var result2 = solution.Merge(intervals2); // [[1,5]]

            var intervals3 = new int[][]
            {
                new int[] { 0, 0 },
                new int[] { 0, 0 }
            };
            var result3 = solution.Merge(intervals3); // [[0,0]]

            var intervals4 = new int[][] {
                new int[] { 1, 10 },
                new int[] { 2, 3 },
                new int[] { 8, 10 },
                new int[] { 15, 18 }
            };
            var result4 = solution.Merge(intervals4); // [[1,10][15,18]]

            var intervals5 = new int[][] {
                new int[] { 1, 11 },
                new int[] { 2, 3 },
                new int[] { 8, 10 },
                new int[] { 15, 18 }
            };
            var result5 = solution.Merge(intervals5); // [[1,11][15,18]]

            var intervals6 = new int[][] {
                new int[] { 1, 15 },
                new int[] { 2, 3 },
                new int[] { 8, 10 },
                new int[] { 15, 18 }
            };
            var result6 = solution.Merge(intervals6); // [[1,18]]

            var intervals7 = new int[][]
            {
                new int[] { 1, 4 },
                new int[] { 0, 4 }
            };
            var result7 = solution.Merge(intervals7); // [[0,4]]

            var intervals8 = new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 3, 4 },
                new int[] { 0, 5 }
            };
            var result8 = solution.Merge(intervals8); // [[0,5]]

            var intervals11 = new int[][]
            {
                new int[] { 1, 4 },
                new int[] { 0, 0 }
            };
            var result11 = solution.Merge(intervals11); // [[0,0],[1,4]]

            var intervals12 = new int[][]
            {
                new int[] { 1, 4 },
                new int[] { 0, 1 }
            };
            var result12 = solution.Merge(intervals12); // [[0,4]]

            var intervals13 = new int[][]
            {
                new int[] {2, 3},
                new int[] {2, 2},
                new int[] {3, 3},
                new int[] {1, 3},
                new int[] {5, 7},
                new int[] {2, 2},
                new int[] {4, 6}
            };
            var result13 = solution.Merge(intervals13); // [[1,3],[4,7]]
        }
    }
}
