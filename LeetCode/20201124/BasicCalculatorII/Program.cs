using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BasicCalculatorII
{
    public class Node
    {
        public int val;
        
        public Node left;
        
        public Node right;

        public Node(int val = 0, Node left = null, Node right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public override string ToString()
        {
            return val.ToString();
        }
    }

    class Program
    {
        // https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/567/week-4-november-22nd-november-28th/3542/

        public class Solution
        {
            private IEnumerable<string> Tokenise(string expression, Dictionary<char, int> operators)
            {
                var token = new StringBuilder();

                foreach (var letter in expression)
                {
                    if (operators.TryGetValue(letter, out _))
                    {
                        yield return token.ToString();
                        yield return letter.ToString();
                        token = new StringBuilder();
                    }
                    else if (!char.IsWhiteSpace(letter))
                    {
                        token.Append(letter);
                    }
                }

                if (token.Length > 0)
                {
                    yield return token.ToString();
                }
            }



            public int Calculate(string expression)
            {
                var operators = new Dictionary<char, int>
                {
                    {'+', 1}, {'-', 1}, {'*', 2}, {'/', 2}
                };

                var tokens = Tokenise(expression, operators);

                foreach (var token in tokens)
                {
                    Console.WriteLine(token);
                }

                return 0;
            }
        }

        static void Main(string[] args)
        {
            var solution = new Solution();

            var result1 = solution.Calculate("3+2*2");
            var result2 = solution.Calculate(" 3/2 ");
            var result3 = solution.Calculate(" 3+5 / 2 ");
        }
    }
}
