using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestSubarrayWithSum
{
    class TestData
    {
        public static int[] Data1()
        {
            return ReadFromCSVFile("TestData1.txt");
        }

        public static int[] Data2()
        {
            return ReadFromCSVFile("TestData2.txt");
        }

        private static int[] ReadFromCSVFile(String fileName)
        {
            using (var reader = new StreamReader(File.OpenRead(fileName)))
            {
                var text = reader.ReadLine();

                return text.Split(',')
                    .Select(textValue => Int32.Parse(textValue))
                    .ToArray();
            }
        }
    }
}
