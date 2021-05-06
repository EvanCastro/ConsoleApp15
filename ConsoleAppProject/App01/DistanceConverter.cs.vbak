using System;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App01
{
    /// <summary>
    /// DistanceConverter allows the user to convert from one distance to another
    /// The user is given three choices , Feet, metres and Miles
    /// The user chooses from the three options and this will be converted into
    /// the desired unit by from another three options similar to the first one.
    /// </summary>
    /// <author>
    /// Evan Castro 01/05/2021
    /// </author>

    public class DistanceConverter
    {
        public const int FEET_IN_MILES = 5280;

        public const double METRES_IN_MILES = 1609.34;

        public const double FEET_IN_METRES = 3.28084;

        public const string FEET = "Feet";
        public const string METRES = "Metres";
        public const string MILES = "Miles";

        public double FromDistance { get; set; }
        public double ToDistance { get; set; }

        public string FromUnit { get; set; }
        public string ToUnit { get; set; }

        /// <summary>
        /// This method will run the program, outputting a heading
        /// and closing the program if the user does not wish to
        /// chose to convert another distance
        /// </summary>
        public void Run()
        {
            bool repeat = true;
            while (repeat)
            {
                ConsoleHelper.OutputHeading(" Distance Converter");
                ConvertDistance();
                repeat = ConsoleHelper.WantToRepeat();
            }
        }

        /// <summary>
        /// This method outputs the heading and gives the user a choice
        /// of distance unit they would like to convert from and to.
        /// It lets the user know the distance is being converted, calculates
        /// the conversion and gives the user the result
        /// </summary>
        public void ConvertDistance()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n Selecting units");
            string[] choices = new string[]
            {
                FEET, METRES, MILES
            };

            Console.WriteLine($"\n Please select a unit to convert from\n");
            int choice = ConsoleHelper.SelectChoice(choices);
            FromUnit = choices[choice - 1];
            Console.WriteLine($"\n You have selected {FromUnit}! ");

            Console.WriteLine($"\n Please select a unit to convert to\n");
            choice = ConsoleHelper.SelectChoice(choices);
            ToUnit = choices[choice - 1];
            Console.WriteLine($"\n You have selected {ToUnit}! ");

            FromDistance = ConsoleHelper.InputNumberDouble($"\n Please enter the number of" +
                $" {FromUnit} you wish to convert to {ToUnit} > ");

            ConsoleHelper.OutputTitle($"\n Converting {FromUnit} to {ToUnit} ");
            CalculateDistance();

            OutputDistance();
        }

        /// <summary>
        /// This method does the actual calculations needed from the
        /// chosen input unit to the chosen output unit
        /// </summary>
        public void CalculateDistance()
        {
            if (FromUnit == MILES && ToUnit == FEET)
            {
                ToDistance = FromDistance * FEET_IN_MILES;
            }
            else if (FromUnit == FEET && ToUnit == MILES)
            {
                ToDistance = FromDistance / FEET_IN_MILES;
            }
            else if (FromUnit == MILES && ToUnit == METRES)
            {
                ToDistance = FromDistance * METRES_IN_MILES;
            }
            else if (FromUnit == METRES && ToUnit == MILES)
            {
                ToDistance = FromDistance / METRES_IN_MILES;
            }
            else if (FromUnit == METRES && ToUnit == FEET)
            {
                ToDistance = FromDistance * FEET_IN_METRES;
            }
            else if (FromUnit == FEET && ToUnit == METRES)
            {
                ToDistance = FromDistance / FEET_IN_METRES;
            }
        }

        /// <summary>
        /// This method displays the list of choices of measurement
        /// units the user can choose to convert from and to
        /// </summary>
        private static string DisplayChoices(string prompt)
        {
            Console.WriteLine("\n");
            Console.WriteLine($" 1. {FEET}");
            Console.WriteLine($" 2. {METRES}");
            Console.WriteLine($" 3. {MILES}");
            Console.WriteLine();

            Console.Write(prompt);
            string choice = Console.ReadLine();
            return choice;
        }

        /// <summary>
        /// This method takes the input unit, reads it and returns the
        /// conversion to an double-precision floating-point number
        /// </summary>
        private double InputDistance(string prompt)
        {
            Console.Write(prompt);
            string value = Console.ReadLine();
            return Convert.ToDouble(value);
        }

        /// <summary>
        /// This method lets the user know that from the unit
        /// and measurement they chose, it has been converted
        /// to the desired unit and measurement chosen
        /// </summary>
        private void OutputDistance()
        {
            Console.WriteLine($"\n {FromDistance} {FromUnit}" +
                $" is {ToDistance} {ToUnit}!");

        }

    }
}