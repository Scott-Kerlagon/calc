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

            //Removed limit so test no longer applies
            //Max 2 number limit
            //var result5 = calc.ProcessInput("5,2,3");
            //Assert.AreEqual(7, result5);

            //Negative numbers
            var result6 = calc.ProcessInput("5,-2,3");
            Assert.AreEqual(6, result6);
        }

        [TestMethod]
        public void Requirement2()
        {
            Calculator calc = new Calculator();
            var result1 = calc.ProcessInput("1,2,3,4,5,6,7,8,9,10,11,12");
            Assert.AreEqual(78, result1);

            var result2 = calc.ProcessInput("1,2,3,4,5,6,7,8,9,10,11,-12,junk");
            Assert.AreEqual(54, result2);
        }

        [TestMethod]
        public void Requirement3()
        {
            Calculator calc = new Calculator();
            var result1 = calc.ProcessInput("1\n2,3");
            Assert.AreEqual(6, result1);

            var result2 = calc.ProcessInput("1,2\n3");
            Assert.AreEqual(6, result2);

            var result3 = calc.ProcessInput("1\n2,3,,\n\n,junk,1\n1");
            Assert.AreEqual(8, result3);
        }
    }
}