using ConsoleAppProject.App03;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApp.tests
{

    [TestClass]
    public class TestStudentGrades
    {
        private readonly StudentGrades
            converter = new StudentGrades();

        private readonly int[] StatsMarks = new int[]
        {
            10, 20, 30, 40, 50, 60, 70, 80, 90, 100
        };

        [TestMethod]
        public void TestConvert0ToGradeF()
        {
            // Arrange
            Grades expectedGrade = Grades.F;

            //Act
            Grades actualGrade = converter.ConvertToGrade(0);

            // Assert
            Assert.AreEqual(expectedGrade, actualGrade);
        }

        [TestMethod]
        public void TestConvert39ToGradeF()
        {
            // Arrange
            Grades expectedGrade = Grades.F;

            //Act
            Grades actualGrade = converter.ConvertToGrade(39);

            // Assert
            Assert.AreEqual(expectedGrade, actualGrade);
        }

        [TestMethod]
        public void TestConvert40ToGradeD()
        {
            // Arrange
            Grades expectedGrade = Grades.D;

            //Act
            Grades actualGrade = converter.ConvertToGrade(40);

            // Assert
            Assert.AreEqual(expectedGrade, actualGrade);
        }

        [TestMethod]
        public void TestConvert49ToGradeD()
        {
            // Arrange
            Grades expectedGrade = Grades.D;

            //Act
            Grades actualGrade = converter.ConvertToGrade(49);

            // Assert
            Assert.AreEqual(expectedGrade, actualGrade);
        }

        [TestMethod]
        public void TestConvert50ToGradeC()
        {
            // Arrange
            Grades expectedGrade = Grades.C;

            //Act
            Grades actualGrade = converter.ConvertToGrade(50);

            // Assert
            Assert.AreEqual(expectedGrade, actualGrade);
        }

        [TestMethod]
        public void TestConvert59ToGradeC()
        {
            // Arrange
            Grades expectedGrade = Grades.C;

            //Act
            Grades actualGrade = converter.ConvertToGrade(59);

            // Assert
            Assert.AreEqual(expectedGrade, actualGrade);
        }

        [TestMethod]
        public void TestConvert60ToGradeB()
        {
            // Arrange
            Grades expectedGrade = Grades.B;

            //Act
            Grades actualGrade = converter.ConvertToGrade(60);

            // Assert
            Assert.AreEqual(expectedGrade, actualGrade);
        }

        [TestMethod]
        public void TestConvert69ToGradeB()
        {
            // Arrange
            Grades expectedGrade = Grades.B;

            //Act
            Grades actualGrade = converter.ConvertToGrade(69);

            // Assert
            Assert.AreEqual(expectedGrade, actualGrade);
        }

        [TestMethod]
        public void TestConvert70ToGradeA()
        {
            // Arrange
            Grades expectedGrade = Grades.A;

            //Act
            Grades actualGrade = converter.ConvertToGrade(70);

            // Assert
            Assert.AreEqual(expectedGrade, actualGrade);
        }

        [TestMethod]
        public void TestConvert99ToGradeA()
        {
            // Arrange
            Grades expectedGrade = Grades.A;

            //Act
            Grades actualGrade = converter.ConvertToGrade(99);

            // Assert
            Assert.AreEqual(expectedGrade, actualGrade);
        }

        [TestMethod]
        public void TestCalculateMean()
        {
            converter.Marks = StatsMarks;
            double expectedMean = 55.0;
            converter.CalculateStats();

            Assert.AreEqual(expectedMean, converter.Mean);
        }

        [TestMethod]
        public void TestCalculateMin()
        {
            // Arrange
            converter.Marks = StatsMarks;
            int expectedMin = 10;

            // Act
            converter.CalculateStats();

            // Assert
            Assert.AreEqual(expectedMin, converter.Minimum);
        }

        [TestMethod]
        public void TestGradeProfile()
        {
            // Arrange
            converter.Marks = StatsMarks;

            // Act
            converter.CalculateGradeProfile();

            bool expectedProfile;
            expectedProfile = ((converter.GradeProfile[0] == 3) &&
                               (converter.GradeProfile[1] == 1) &&
                               (converter.GradeProfile[2] == 1) &&
                               (converter.GradeProfile[3] == 1) &&
                               (converter.GradeProfile[4] == 4));
            // Assert
            Assert.IsTrue(expectedProfile);

        }
    }
}
