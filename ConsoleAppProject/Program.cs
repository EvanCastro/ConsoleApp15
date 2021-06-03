using ConsoleAppProject.App01;
using ConsoleAppProject.App02;
using ConsoleAppProject.App03;
using ConsoleAppProject.App04;
using ConsoleAppProject.Helpers;
using System;

namespace ConsoleAppProject
{
    /// <summary>
    /// The main method in this class is called first
    /// when the application is started.  It will be used
    /// to start Apps 01 to 05 for CO453 CW1
    /// 
    /// This Project has been modified by:
    /// Evan Castro 01/05/2021
    /// </summary>
    public static class Program
    {
        private static int choice;
        public static void Main(string[] args)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("BNU CO453 Applications Programming Jan start");
            Console.WriteLine("Evan Castro");
            Console.WriteLine();

            string[] choices = new string[]
            {
                "Distance Coverter",
                "BMI Calculator",
                "Student Grades",
                "Social Network"
            };

            ConsoleHelper.OutputTitle("Please select the application you wish to use ");
            choice = ConsoleHelper.SelectChoice(choices);

            if (choice == 1)
            {
                DistanceConverter converter = new DistanceConverter();
                converter.Run();
            }
            else if (choice == 2)
            {
                BMICalculator calculator = new BMICalculator();
                calculator.Run();
            }
            else if(choice == 3)
            {
                StudentGrades grades = new StudentGrades();
                grades.Run();
            }
            else if (choice == 4)
            {
                NetworkApp App04 = new NetworkApp();
                App04.DisplayMenu();
            }

        }
    }
}