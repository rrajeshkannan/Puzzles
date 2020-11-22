using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DecodeString
{
    public abstract class DecodeState
    {
        protected DecodeContext Context { get; }

        public DecodeState(DecodeContext context) => Context = context;

        public abstract String Decode(string input, ref int index);
    }

    public class Begin : DecodeState
    {
        public Begin(DecodeContext context) : base(context)
        {
        }

        public override String Decode(string input, ref int index)
        {
            if (index >= input.Length)
            {
                return String.Empty;
            }

            var character = input[index];

            if (character >= 'a' && character <= 'z')
            {

            }
        }
    }

    public class RepeatCount : DecodeState
    {
        public RepeatCount(DecodeContext context) : base(context)
        {
        }

        public override String Decode(string input, ref int index)
        {
            throw new NotImplementedException();
        }
    }

    public class Text : DecodeState
    {
        public Text(DecodeContext context) : base(context)
        {
        }

        public override String Decode(string input, ref int index)
        {
            throw new NotImplementedException();
        }
    }

    public class DecodeContext
    {
        public DecodeState Begin { get; }
        public DecodeState RepeatCount { get; }
        public DecodeState RepeatText { get; }

        public DecodeState State { get; set; }

        public DecodeContext()
        {
            Begin = new Begin(this);
            RepeatCount = new RepeatCount(this);
            RepeatText = new Text(this);

            State = Begin;
        }

        public string Decode (string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return String.Empty;
            }

            int index = 0;
            return State.Decode(input, ref index);
        }
    }

    public class Solution
    {
        private DecodeContext _context = new DecodeContext();

        public string DecodeString(string input)
        {
            var result = "";

            var countStarted = false;
            var repeatCount = 0;

            var substring = "";

            foreach (char character in input)
            {
                if (char.IsLetter(character))
                {
                    substring += character;
                }
                else if (char.IsDigit(character))
                {
                    countStarted = true;

                    var digit = Convert.ToInt32(character);
                    repeatCount = repeatCount * 10 + digit;
                }
                else if (character == '[')
                {
                    substring = "";
                }
            }

            return string.Empty;
        }

        public string DecodeString(string input, ref int index)
        {
            for (; index < input.Length; index++)
            {
                var character = input[index];

                if (char.IsLetter(character))
                {
                }
            }

            return String.Empty;
        }

        public string ExtractSubstring(string input, ref int index)
        {
            var substring = "";

            for (; index < input.Length; index++)
            {
                var character = input[index];

                if (!char.IsLetter(character))
                    break;

                substring += character;
            }
            
            return String.Empty;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            solution.DecodeString("");

            //var result1 = solution.DecodeString("3[a]2[bc]");
            //var result2 = solution.DecodeString("3[a2[c]]");
            //var result3 = solution.DecodeString("2[abc]3[cd]ef");
            //var result4 = solution.DecodeString("abc3[cd]xyz");

            Console.ReadKey();
        }
    }
}


public class dummy
{

    public void DecodeString()
    {
        var input = @"add(mul(a,add(b,c)),d) + e - sub(f,g)";
        var pattern =
            @"\(                    # Match (" +
            @"(" +
            @"        [^()]+            # all chars except ()" +
            @"        | (?<Level>\()    # or if ( then Level += 1" +
            @"        | (?<-Level>\))   # or if ) then Level -= 1" +
            @"    )+                    # Repeat (to go from inside to outside)" +
            @"    (?(Level)(?!))        # zero-width negative lookahead assertion" +
            @"    \)                    # Match )";


        Match m = Regex.Match(input, pattern,
            RegexOptions.IgnorePatternWhitespace);
        if (m.Success == true)
        {
            Console.WriteLine("Input: \"{0}\" \nMatch: \"{1}\"", input, m);
            int grpCtr = 0;
            foreach (Group grp in m.Groups)
            {
                Console.WriteLine("   Group {0}: {1}", grpCtr, grp.Value);
                grpCtr++;
                int capCtr = 0;
                foreach (Capture cap in grp.Captures)
                {
                    Console.WriteLine("      Capture {0}: {1}", capCtr, cap.Value);
                    capCtr++;
                }
            }
        }
        else
        {
            Console.WriteLine("Match failed.");
        }


        //string pattern = @"[0-9]*";

        //string[] substrings = Regex.Split(input, pattern);    // Split on numbers
        //foreach (string match in substrings)
        //{
        //    Console.WriteLine("'{0}'", match);
        //}
    }




    public string DecodeString2(string input)
    {
        input = @"add(mul(a,add(b,c)),d) + e - sub(f,g)";
        var pattern =
            @"\(                    # Match (" +
            @"(" +
            @"        [^()]+            # all chars except ()" +
            @"        | (?<Level>\()    # or if ( then Level += 1" +
            @"        | (?<-Level>\))   # or if ) then Level -= 1" +
            @"    )+                    # Repeat (to go from inside to outside)" +
            @"    (?(Level)(?!))        # zero-width negative lookahead assertion" +
            @"    \)                    # Match )";

        var regex = new Regex(pattern,
            RegexOptions.IgnorePatternWhitespace);

        foreach (Match c in regex.Matches(input))
        {
            Console.WriteLine(c.Value);
            //Console.WriteLine(c.Value.Trim('(', ')'));
        }


        //string pattern = @"[0-9]*";

        //string[] substrings = Regex.Split(input, pattern);    // Split on numbers
        //foreach (string match in substrings)
        //{
        //    Console.WriteLine("'{0}'", match);
        //}

        return String.Empty;
    }

    public string DecodeString1(string input)
    {
        //var pattern1 = @"([0-9*?])";
        //var pattern2 = @"\[(.*?)\]";


        //string pattern = "^[^<>]*" +
        //           "(" +
        //           "((?'Open'<)[^<>]*)+" +
        //           "((?'Close-Open'>)[^<>]*)+" +
        //           ")*" +
        //           "(?(Open)(?!))$";
        //string input = "<abc><mno<xyz>>";

        string pattern = @"^[^0-9]*" + @"(?'Count'\d+)"; // @"(\d+)"; 

        Match m = Regex.Match(input, pattern);
        if (m.Success == true)
        {
            Console.WriteLine("Input: \"{0}\" \nMatch: \"{1}\"", input, m);
            int grpCtr = 0;
            foreach (Group grp in m.Groups)
            {
                Console.WriteLine("   Group {0}: {1}", grpCtr, grp.Value);
                grpCtr++;
                int capCtr = 0;
                foreach (Capture cap in grp.Captures)
                {
                    Console.WriteLine("      Capture {0}: {1}", capCtr, cap.Value);
                    capCtr++;
                }
            }
        }
        else
        {
            Console.WriteLine("Match failed.");
        }

        Console.WriteLine();


        return String.Empty;
    }
}