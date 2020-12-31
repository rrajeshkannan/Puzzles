using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalParser
{
    // https://leetcode.com/contest/weekly-contest-218/problems/goal-parser-interpretation/

    public class Solution
    {
        public string Interpret(string command)
        {
            var result = new StringBuilder();

            for (int i = 0; i < command.Length; )
            {
                switch (command[i])
                {
                    case 'G':
                        {
                            result.Append('G');
                            i++;
                        }
                        break;

                    case '(':
                        {
                            i++;

                            if (command[i] == ')')
                            {
                                i++;
                                result.Append('o');
                            }
                            else
                            {
                                i += 3;
                                result.Append("al");
                            }
                        }
                        break;

                    default:
                        i++;
                        break;
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

            var result1 = solution.Interpret("G()(al)"); // Goal
            var result2 = solution.Interpret("G()()()()(al)"); // Gooooal
            var result3 = solution.Interpret("(al)G(al)()()G"); // alGalooG
        }
    }
}
