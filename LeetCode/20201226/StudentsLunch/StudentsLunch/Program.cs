using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsLunch
{
    class Program
    {
        public class Solution
        {
            public int CountStudents(int[] students, int[] sandwiches)
            {
                Queue<int> studentQueue = new Queue<int>(students);
                Queue<int> unsatisfiedQueue = new Queue<int>();

                for (int i = 0; i < sandwiches.Length; i++)
                {
                    var currentSandwich = sandwiches[i];

                    while(studentQueue.Any())
                    {
                        var currentStudent = studentQueue.Dequeue();

                        if (currentStudent == currentSandwich)
                        {
                            studentQueue = new Queue<int>(studentQueue.Concat(unsatisfiedQueue));
                            unsatisfiedQueue = new Queue<int>();
                            break;
                        }

                        unsatisfiedQueue.Enqueue(currentStudent);
                    }
                }

                return unsatisfiedQueue.Count;
            }
        }


        static void Main(string[] args)
        {
            var solution = new Solution();

            var students1 = new int[] { 1, 1, 0, 0 };
            var sandwiches1 = new int[] { 0, 1, 0, 1 };

            var count1 = solution.CountStudents(students1, sandwiches1);

            var students2 = new int[] { 1, 1, 1, 0, 0, 1 };
            var sandwiches2 = new int[] { 1, 0, 0, 0, 1, 1 };

            var count2 = solution.CountStudents(students2, sandwiches2);

            var students3 = new int[] { 1, 1, 0, 0 };
            var sandwiches3 = new int[] { 0, 1, 0, 1 };

            var count3 = solution.CountStudents(students3, sandwiches3);
        }
    }
}
