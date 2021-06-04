using System;

namespace ConsoleAppProject.Helpers
{

    /// <summary>
    /// This is a general purpose class containing methods
    /// that can be used by other console based classes.
    /// Methods to input numbers from the user, and ask the
    /// user to select a choice from a list of choices.
    /// There are methods for outputting a main heading
    /// and a title.
    /// <author>
    /// Evan Castro 01/05/2021
    /// </author>
    /// </summary>
    public static class ConsoleHelper
    {

        /// <summary>
        /// This method displays a list of numbered choices to the
        /// user, they can then select a choice and and the choice 
        /// number is returned.  Choices start at 1.
        /// </summary>
        public static int SelectChoice(string[] choices)
        {
            int choiceNo = 0;

            //Display all the choices

            foreach (string choice in choices)
            {
                choiceNo++;
                Console.WriteLine($"|{choiceNo}. {choice}");
            }

            choiceNo = InputNumberWithin(choiceNo - choiceNo + 1, choices.Length);


            return choiceNo;
        }


        /// <summary>
        /// Aks for an Int number and ensures that only a number can be returned
        /// </summary>
        /// <returns>double</returns>
        public static int InputInt()
        {
            int number = 0;
            bool Isvalid = false;

            do
            {
                Console.Write(">");
                string value = Console.ReadLine();

                try
                {
                    number = Convert.ToInt32(value);
                    Isvalid = true;
                }
                catch (Exception)
                {
                    Isvalid = false;
                    Console.WriteLine("Number is INVALID!!");
                }
            }
            while (!Isvalid);
            return number;
        }


        /// <summary>
        /// This displays all the available choices in a numbered
        /// list, starting at 1
        /// </summary>
        private static void DisplayChoices(string[] choices)
        {
            int choiceNo = 0;

            foreach (string choice in choices)
            {
                choiceNo++;
                Console.WriteLine($"    {choiceNo}.  {choice}");
            }
        }


        /// <summary>
        /// This method will display a prompt to the user and
        /// will return any number as a double.  Any exception
        /// will generate an error message.
        /// </summary>
        public static double InputNumberDouble(string prompt)
        {
            double number = 0;
            bool isValid;

            do
            {
                Console.Write(prompt);
                string value = Console.ReadLine();

                try
                {
                    number = Convert.ToDouble(value);
                    isValid = true;
                }
                catch (Exception)
                {
                    isValid = false;
                    Console.WriteLine("Error!");
                }

            } while (!isValid);

            return number;
        }


        /// <summary>
        /// This method will prompt the user to enter a number
        /// between the min and max values includice.
        /// 
        /// Error messages will be displayed for an invalid number
        /// or a number outside the min or max values.
        /// The number returned can be cast as an (int/decimal)
        /// </summary>
        public static double InputNumber(string prompt, double min, double max)
        {
            bool isValid;
            double number;

            do
            {
                number = InputNumberDouble(prompt);

                if (number < min || number > max)
                {
                    isValid = false;
                    Console.WriteLine($" Number must be between {min} and {max}");
                }
                else isValid = true;

            } while (!isValid);

            return number;

        }

        /// <summary>
        /// Aks for a double number and ensures that only a number can be returned
        /// </summary>
        /// <returns>double</returns>
        public static double InputNumber()
        {
            double number = 0;
            bool Isvalid = false;

            do
            {
                Console.Write(">");
                string value = Console.ReadLine();

                try
                {
                    number = Convert.ToDouble(value);
                    Isvalid = true;
                }
                catch (Exception)
                {
                    Isvalid = false;
                    Console.WriteLine("Number is INVALID!!");
                }
            }
            while (!Isvalid);
            return number;
        }

        /// <summary>
        /// Output a short heading in green for the application
        /// and the name of the author and a prompt to
        /// inform the use which units are being converted
        /// Please change the authors name.
        /// </summary>
        public static void OutputHeading(string heading)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(" \n  -------------------------------------------");
            Console.WriteLine($" {heading} | BY EVAN CASTRO");
            Console.WriteLine("  -------------------------------------------");
            Console.WriteLine("");

            Console.ForegroundColor = ConsoleColor.Yellow;
        }


        public static void OutputYellow(string line)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($" {line}");
        }

        public static void OutputRed(string line)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($" {line}");
        }

        public static string InputString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        /// <summary>
        /// Returns and Ensures that only a number within a range can be returned
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns>double</returns>
        public static int InputNumberWithin(int from, int to)
        {
            int number;
            bool Isvalid;

            do
            {
                double value = InputNumber();

                number = Convert.ToInt32(value);
                Isvalid = true;

                if (number < from || number > to)
                {
                    Console.WriteLine($"Number must be between {from} and {to} !");
                    Isvalid = false;
                }
            }
            while (!Isvalid);

            return number;
        }
    



        /// <summary>
        /// This method will display a green title underlined
        /// by dashes.
        /// </summary>
        public static void OutputTitle(string title)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine($"\n {title}");
                Console.Write(" ");

                for (int count = 0; count <= title.Length; count++)
                {
                    Console.Write("-");
                }

                Console.WriteLine("\n");
                Console.ResetColor();
            }
        

            /// <summary>
            /// This method will give the user the option to carry
            /// out another calculation by saying yes or no
            /// </summary>
            public static bool WantToRepeat()
            {
                bool repeat = true;
                while (repeat)
                {
                    Console.WriteLine("\n Would you like to choose"
                        + " another calculation? yes/no? > ");
                    string choice = Console.ReadLine();

                    if (choice.ToLower().Contains("y"))
                    {
                        Console.WriteLine(" You have selected yes");
                        repeat = false;
                        return true;
                    }

                    else if (choice.ToLower().Contains("n"))
                    {
                        Console.WriteLine(" You entered no, exiting the app, thank you!");
                        repeat = false;
                        return false;
                    }

                    else
                    {
                        Console.WriteLine(" Error: invalid input. Please try again");
                    }
                }
                return false;

            }
        }
    }
