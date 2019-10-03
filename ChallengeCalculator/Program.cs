using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeCalculator
{
    class Program
    {
        static void Main()
        {
            Calculator calc = new Calculator();
            string input = Console.ReadLine();
            var answer = calc.ProcessInput(input);
            Console.Write(answer);
            Console.Write($"{Environment.NewLine}Press any key to end.{Environment.NewLine}");
            Console.ReadKey();
        }
    }
}