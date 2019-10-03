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
            Console.WriteLine("Enter numbers with ',' or '\\n' between them to be added together, x to finish.");

            //Enter on windows is expressed as \r\n where the requirents state \n for new line. Since there is no good way I can find to accept a \n for newline
            // as console input I will use the enter key's \r\n to do the same. Linux line endings are \n and windows tends to use \r\n.
            //Another possible way would be to unescape \\n from the input from console and proceed from there.

            bool keepReading = true;
            string input = string.Empty;
            while (keepReading)
            {
                string line = Console.ReadLine();
                if (line.ToLower() == "x")
                    keepReading = false;
                input += line + '\n'; // Adding newline from enter key.
            }
            var answer = calc.ProcessInput(input);
            Console.Write(answer);
            Console.Write($"{Environment.NewLine}Press any key to end.{Environment.NewLine}");
            Console.ReadKey();
        }
    }
}