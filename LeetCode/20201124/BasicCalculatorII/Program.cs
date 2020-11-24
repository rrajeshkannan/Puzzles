using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Expressions;
using System.Diagnostics;

namespace Expressions
{
    public abstract class Expression
    {
        public abstract int Precedence { get; }

        public abstract int Resolve();

        public static HashSet<char> _operators = new HashSet<char>(
            new char[]
            {
                Add.Operator,
                Subtract.Operator,
                Multiply.Operator,
                Divide.Operator
            });

        public static void Dummy()
        {
        }

        public static IEnumerable<string> Tokenise(string expression)
        {
            var token = new StringBuilder();

            foreach (var letter in expression)
            {
                if (_operators.Contains(letter))
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

        private static BinaryExpression Construct(string leftValue, string operation, string rightValue)
        {
            var left = new Literal(leftValue);
            var right = new Literal(rightValue);

            switch (operation[0])
            {
                case Add.Operator:
                    return new Add(left, right);

                case Subtract.Operator:
                    return new Subtract(left, right);

                case Multiply.Operator:
                    return new Multiply(left, right);

                case Divide.Operator:
                    return new Divide(left, right);

                default:
                    return null;
            }
        }

        private static BinaryExpression Construct(BinaryExpression root, string operation, string value)
        {
            BinaryExpression expression;

            switch (operation[0])
            {
                case Add.Operator:
                    expression = new Add();
                    break;

                case Subtract.Operator:
                    expression = new Subtract();
                    break;

                case Multiply.Operator:
                    expression = new Multiply();
                    break;

                case Divide.Operator:
                    expression = new Divide();
                    break;

                default:
                    return null;
            }

            var literal = new Literal(value);
            expression.Right = literal;

            if (expression.Precedence <= root.Precedence)
            {
                expression.Left = root;
                root = expression;
            }
            else
            {
                expression.Left = root.Right;
                root.Right = expression;
            }

            return root;
        }

        public static Expression Construct(string[] tokens)
        {
            if (tokens.Length < 1)
            {
                return null;
            }

            if (tokens.Length < 3)
            {
                return new Literal(tokens[0]);
            }

            var root = Construct(tokens[0], tokens[1], tokens[2]);

            for (int i = 3; i < tokens.Length - 1; i += 2)
            {
                root = Construct(root, tokens[i], tokens[i + 1]);
            }

            return root;
        }

        private static Expression Construct(Expression root, char operation, string value)
        {
            BinaryExpression expression;

            switch (operation)
            {
                case Add.Operator:
                    expression = new Add();
                    break;

                case Subtract.Operator:
                    expression = new Subtract();
                    break;

                case Multiply.Operator:
                    expression = new Multiply();
                    break;

                case Divide.Operator:
                    expression = new Divide();
                    break;

                default:
                    return null;
            }

            var literal = new Literal(value);
            expression.Right = literal;

            if (expression.Precedence <= root.Precedence)
            {
                expression.Left = root;
                root = expression;
            }
            else
            {
                var rootAsBinary = root as BinaryExpression;

                expression.Left = rootAsBinary.Right;
                rootAsBinary.Right = expression;
            }

            return root;
        }

        public static int Resolve(string input)
        {
            var token = new StringBuilder();
            char operation = char.MinValue;
            Expression root = null;

            foreach (var letter in input)
            {
                if (_operators.Contains(letter))
                {
                    operation = letter;

                    var value = token.ToString();

                    if (root == null)
                    {
                        root = new Literal(value);
                    }
                    else
                    {
                        root = Construct(root, operation, value);
                    }

                    token = new StringBuilder();
                }
                else if (!char.IsWhiteSpace(letter))
                {
                    token.Append(letter);
                }
            }

            if (token.Length > 0)
            {
                var value = token.ToString();
                root = Construct(root, operation, value);
            }

            return root?.Resolve() ?? 0;
        }
    }

    public abstract class BinaryExpression : Expression
    {
        private Expression left;
        private Expression right;

        public Expression Left
        {
            get => left;
            set => left = value ?? throw new ArgumentNullException(nameof(value), "Left cannot be null");
        }

        public Expression Right
        {
            get => right;
            set => right = value ?? throw new ArgumentNullException(nameof(value), "Right cannot be null");
        }

        public BinaryExpression() { }

        public BinaryExpression(Expression left, Expression right)
        {
            Left = left;
            Right = right;
        }
    }

    public class Add : BinaryExpression
    {
        public const char Operator = '+';

        public override int Precedence => 1;

        public Add() { }

        public Add(Expression left, Expression right) : base(left, right) { }

        public override int Resolve() => Left.Resolve() + Right.Resolve();
    }

    public class Subtract : BinaryExpression
    {
        public const char Operator = '-';

        public override int Precedence => 1;

        public Subtract() { }

        public Subtract(Expression left, Expression right) : base(left, right) { }

        public override int Resolve() => Left.Resolve() - Right.Resolve();
    }

    public class Multiply : BinaryExpression
    {
        public const char Operator = '*';

        public override int Precedence => 2;

        public Multiply() { }

        public Multiply(Expression left, Expression right) : base(left, right) { }

        public override int Resolve() => Left.Resolve() * Right.Resolve();
    }

    public class Divide : BinaryExpression
    {
        public const char Operator = '/';

        public override int Precedence => 2;

        public Divide() { }

        public Divide(Expression left, Expression right) : base(left, right) { }

        public override int Resolve() => Left.Resolve() / Right.Resolve();
    }

    public class Literal : Expression
    {
        public int Value { get; private set; }

        public override int Precedence => 0;

        public Literal(String value) => Value = int.Parse(value);

        public override int Resolve() => Value;
    }
}

namespace BasicCalculatorII
{
    class Program
    {
        // https://leetcode.com/explore/challenge/card/november-leetcoding-challenge/567/week-4-november-22nd-november-28th/3542/

