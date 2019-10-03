using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeCalculator.Tests
{
    [TestClass]
    public class RequirementsTests
    {
        [TestMethod]
        public void Requirement1()
        {
            Calculator calc = new Calculator();
            var result = calc.ProcessInput("20");
            Assert.AreEqual(20, result);

            var result2 = calc.ProcessInput("1,5000");
            Assert.AreEqual(5001, result2);

            var result3 = calc.ProcessInput("");
            Assert.AreEqual(0, result3);

            var result4 = calc.ProcessInput("5,tytyt");
            Assert.AreEqual(5, result4);

            //Max 2 number limit
            var result5 = calc.ProcessInput("5,2,3");
            Assert.AreEqual(7, result5);

            //Negative numbers
            var result6 = calc.ProcessInput("5,-2,3");
            Assert.AreEqual(3, result6);
        }
    }
}