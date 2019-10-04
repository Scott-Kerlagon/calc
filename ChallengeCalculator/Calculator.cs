using System;
using System.Collections.Generic;
using System.Linq;

namespace ChallengeCalculator
{
    public class Calculator
    {

        public double ProcessInput(string input)
        {
            List<string> delimiters = new List<string>() { ",", "\n" };
            List<double> negativeNumbers = new List<double>();
            double answer = 0;

            string[] addends = input.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            bool newDelimitersAdded = false;
            if (addends != null && addends.Length > 0)
            {
                if (addends[0].StartsWith("//[") && addends[0].EndsWith("]"))
                {
                    delimiters.Add(addends[0].Remove(addends[0].Length - 1, 1).Remove(0, 3));
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
                addends = input.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray(); 
            }

            foreach (string addend in addends)
            {
                var isNumber = double.TryParse(addend, out double number);
                if (isNumber)
                {
                    if (number < 0)
                        negativeNumbers.Add(number);
                    else if (number < 1001)
                        answer += number;
                }
            }

            if (negativeNumbers.Any())
                throw new ArgumentOutOfRangeException($"Invalid negative numbers {string.Join(", ", negativeNumbers)}");

            return answer;
        }
    }
}