        public class Solution
        {
            public int Calculate(string BinaryExpression)
            {
                var tokens = Expression.Tokenise(BinaryExpression);
                var root = Expression.Construct(tokens.ToArray());

                return root?.Resolve() ?? 0;
            }
            public int Resolve(string BinaryExpression)
            {
                var tokens = Expression.Tokenise(BinaryExpression);
                var root = Expression.Construct(tokens.ToArray());

                return root?.Resolve() ?? 0;
            }
        }

        static void Main(string[] args)
        {
            Expression.Dummy();

            var solution = new Solution();

            var watch = Stopwatch.StartNew();
            var result00 = solution.Calculate("3+2*2"); // 7
            var result01 = solution.Resolve("3+2*2"); // 7
            watch.Stop();
            
            watch.Restart();
            var result11 = solution.Calculate("3+2*2"); // 7
            watch.Stop();
            Console.WriteLine(watch.ElapsedTicks);
            watch.Restart();
            var result12 = solution.Resolve("3+2*2"); // 7
            watch.Stop();
            Console.WriteLine(watch.ElapsedTicks);

            watch.Restart();
            var result21 = solution.Calculate(" 3/2 "); // 1
            watch.Stop();
            Console.WriteLine(watch.ElapsedTicks);
            watch.Restart();
            var result22 = solution.Resolve(" 3/2 "); // 1
            watch.Stop();
            Console.WriteLine(watch.ElapsedTicks);

            watch.Restart();
            var result31 = solution.Calculate(" 3+5 / 2 "); // 5
            watch.Stop();
            Console.WriteLine(watch.ElapsedTicks);
            watch.Restart();
            var result32 = solution.Resolve(" 3+5 / 2 "); // 5
            watch.Stop();
            Console.WriteLine(watch.ElapsedTicks);

            watch.Restart();
            var result41 = solution.Calculate(" 3+5 + 2 "); // 10
            watch.Stop();
            Console.WriteLine(watch.ElapsedTicks);
            watch.Restart();
            var result42 = solution.Resolve(" 3+5 + 2 "); // 10
            watch.Stop();
            Console.WriteLine(watch.ElapsedTicks);

            watch.Restart();
            var result51 = solution.Calculate(" 3*5 / 2 "); // 7
            watch.Stop();
            Console.WriteLine(watch.ElapsedTicks);
            watch.Restart();
            var result52 = solution.Resolve(" 3*5 / 2 "); // 7
            watch.Stop();
            Console.WriteLine(watch.ElapsedTicks);
        }
    }
}
