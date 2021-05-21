using ConsoleAppProject.App01;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApp.tests
{
    [TestClass]
    public class TestDistanceConverter
    {
        [TestMethod]
        public void TestMilesToFeet()
        {
            // Arrange
            DistanceConverter converter = new DistanceConverter();

            converter.FromUnit = DistanceConverter.MILES;
            converter.ToUnit = DistanceConverter.FEET;

            converter.FromDistance = 1.0;

            //Act
            converter.CalculateDistance();

            double expectedDistance = 5280;

            // Assert
            Assert.AreEqual(expectedDistance, converter.ToDistance);
        }
        [TestMethod]
        public void TestFeetToMiles()
        {
            // Arrange
            DistanceConverter converter = new DistanceConverter();

            converter.FromUnit = DistanceConverter.FEET;
            converter.ToUnit = DistanceConverter.MILES;

            converter.FromDistance = 5280;

            //Act
            converter.CalculateDistance();

            double expectedDistance = 1.0;

            // Assert
            Assert.AreEqual(expectedDistance, converter.ToDistance);
        }
        [TestMethod]
        public void TestMilesToMetres()
        {
            // Arrange
            DistanceConverter converter = new DistanceConverter();

            converter.FromUnit = DistanceConverter.MILES;
            converter.ToUnit = DistanceConverter.METRES;

            converter.FromDistance = 1.0;

            //Act
            converter.CalculateDistance();

            double expectedDistance = 1609.34;

            // Assert
            Assert.AreEqual(expectedDistance, converter.ToDistance);
        }
        [TestMethod]
        public void TestMetresToMiles()
        {
            // Arrange
            DistanceConverter converter = new DistanceConverter();

            converter.FromUnit = DistanceConverter.METRES;
            converter.ToUnit = DistanceConverter.MILES;

            converter.FromDistance = 1609.34;

            //Act
            converter.CalculateDistance();

            double expectedDistance = 1.0;

            // Assert
            Assert.AreEqual(expectedDistance, converter.ToDistance);
        }
        [TestMethod]
        public void TestMetresToFeet()
        {
            // Arrange
            DistanceConverter converter = new DistanceConverter();

            converter.FromUnit = DistanceConverter.METRES;
            converter.ToUnit = DistanceConverter.FEET;

            converter.FromDistance = 1.0;

            //Act
            converter.CalculateDistance();

            double expectedDistance = 3.28084;

            // Assert
            Assert.AreEqual(expectedDistance, converter.ToDistance);
        }
        [TestMethod]
        public void TestFeetToMetres()
        {
            // Arrange
            DistanceConverter converter = new DistanceConverter();

            converter.FromUnit = DistanceConverter.FEET;
            converter.ToUnit = DistanceConverter.METRES;

            converter.FromDistance = 3.28084;

            //Act
            converter.CalculateDistance();

            double expectedDistance = 1.0;

            // Assert
            Assert.AreEqual(expectedDistance, converter.ToDistance);
        }
    }
}