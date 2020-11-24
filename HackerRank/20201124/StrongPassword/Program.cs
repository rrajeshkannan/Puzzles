using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace StrongPassword
{
    // https://www.hackerrank.com/challenges/strong-password/problem

    class Solution
    {
        static Dictionary<char, LetterKind> _characters= new Dictionary<char, LetterKind>();

        static Solution()
        {
            var numbers = Enumerable.Range('0', '9' - '0' + 1)
                .Select(number => (char)number);
            foreach (var number in numbers)
            {
                _characters.Add(number, LetterKind.Number);
            }

            var lowerCaseCharacters = Enumerable.Range('a', 'z' - 'a' + 1)
                .Select(lowerCaseCharacter => (char)lowerCaseCharacter);
            foreach (var character in lowerCaseCharacters)
            {
                _characters.Add(character, LetterKind.LowerCase);
            }

            var upperCaseCharacters = Enumerable.Range('A', 'Z' - 'A' + 1)
                .Select(upperCaseCharacter => (char)upperCaseCharacter);
            foreach (var character in upperCaseCharacters)
            {
                _characters.Add(character, LetterKind.UpperCase);
            }

            var specialCharacters = "!@#$%^&*()-+"
                .Select(specialCharacter => (char)specialCharacter);
            foreach (var character in specialCharacters)
            {
                _characters.Add(character, LetterKind.SpecialCharacter);
            }
        }


        enum LetterKind
        {
            Unknown,
            Number,
            LowerCase,
            UpperCase,
            SpecialCharacter
        }

        const int MinNumbers = 1;
        const int MinLowerCaseCharacters = 1;
        const int MinUpperCaseCharacters = 1;
        const int MinSpecialCharacters = 1;

        // Complete the minimumNumber function below.
        static int minimumNumber(int n, string password)
        {
            var wordGap = 0;

            if (password.Length < 6)
            {
                wordGap = 6 - password.Length;
            }

            // Return the minimum number of characters to make the password strong
            var result = password
                .GroupBy(letter => _characters.TryGetValue(letter, out LetterKind letterKind) ? letterKind : LetterKind.Unknown)
                .ToDictionary(letterGroup => letterGroup.Key, letterGroup => letterGroup.Count());
            
            var gap = 0;

            if (!result.TryGetValue (LetterKind.Number, out int numbers))
            {
                numbers = 0;
            }
            gap += (numbers < MinNumbers) ? (MinNumbers - numbers) : 0;

            if (!result.TryGetValue(LetterKind.LowerCase, out int lowerCaseLetters))
            {
                lowerCaseLetters = 0;
            }
            gap += (lowerCaseLetters < MinLowerCaseCharacters) ? (MinLowerCaseCharacters - lowerCaseLetters) : 0;

            if (!result.TryGetValue(LetterKind.UpperCase, out int upperCaseLetters))
            {
                upperCaseLetters = 0;
            }
            gap += (upperCaseLetters < MinUpperCaseCharacters) ? (MinUpperCaseCharacters - upperCaseLetters) : 0;

            if (!result.TryGetValue(LetterKind.SpecialCharacter, out int specialCharacters))
            {
                specialCharacters = 0;
            }
            gap += (specialCharacters < MinSpecialCharacters) ? (MinSpecialCharacters - specialCharacters) : 0;

            return Math.Max(wordGap, gap);
        }

        static void Main(string[] args)
        {
            var result0 = minimumNumber(3, ""); // 6
            var result1 = minimumNumber(3, "Ab1"); // 3
            var result2 = minimumNumber(11, "#HackerRank"); // 1
            var result3 = minimumNumber(4, "4700"); // 3


            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            //int n = Convert.ToInt32(Console.ReadLine());

            //string password = Console.ReadLine();

            //int answer = minimumNumber(n, password);

            //textWriter.WriteLine(answer);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
