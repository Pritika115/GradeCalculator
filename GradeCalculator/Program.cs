
using System.Collections.Generic;
using System.IO;

namespace GradeCalculator
{
    internal class Program
    {

        public void main(String[] args)
        {
            List<int> marks = new List<int>();
            int totalMarks = 0;
            double averageMarks = 0.0;
            string grade = "";

            InputMarks(marks);
        }
        


        static void InputMarks(List<int> studentMarks)
        {
            Console.Write("Enter the number of subjects: ");
            int numSubjects = int.Parse(Console.ReadLine());

            for (int i = 0; i <= numSubjects; i++)
            {
                Console.Write("Enter marks for subject" + i + "(0-100): ");
                int mark = int.Parse(Console.ReadLine());


                if (mark >= 0 && mark <= 100)
                {
                    studentMarks.Add(mark);
                }
                else
                {
                    Console.WriteLine("Invalid mark. Please enter between 0 and 100.");

                }
            }
        }
        

    }
}
