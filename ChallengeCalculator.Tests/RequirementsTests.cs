using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
            //Expected result changed to 1 after requirement 5 to ignore values over 1000
            //Assert.AreEqual(5001, result2);
            Assert.AreEqual(1, result2);

            var result3 = calc.ProcessInput("");
            Assert.AreEqual(0, result3);

            var result4 = calc.ProcessInput("5,tytyt");
            Assert.AreEqual(5, result4);

            //Removed limit so test no longer applies
            //Max 2 number limit
            //var result5 = calc.ProcessInput("5,2,3");
            //Assert.AreEqual(7, result5);

            //No longer applies as negative numbers throw an exception
            //Negative numbers
            //var result6 = calc.ProcessInput("5,-2,3");
            //Assert.AreEqual(6, result6);
        }

        [TestMethod]
        public void Requirement2()
        {
            Calculator calc = new Calculator();
            var result1 = calc.ProcessInput("1,2,3,4,5,6,7,8,9,10,11,12");
            Assert.AreEqual(78, result1);

            //No longer applies as negative numbers throw an exception
            //var result2 = calc.ProcessInput("1,2,3,4,5,6,7,8,9,10,11,-12,junk");
            //Assert.AreEqual(54, result2);
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Invalid negative numbers -1")]
        public void Requirement4a()
        {
            Calculator calc = new Calculator();
            var result1 = calc.ProcessInput("-1");
            Assert.AreEqual(6, result1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Invalid negative numbers -2")]
        public void Requirement4b()
        {
            Calculator calc = new Calculator();
            var result2 = calc.ProcessInput("1,-2");
            Assert.AreEqual(6, result2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Invalid negative numbers -3")]
        public void Requirement4c()
        {
            Calculator calc = new Calculator();
            var result3 = calc.ProcessInput("1\n0,-3");
            Assert.AreEqual(8, result3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),"Invalid negative numbers -2, -4")]
        public void Requirement4d()
        {
            Calculator calc = new Calculator();
            var result4 = calc.ProcessInput("1,-2,-4");
            Assert.AreEqual(6, result4);
        }

        [TestMethod]
        public void Requirement5()
        {
            Calculator calc = new Calculator();
            var result1 = calc.ProcessInput("2,1001,6");
            Assert.AreEqual(8, result1);

            var result2 = calc.ProcessInput("2,1001,1000");
            Assert.AreEqual(1002, result2);
        }
    }
}