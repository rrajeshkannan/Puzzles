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
using System.Runtime.InteropServices;

// https://www.hackerrank.com/challenges/30-bitwise-and/problem?isFullScreen=true

class Solution
{
    class Query
    {
        public uint N { get; set; }

        public uint K { get; set; }
    }


    static void Main(string[] args)
    {
        //var queriesCount = Convert.ToUInt32(Console.ReadLine());
        //var queries = new Query[queriesCount];

        //for (uint i = 0; i < queriesCount; i++)
        //{
        //    string[] input = Console.ReadLine().Split(' ');

        //    queries[i] = new Query { N = Convert.ToUInt32(input[0]), K = Convert.ToUInt32(input[1]) };
        //}

        var queries = new Query[] {
            new Query { N = 5, K = 2 },
            new Query { N = 8, K = 5 },
            new Query { N = 2, K = 2 },
        };
        var queriesCount = queries.Length;


        for (uint i = 0; i < queriesCount; i++)
        {
            var n = queries[i].N;
            var k = queries[i].K;
            var max = uint.MinValue;

            for (uint j = 1; j <= n - 1; j++)
            {
                for (uint l = j + 1; l <= n; l++)
                {
                    var result = j & l;

                    if (result < k)
                    {
                        if (result > max)
                        {
                            max = result;
                        }
                    }
                }
            }

            Console.WriteLine(max);
        }
    }
}
