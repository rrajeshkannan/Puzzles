using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningTimeAndComplexityPrimeNumber
{
    class Program
    {
        static bool IsPrime(uint number)
        {
            if (number == 1)
            {
                return false;
            }

            if (number == 2)
            {
                return true;
            }

            if (number % 2 == 0)
            {
                return false;
            }

            // Find out square root for "number"
            // Traverse all odd numbers up to the sqrt(number)
            // Check if number is divisible by current odd number --> if remainder is 0 for any odd number then number is NOT PRIME
            uint terminalValue = (uint)Math.Sqrt(number);
            for (uint i = 3; i <= terminalValue; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        static void Main(string[] args)
        {
            var count = Convert.ToInt32(Console.ReadLine());

            var numbers = new uint[count];

            for (int i = 0; i < count; i++)
            {
                numbers[i] = Convert.ToUInt32(Console.ReadLine());
            }

            for (int i = 0; i < count; i++)
            {
                if (IsPrime(numbers[i]))
                {
                    Console.WriteLine("Prime");
                }
                else
                {
                    Console.WriteLine("Not prime");
                }
            }
        }
    }
}
