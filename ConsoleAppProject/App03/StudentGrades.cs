using System;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App03
{
    /// <summary>
    /// This app allows the user to input each student's mark. 
    /// The app will calculate the mark and convert it into a grade accordingly.
    /// Evan Castro 12/05/2021
    /// </summary>

    public class StudentGrades
    {
        //Number of students to be evaluated
        public const int NoStudents = 10;
        //Grades Marking Values
        public const int LowestGradeF = 0;
        public const int LowestGradeD = 40;
        public const int LowestGradeC = 50;
        public const int LowestGradeB = 60;
        public const int LowestGradeA = 70;
        public const int HighestMark = 100;

        //Students, Marks Arrays
        public string[] Students { get; set; }
        public int[] GradeProfile { get; }
        public int[] Marks { get; set; }

        //Variables to Store the Minimum, Mean and Maximum Mark
        public double Mean { get; set; }

        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public int LowestMark { get; private set; }

        //Declares Students Names and the Lenght of the Marks Array
        /// <summary>
        /// This method stores the names of the students.
        /// It allows the user to run various methods
        /// such as inputmark, output mark grades, calculate stats and calculate grade profile.
        /// </summary>
        public StudentGrades()
        {
            Students = new string[NoStudents]
            {
                "Lilly","Iggy","Icia","Justin","Kaye","Russel","Chris","Roland","Earl","Eunice"
            };
            GradeProfile = new int[(int)Grades.A + 1];
            Marks = new int[Students.Length];

            InputMarks();
            OutputMarks();
            CalculateStats();
            CalculateGradeProfile();

        }
        /// <summary>
        /// This method will run the program.
        /// it will output the heading
        /// allows the user to make a choice whether they want to continue or not. 
        /// </summary>
        public void Run()
        {
            
            bool repeat = true;
            while (repeat)
            {
                ConsoleHelper.OutputHeading("Student Grades");
                repeat = ConsoleHelper.WantToRepeat();
            }
        }


        //Insert Student Marks
        /// <summary>
        /// Allows the user to input the student's mark.
        /// Marks can only hold the value between min and max.
        /// </summary>
        public void InputMarks()
        {
            int mark, index = 0;

            Console.WriteLine();

            foreach (string student in Students)
            {
                Console.Write("Please enter a mark for {0} ", student);
                mark = Convert.ToInt32(Console.ReadLine());
                Marks[index] = mark;
                index++;
            }

            Console.WriteLine();
        }

        //Display Marks and Grades
        /// <summary>
        /// This method displays the names of all students
        /// also displays their mark as well as their class using enumeration.
        /// </summary>
        public void OutputMarks()
        {
            {
                ConsoleHelper.OutputTitle(" Student Marks");

                for (int index = 0; index < Students.Length; index++)
                {
                    Grades grade = ConvertToGrade(Marks[index]);
                    string name = EnumHelper<Grades>.GetName(grade);

                    Console.WriteLine($" {Students[index]} {Marks[index]}% - Grade {grade} | {name}");
                }
            }
        }

        /// <summary>
        /// This method allows the convertion of student marks to grade
        /// It ranges from F(fail) to A(first class)
        /// </summary>
        public Grades ConvertToGrade(int mark)
        {
            if (mark >= LowestMark && mark < LowestGradeD)
            {
                return Grades.F;
            }
            else if (mark >= LowestGradeD && mark < LowestGradeC)
            {
                return Grades.D;
            }
            else if (mark >= LowestGradeC && mark < LowestGradeB)
            {
                return Grades.C;
            }
            else if (mark >= LowestGradeB && mark < LowestGradeA)
            {
                return Grades.B;
            }
            else if (mark >= LowestGradeA && mark <= HighestMark)
            {
                return Grades.A;
            }
            else
            {
                return Grades.None;
            }
        }

        /// <summary>
        /// This method sums the minimum and maximum and mean mark for all the students
        /// Also outputs the mean mark for all the students
        /// </summary>
        public void CalculateStats()
        {
            double total = 0;

            Minimum = HighestMark;
            Maximum = 0;

            foreach (int mark in Marks)
            {
                total = total + mark;
                if (mark > Maximum) Maximum = mark;
                if (mark < Minimum) Minimum = mark;
            }
            Mean = total / Marks.Length;
            OutputStats();
        }

        /// <summary>
        /// This method outputs the minimum, maximum and mean of the entirety of the students.
        /// 
        /// </summary>
        private void OutputStats()
        {
            ConsoleHelper.OutputTitle(" Student Marks Statistics");
            Console.WriteLine($" No. of students marked = {Marks.Length}");
            Console.WriteLine($" Minimum mark = {Minimum}");
            Console.WriteLine($" Mean mark = {Mean}");
            Console.WriteLine($" Maximum mark = {Maximum}");
        }

        public void CalculateGradeProfile()
        {
            for (int i = 0; i < GradeProfile.Length; i++)
            {
                GradeProfile[i] = 0;
            }

            foreach (int mark in Marks)
            {
                Grades grade = ConvertToGrade(mark);
                GradeProfile[(int)grade]++;
            }

            OutputGradeProfile();
        }

        /// <summary>
        /// This will display percentage of students obtaining each grade
        /// </summary>
        private void OutputGradeProfile()
        {
            Grades grade = Grades.None;
            ConsoleHelper.OutputYellow("\n Number of students that achieved " +
                             "the following grades");

            foreach (int count in GradeProfile)
            {
                int percentage = count * 100 / Marks.Length;
                Console.WriteLine($" \n Grade {grade} - {percentage}% | Count {count}");
                grade++;
            }

            Console.WriteLine();
        }
    }
}
