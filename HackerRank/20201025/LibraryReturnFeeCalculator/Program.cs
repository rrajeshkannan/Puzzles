using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReturnFeeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            const int finePerDay = 15;
            const int finePerMonth = 500;
            const int fineForYearsDelay = 10000;

            //var actualDateParts = Console.ReadLine().Split(' ');
            //var expectedDateParts = Console.ReadLine().Split(' ');

            //var actualDay = Convert.ToInt32(actualDateParts[0]);
            //var actualMonth = Convert.ToInt32(actualDateParts[1]);
            //var actualYear = Convert.ToInt32(actualDateParts[2]);

            //var expectedDay = Convert.ToInt32(expectedDateParts[0]);
            //var expectedMonth = Convert.ToInt32(expectedDateParts[1]);
            //var expectedYear = Convert.ToInt32(expectedDateParts[2]);

            var actualDay = 31;
            var actualMonth = 12;
            var actualYear = 2009;

            var dueDay = 1;
            var dueMonth = 1;
            var dueYear = 2010;

            int fine = 0;
            var yearsDelayed = actualYear - dueYear;

            if (yearsDelayed > 0)
            {
                fine = fineForYearsDelay;
            }
            else if (yearsDelayed == 0)
            {
                var monthsDelayed = actualMonth - dueMonth;

                if (monthsDelayed > 0)
                {
                    fine = finePerMonth * monthsDelayed;
                }
                else if (monthsDelayed == 0)
                {
                    var daysDelayed = actualDay - dueDay;

                    if (daysDelayed > 0)
                    {
                        fine = finePerDay * daysDelayed;
                    }
                }
            }

            Console.WriteLine(fine);
        }
    }
}
