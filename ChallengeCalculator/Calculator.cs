using System;

namespace ChallengeCalculator
{
    public class Calculator
    {
        private readonly char[] delimiters =  { ',' };

        public double ProcessInput(string input)
        {
            double answer = 0;

            string[] addends = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            foreach (string addend in addends)
            {
                var isNumber = double.TryParse(addend, out double number);
                if (isNumber)
                {
                    answer += number;
                }
            }

            return answer;
        }
    }
}