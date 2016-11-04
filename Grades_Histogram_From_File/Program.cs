using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradesHistogram
{
    class Program
    {

        static bool keepGoing()
        {
            /* Name: keepGoing
            * Description:  This method implements a loop to determine if users wants to continue
            * Input:  None
            * Output: Returns false if user doesn't want to continue.  Otherwise returns true.
            *         Outputs values to Console
            */


            // If user enters "q", execute exit procedure
            Console.WriteLine("\nContinue? (y/n):");
            string input = Console.ReadLine();

            if (input == "n")
            {
                Console.WriteLine("You entered n\n");
                Console.WriteLine("Are you sure you want to exit? (Type y to confirm)");
                input = Console.ReadLine();

                if (input == "y")
                {
                    return false;
                }

            }

            return true;
        }

        static int[] getGrades()
        {
            int[] gradeRangeCounter = new int[10];
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\tnagl\OneDrive\Documents\Visual Studio 2015\Projects\GradesHistogram\grades.txt");
            int grade = 0;


            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                if (int.TryParse(line, out grade))
                {
                    Console.WriteLine(grade);
                    if ((grade <= 100) && (grade >= 0))
                    {
                        int range = getRange(grade);
                        gradeRangeCounter[range] = gradeRangeCounter[range] + 1;
                    }
                    else
                    {
                        Console.WriteLine("Grade is not between 1 and 100");
                    }
                }
                else
                {

                }


            }


            return gradeRangeCounter;

        }

        static int getRange(int grade)
        {
            int range = grade / 10;
            if (grade == 100)
            {
                range--;
            }
            return range;
        }

        static void printHorizontalAsterisk(int[] counter)
        {
            string[] gradeRangeOutput = { " 0  -   9: ", "10  -  19: ", "20  -  29: ", "30  -  39: ", "40  -  49: ", "50  -  59: ", "60  -  69: ", "70  -  79: ", "80  -  89: ", "90  - 100: " };
            string[] gradeRangeAsterisks = new string[10];

            // Create horizontal asterisk bars. One asterisk per score.
            for (int i = 0; i < counter.Length; i++)
            {
                for (int j = 0; j < counter[i]; j++)
                { gradeRangeAsterisks[i] = gradeRangeAsterisks[i] + "*"; }
            }

            // Print asterisks with ranges
            for (int i = 0; i < gradeRangeOutput.Length; i++)
            {
                Console.WriteLine(gradeRangeOutput[i] + gradeRangeAsterisks[i]);
            }

        }

        static void printVerticalAsterisk(int[] counter)
        {
            string gradeRangeOutput = "\n 0-9  10-19  20-29  30-39  40-49  50-59  60-69  70-79  80-89  90-100";
            string[] gradeRangeAsterisks = new string[10];



            for (int i = counter.Max(); i > 0; i--)
            {
                Console.WriteLine("");
                for (int j = 0; j < counter.Length; j++)
                {

                    if ((counter[j] > 0) && (counter[j] >= i))
                    {

                        Console.Write("  *".PadRight(7));
                        counter[j] = counter[j] - 1;
                    }
                    else
                    {
                        Console.Write("   ".PadRight(7));
                    }
                }
            }

            // Print horizontal ranges
            Console.WriteLine(gradeRangeOutput);
        }





        static void Main(string[] args)
        {

            do
            {






                Console.WriteLine("Grade Historgram program.");
                Console.WriteLine("Please enter all your grades, (enter -1 to quit)");
                int[] gradeRangeCounter = getGrades();
                printHorizontalAsterisk(gradeRangeCounter);
                printVerticalAsterisk(gradeRangeCounter);





            } while (keepGoing());

        }


    }

}
