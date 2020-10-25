using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlowestKey
{
    //https://leetcode.com/contest/weekly-contest-212/problems/slowest-key/

    public class CharacterWithDuration
    {
        public char Character { get; private set; }
        public int Duration { get; private set; }

        public CharacterWithDuration(char character, int duration)
        {
            this.Character = character;
            this.Duration = duration;
        }
    }

    public class CharacterWithDurationComparer : IComparer<CharacterWithDuration>
    {
        public int Compare(CharacterWithDuration x, CharacterWithDuration y)
        {
            if (x.Duration < y.Duration)
            {
                return -1;
            }

            if (x.Duration > y.Duration)
            {
                return 1;
            }

            if (x.Character < y.Character)
            {
                return -1;
            }

            if (x.Character > y.Character)
            {
                return 1;
            }

            return 0;
        }
    }


    public class Solution
    {
        public char SlowestKey(int[] releaseTimes, string keysPressed)
        {
            var characters = keysPressed
                .Select(character => character);

            var beginTime = 0;
            var durations = releaseTimes
                .Select(releaseTime =>
                {
                    var duration = releaseTime - beginTime;
                    // move the clock to next
                    beginTime = releaseTime;
                    return duration;
                });

            var slowestKey = characters
                .Zip(durations, (character, duration) => new CharacterWithDuration (character, duration))
                .OrderByDescending(characterWithDuration => characterWithDuration, new CharacterWithDurationComparer())
                .First()
                .Character;

            return slowestKey;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var releaseTimes1 = new int[] { 9, 29, 49, 50 };
            var keysPressed1 = "cbcd";
            var slowestKey1 = solution.SlowestKey(releaseTimes1, keysPressed1);
            Console.WriteLine(slowestKey1);

            var releaseTimes2 = new int[] { 12, 23, 36, 46, 62 };
            var keysPressed2 = "spuda";
            var slowestKey2 = solution.SlowestKey(releaseTimes2, keysPressed2);
            Console.WriteLine(slowestKey2);

            Console.ReadKey();
        }
    }
}
