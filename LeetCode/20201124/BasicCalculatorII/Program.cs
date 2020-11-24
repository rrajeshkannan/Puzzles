using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BasicCalculatorII
{
    public abstract class Expression
    {
        public abstract int Precedence { get;}

        public abstract int Resolve();
    }

    public abstract class BinaryExpression : Expression
    {
        protected Expression Left { get; private set; }
        protected Expression Right { get; private set; }

        public BinaryExpression(Expression left, Expression right)
        {
            this.Left = left;
            this.Right = right;
        }
    }

    public class Add : BinaryExpression
    {
        public Add(Expression left, Expression right) : base (left, right) { }

        public override int Precedence => 1;

        public override int Resolve()
        {
            return Left.Resolve() + Right.Resolve();
        }
    }

    public class Subtract : BinaryExpression
    {
        public Subtract(Expression left, Expression right) : base(left, right) { }

        public override int Precedence => 1;

        public override int Resolve()
        {
            return Left.Resolve() - Right.Resolve();
        }
    }

    public class Multiply : BinaryExpression
    {
        public Multiply(Expression left, Expression right) : base(left, right) { }

        public override int Precedence => 2;

        public override int Resolve()
        {
            return Left.Resolve() * Right.Resolve();
        }
    }

    public class Divide : BinaryExpression
    {
        public Divide(Expression left, Expression right) : base(left, right) { }

        public override int Precedence => 2;

        public override int Resolve()
        {
            return Left.Resolve() / Right.Resolve();
        }
    }

    public class Literal : Expression
    {
        public int Value { get; private set; }

        public override int Precedence => 0;

        public Literal(int value)
        {
            Value = value;
        }

        public override int Resolve()
        {
            return Value;
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
