using System.Collections.Generic;
using System.IO;

namespace GradeCalculator
{
    internal class Program
    {
        // Declare variables as class-level fields
         static int totalMarks = 0;
         static double averageMarks = 0.0;
         static string grade = "";

        static void Main(string[] args)
        {
            List<int> marks = new List<int>();
            InputMarks(marks);
            CalculateResults(marks); 
        }

        static void InputMarks(List<int> studentMarks)
        {
            Console.Write("Enter the number of subjects: ");
            int numSubjects = int.Parse(Console.ReadLine());

            for (int i = 0; i < numSubjects; i++)
            {
                Console.Write("Enter marks for subject" + (i + 1) + "(0-100): ");
                int mark = int.Parse(Console.ReadLine());

                if (mark >= 0 && mark <= 100)
                {
                    studentMarks.Add(mark);
                }
                else
                {
                    Console.WriteLine("Invalid mark. Please enter between 0 and 100.");
                    i--;
                }
            }
        }

        static void CalculateResults(List<int> studentMarks)
        {
            foreach (int mark in studentMarks)
            {
                totalMarks += mark;
            }

            averageMarks = (double)totalMarks / studentMarks.Count;

            if (averageMarks >= 90)
                grade = "A";
            else if (averageMarks >= 80)
                grade = "B";
            else if (averageMarks >= 70)
                grade = "C";
            else if (averageMarks >= 60)
                grade = "D";
            else
                grade = "F";

            // Display results
            Console.WriteLine("Total Marks: " + totalMarks);
            Console.WriteLine("Average Marks: " + averageMarks);
            Console.WriteLine("Grade: " + grade);

        }
    }
}


