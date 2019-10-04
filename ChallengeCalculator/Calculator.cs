using System;
using System.Collections.Generic;
using System.Linq;

namespace ChallengeCalculator
{
    public class Calculator
    {
        private readonly string AlternateDelimiter;
        private readonly bool DenyNegativeNumbers;
        private readonly double UpperBound;

        public Calculator(string alternateDelimiter = "", bool denyNegativeNumbers = true, double upperBound = 1000)
        {
            AlternateDelimiter = alternateDelimiter;
            DenyNegativeNumbers = denyNegativeNumbers;
            UpperBound = upperBound;
        }

        public CalculatorResult ProcessInput(string input)
        {
            List<string> delimiters = new List<string>() { ",", "\n", AlternateDelimiter };
            List<double> negativeNumbers = new List<double>();
            CalculatorResult result = new CalculatorResult();

            string[] addends = input.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            bool newDelimitersAdded = false;
            if (addends != null && addends.Length > 0)
            {
                if (addends[0].StartsWith("//[") && addends[0].EndsWith("]"))
                {
                    delimiters.AddRange(addends[0]
                        .Remove(addends[0].Length - 1, 1)
                        .Remove(0, 3)
                        .Split(new string[] { "][" }, StringSplitOptions.RemoveEmptyEntries)
                        );
                    newDelimitersAdded = true;
                }
                else if (addends[0].StartsWith("//") && addends[0].Length == 3)//If the custom delimiter at this requirement number is more than 1 char ignore
                {
                    delimiters.Add(addends[0][2].ToString());
                    newDelimitersAdded = true;
                }
            }
            if (newDelimitersAdded)
            {
                //Skip 1 is to ignore the custom delimiters when present.
                addends = input.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
            }

            foreach (string addend in addends)
            {
                var isNumber = double.TryParse(addend, out double number);
                if (isNumber)
                {
                    if (DenyNegativeNumbers && number < 0)
                        negativeNumbers.Add(number);
                    else if (number <= UpperBound)
                        result.AddNumber(number);
                    else
                        result.AddNumber(0);
                }
                else
                    result.AddNumber(0);
            }

            if (negativeNumbers.Any())
                throw new ArgumentOutOfRangeException($"Invalid negative numbers {string.Join(", ", negativeNumbers)}");

            return result;
        }
    }
}