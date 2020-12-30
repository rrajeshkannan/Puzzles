using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesEaten
{
    public class ApplesWaiting : IComparable<ApplesWaiting>
    {
        public int ArrivedOn { get; }
        
        public int LastUntil { get; }

        public int Count { get; set; }

        public ApplesWaiting(int arrivedOn, int lastUntil, int count) => (ArrivedOn, LastUntil, Count) = (arrivedOn, lastUntil, count);

        public int CompareTo(ApplesWaiting other)
        {
            if (LastUntil < other.LastUntil)
            {
                return -1;
            }

            if (LastUntil > other.LastUntil)
            {
                return 1;
            }

            return 0;
        }
    }

    public class Solution
    {
        public int EatenApples(int[] apples, int[] days)
        {
            var waitingList = new List<ApplesWaiting>();
            var applesEaten = 0;

            for (int i = 0; i < apples.Length; i++)
            {
                int applesArrived = apples[i];
                int applesExpiry = days[i];
                int applesLastUntil = i + applesExpiry;

                waitingList.Add(new ApplesWaiting(applesArrived, applesLastUntil));
                waitingList.Sort();
            }

            int day = 1;

            while(true)
            {
                var waitingApples = waitingList[0];

                if ((waitingApples.Count > 0) && 
                    (waitingApples.LastUntil <= day))
                {
                    // eat 1 apple
                    applesEaten++;
                    waitingApples.Count--;
                }

                day++;
            }

            return 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var apples1 = new int[] { 1, 2, 3, 5, 2 };
            var days1 = new int[] { 3, 2, 1, 4, 2 };
            var output1 = solution.EatenApples(apples1, days1);

            var apples2 = new int[] { 3, 0, 0, 0, 0, 2 };
            var days2 = new int[] { 3, 0, 0, 0, 0, 2 };
            var output2 = solution.EatenApples(apples2, days2);

            //var apples3 = new int[] { };
            //var days3 = new int[] { };
            //var output3 = solution.EatenApples(apples3, days3);

            //var apples4 = new int[] { };
            //var days4 = new int[] { };
            //var output4 = solution.EatenApples(apples4, days4);
        }
    }
}
