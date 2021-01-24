using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatestTime
{
    // https://leetcode.com/contest/weekly-contest-225/problems/latest-time-by-replacing-hidden-digits/

    public class Solution
    {
        public string MaximumTime(string time)
        {
            var characters = new char[] { '1', '9', ':', '5', '9' };

            var hourFirstAlternateLetter = '2';
            var hourSecondAlternateLetter = '3';

            var result = new StringBuilder();

            for (int i = 0; i < time.Length; i++)
            {
                var actual = time[i];

                if (actual != '?')
                {
                    result.Append(actual);
                }
                else
                {
                    if (i == 0)
                    {
                        var hourActualSecond = time[1];

                        if ((hourActualSecond == '?') 
                            || (hourActualSecond == '0') 
                            || (hourActualSecond == '1') 
                            || (hourActualSecond == '2') 
                            || (hourActualSecond == '3'))
                        {
                            result.Append(hourFirstAlternateLetter);
                        }
                        else
                        {
                            result.Append(characters[i]);
                        }
                    }
                    else if(i == 1)
                    {
                        if (result[0] == '2')
                        {
                            result.Append(hourSecondAlternateLetter);
                        }
                        else
                        {
                            result.Append(characters[i]);
                        }
                    }
                    else
                    {
                        result.Append(characters[i]);
                    }
                }
            }

            return result.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var output1 = solution.MaximumTime("2?:?0");
            var output2 = solution.MaximumTime("0?:3?");
            var output3 = solution.MaximumTime("1?:22");
            var output4 = solution.MaximumTime("?4:03");
            var output5 = solution.MaximumTime("??:3?");
        }
    }
}
