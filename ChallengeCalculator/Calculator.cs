using System;
using System.Collections.Generic;
using System.Linq;

namespace ChallengeCalculator
{
    public class Calculator
    {
        private readonly char[] delimiters =  { ',', '\n' };
        private List<double> negativeNumbers = new List<double>();

        public double ProcessInput(string input)
        {
            double answer = 0;

            string[] addends = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

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