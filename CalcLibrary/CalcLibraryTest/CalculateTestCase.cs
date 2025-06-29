using NUnit.Framework;
using CalcLibrary;
namespace CalcLibraryTest
{
    public class CalculateTestCase
    {
        private SimpleCalculator calculator;
        [SetUp]
        public void Setup()
        {
            calculator = new SimpleCalculator();
        }
        [TearDown]
        public void TearDown()
        {
            calculator = null;
        }

        [Test]
        [TestCase(2,3,5)]
        [TestCase(4,5,9)]
        [TestCase(1,1,2)]
        public void Addition_Result(double a,double b, double expected)
        {
            var result = calculator.Addition(a,b);
            Assert.That(result,Is.EqualTo(expected));
        }
        [Test]
        [TestCase(3, 2, 1)]
        [TestCase(5, 5, 0)]
        [TestCase(8, 8, 0)]
        public void Subtraction_Resut(double a, double b, double expected)
        {
            var result = calculator.Subtraction(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        [TestCase(3, 3, 9)]
        [TestCase(5, 5, 25)]
        [TestCase(1, 1, 0)]
        public void Multiplication_Result(double a, double b, double expected)
        {
            var result = calculator.Multiplication(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        [TestCase(6,3,2)]
        [TestCase(9,3,3)]
        [TestCase(10,0,3)]
        public void Division_Result(double a, double b, double expected)
        {
            var result = calculator.Division(a, b);
            Assert.That (result, Is.EqualTo(expected));
        }

    }
}