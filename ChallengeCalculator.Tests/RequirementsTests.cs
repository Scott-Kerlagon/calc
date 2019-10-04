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
            Assert.AreEqual(20, result.Answer);

            var result2 = calc.ProcessInput("1,5000");
            //Expected result changed to 1 after requirement 5 to ignore values over 1000
            //Assert.AreEqual(5001, result2);
            Assert.AreEqual(1, result2.Answer);

            var result3 = calc.ProcessInput("");
            Assert.AreEqual(0, result3.Answer);

            var result4 = calc.ProcessInput("5,tytyt");
            Assert.AreEqual(5, result4.Answer);

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
            Assert.AreEqual(78, result1.Answer);

            //No longer applies as negative numbers throw an exception
            //var result2 = calc.ProcessInput("1,2,3,4,5,6,7,8,9,10,11,-12,junk");
            //Assert.AreEqual(54, result2);
        }

        [TestMethod]
        public void Requirement3()
        {
            Calculator calc = new Calculator();
            var result1 = calc.ProcessInput("1\n2,3");
            Assert.AreEqual(6, result1.Answer);

            var result2 = calc.ProcessInput("1,2\n3");
            Assert.AreEqual(6, result2.Answer);

            var result3 = calc.ProcessInput("1\n2,3,,\n\n,junk,1\n1");
            Assert.AreEqual(8, result3.Answer);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Invalid negative numbers -1")]
        public void Requirement4a()
        {
            Calculator calc = new Calculator();
            var result1 = calc.ProcessInput("-1");
            Assert.AreEqual(6, result1.Answer);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Invalid negative numbers -2")]
        public void Requirement4b()
        {
            Calculator calc = new Calculator();
            var result2 = calc.ProcessInput("1,-2");
            Assert.AreEqual(6, result2.Answer);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Invalid negative numbers -3")]
        public void Requirement4c()
        {
            Calculator calc = new Calculator();
            var result3 = calc.ProcessInput("1\n0,-3");
            Assert.AreEqual(8, result3.Answer);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),"Invalid negative numbers -2, -4")]
        public void Requirement4d()
        {
            Calculator calc = new Calculator();
            var result4 = calc.ProcessInput("1,-2,-4");
            Assert.AreEqual(6, result4.Answer);
        }

        [TestMethod]
        public void Requirement5()
        {
            Calculator calc = new Calculator();
            var result1 = calc.ProcessInput("2,1001,6");
            Assert.AreEqual(8, result1.Answer);

            var result2 = calc.ProcessInput("2,1001,1000");
            Assert.AreEqual(1002, result2.Answer);
        }

        [TestMethod]
        public void Requirement6()
        {
            Calculator calc = new Calculator();
            var result1 = calc.ProcessInput("//;\n2;5");
            Assert.AreEqual(7, result1.Answer);

            var result2 = calc.ProcessInput("//|\n2|5");
            Assert.AreEqual(7, result2.Answer);

            var result3 = calc.ProcessInput("//||\n2|5");
            Assert.AreEqual(0, result3.Answer);
        }

        [TestMethod]
        public void Requirement7()
        {
            Calculator calc = new Calculator();
            var result1 = calc.ProcessInput("//[***]\n11***22***33");
            Assert.AreEqual(66, result1.Answer);

            var result2 = calc.ProcessInput("//[||]\n2||5");
            Assert.AreEqual(7, result2.Answer);

            var result3 = calc.ProcessInput("//[55]\n2,55");
            Assert.AreEqual(2, result3.Answer);

            var result4 = calc.ProcessInput("//[]\n255");
            Assert.AreEqual(255, result4.Answer);

            var result5 = calc.ProcessInput("//[,]\n4,,2");
            Assert.AreEqual(6, result5.Answer);

            var result6 = calc.ProcessInput("//[[]\n4[2");
            Assert.AreEqual(6, result6.Answer);

            var result7 = calc.ProcessInput("//[[]]\n4[]3");
            Assert.AreEqual(7, result7.Answer);
        }

        [TestMethod]
        public void Requirement8()
        {
            Calculator calc = new Calculator();
            var result1 = calc.ProcessInput("//[*][!!][r9r]\n11r9r22*33!!44");
            Assert.AreEqual(110, result1.Answer);

            var result2 = calc.ProcessInput("//[***][||]\n11***22||33");
            Assert.AreEqual(66, result2.Answer);

            var result3 = calc.ProcessInput("//[||][||]\n2||5");
            Assert.AreEqual(7, result3.Answer);

            var result4 = calc.ProcessInput("//[][]\n2,55");
            Assert.AreEqual(57, result4.Answer);
        }

        [TestMethod]
        public void Stretch1()
        {
            Calculator calc = new Calculator();
            var result1 = calc.ProcessInput("2,4,rrrr,1001,6");
            Assert.AreEqual("2+4+0+0+6 = 12", result1.Formula);

            var result2 = calc.ProcessInput("2,4\n20,6");
            Assert.AreEqual("2+4+20+6 = 32", result2.Formula);
        }

        [TestMethod]
        public void Stretch3()
        {
            //Tests here are to verify configurations take.
            Calculator calc = new Calculator("|", false, 10);
            var result1 = calc.ProcessInput("1,-1,20");
            Assert.AreEqual(0, result1.Answer);
            Assert.AreEqual("1+-1+0 = 0", result1.Formula);
        }
    }
}