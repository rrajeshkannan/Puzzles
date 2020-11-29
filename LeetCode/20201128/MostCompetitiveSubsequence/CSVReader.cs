using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostCompetitiveSubsequence
{
    public static class CSVReader
    {
        public static int[] GetValues(string csvFilePath)
        {
            var list = new List<String>();

            using (var reader = new StreamReader(csvFilePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    list.AddRange(values);
                }
            }

            return list.Select(text => Int32.Parse(text)).ToArray();
        }
    }
}
