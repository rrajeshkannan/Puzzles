using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigratoryBirds
{
    // https://www.hackerrank.com/challenges/migratory-birds/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=24-hour-campaign&isFullScreen=true

    class Solution
    {
        class BirdGroup : IComparable<BirdGroup>
        {
            public int BirdId { get; set; }
            public int Count { get; set; }

            public int CompareTo(BirdGroup other)
            {
                // which type of bird is most common?
                if (Count < other.Count)
                {
                    return -1;
                }

                if (Count > other.Count)
                {
                    return 1;
                }

                //  if two or more types of birds are equally common, choose the type with the smallest ID number
                if (BirdId < other.BirdId)
                {
                    return 1;
                }

                if (BirdId > other.BirdId)
                {
                    return -1;
                }

                return 0;
            }
        }


        // Complete the migratoryBirds function below.
        static int migratoryBirds(List<int> arr)
        {
            return arr.GroupBy(birdId => birdId)
                .Select(birdGroup => new BirdGroup() { BirdId = birdGroup.Key, Count = birdGroup.Count() })
                .OrderByDescending(birdGroup => birdGroup)
                .Select(birdGroup => birdGroup.BirdId)
                .First();
        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            //int arrCount = Convert.ToInt32(Console.ReadLine().Trim());

            //List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            //int result = migratoryBirds(arr);

            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();

            var input1 = new List<int> { 1, 4, 4, 4, 5, 3 };
            var result1 = migratoryBirds(input1); // 4

            var input2 = new List<int> { 1, 2, 3, 4, 5, 4, 3, 2, 1, 3, 4 };
            var result2 = migratoryBirds(input2); // 3
        }
    }

}
