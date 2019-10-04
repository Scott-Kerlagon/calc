using System.Collections.Generic;
using System.Linq;

namespace ChallengeCalculator
{
    public class CalculatorResult
    {
        private List<double> Numbers { get; set; }
        public double Answer => Numbers.Sum();
        public string Formula => $"{string.Join("+", Numbers)} = {Answer}";

        public CalculatorResult()
        {
            Numbers = new List<double>();
        }

        public void AddNumber(double number)
        {
            Numbers.Add(number);
        }
    }
}