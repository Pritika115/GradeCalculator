using System.Collections.Generic;
using System.IO;

namespace GradeCalculator
{
    internal class Program
    {
        // Class-level variables to hold final results
        static int totalMarks = 0;
        static double averageMarks = 0.0;
        static string grade = "";

        static void Main(string[] args)
        {
            // List to store individual subject marks
            List<int> marks = new List<int>();

            // Prompt user to choose input method
            Console.WriteLine("Choose input method:");
            Console.WriteLine("1. Manual Entry");
            Console.WriteLine("2. Read from File (marks.txt)");
            Console.Write("Enter choice (1 or 2): ");
            string choice = Console.ReadLine();

            // Handle user input for input method
            if (choice == "1")
            {
                InputMarks(marks); // Manual entry
            }
            else if (choice == "2")
            {
                ReadMarksFromFile(marks); // Read from file
            }
            else
            {
                Console.WriteLine("Invalid choice. Exiting program.");
                return;
            }

            CalculateResults(marks);     // Process marks
            SaveResultsToFile();         // Save to result.txt
        }
        /*
         * Method: InputMarks
         * Purpose: Accepts subject marks manually from the user.
         * Validates each input to ensure it's between 0 and 100.
         */

        static void InputMarks(List<int> studentMarks)
        {
            Console.Write("Enter the number of subjects: ");
            int numSubjects = int.Parse(Console.ReadLine()); // Read number of subjects

            for (int i = 0; i < numSubjects; i++)
            {
                Console.Write("Enter marks for subject " + (i + 1) + " (0-100): ");
                int mark = int.Parse(Console.ReadLine()); // Read individual mark

                if (mark >= 0 && mark <= 100)
                {
                    studentMarks.Add(mark); // Add to list
                }
                else
                {
                    Console.WriteLine("Invalid mark. Please enter between 0 and 100.");
                    i--; // Repeat the same index
                }
            }
        }


        /*
         * Method: ReadMarksFromFile
         * Purpose: Reads subject marks line-by-line from a predefined file path.
         * Only valid marks between 0 and 100 are added to the list.
         */
        static void ReadMarksFromFile(List<int> studentMarks)
        {
            try
            {
                // Adjust file path as needed
                StreamReader reader = new StreamReader("C:\\Users\\Armaan\\source\\repos\\cafe\\GradeCalculator\\GradeCalculator\\bin\\Debug\\net8.0\\marks.txt");

                string line = reader.ReadLine(); // Read first line

                while (line != null)
                {
                    int mark = int.Parse(line); // Convert line to int

                    if (mark >= 0 && mark <= 100)
                    {
                        studentMarks.Add(mark); // Add valid mark
                    }
                    else
                    {
                        Console.WriteLine("Invalid mark found in file: " + mark);
                    }

                    line = reader.ReadLine(); // Read next line
                }

                reader.Close(); // Close file

                Console.WriteLine("Marks successfully read from marks.txt.");
            }
            catch (Exception e)
            {
                // Handle file errors
                Console.WriteLine("Error reading file: " + e.Message);
                Environment.Exit(0);
            }
        }
        /*
        * Method: CalculateResults
        * Purpose: Calculates the total, average, and grade from the list of marks.
        * Displays the result to the user.
        */

        static void CalculateResults(List<int> studentMarks)
        {
            foreach (int mark in studentMarks)
            {
                totalMarks += mark; // Add each mark to total
            }

            averageMarks = (double)totalMarks / studentMarks.Count; // Calculate average

            // Determine grade
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

            // Output results
            Console.WriteLine("Total Marks: " + totalMarks);
            Console.WriteLine("Average Marks: " + averageMarks);
            Console.WriteLine("Grade: " + grade);
        }

        /*
          * Method: SaveResultsToFile
          * Purpose: Saves the final results to a text file.
          */
        static void SaveResultsToFile()
        {
            try
            {
                // Output file will be saved in the parent directory
                StreamWriter writer = new StreamWriter("..\\..\\..\\..result.txt");

                writer.WriteLine("Total Marks: " + totalMarks);
                writer.WriteLine("Average Marks: " + averageMarks);
                writer.WriteLine("Grade: " + grade);
                writer.Close();

                Console.WriteLine("Results saved to result.txt.");
            }
            catch (Exception e)
            {
                // Handle file writing errors
                Console.WriteLine("Error saving results: " + e.Message);
            }
        }
    }
}
