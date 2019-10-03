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

            int counter = 0;
            foreach (string addend in addends)
            {
                if (counter >= 2)
                    break;

                var isNumber = double.TryParse(addend, out double number);
                if (isNumber)
                {
                    counter++;
                    answer += number;
                }
            }

            return answer;
        }
    }
}