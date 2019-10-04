using System;

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

            string input = string.Empty;
            while (true)
            {
                string line = Console.ReadLine();
                if (line.ToLower() == "x")
                    break;
                input += line + '\n'; // Adding newline from enter key.
            }
            var result = calc.ProcessInput(input);
            Console.Write(result.Answer + Environment.NewLine + result.Formula);
            Console.Write($"{Environment.NewLine}Press any key to end.{Environment.NewLine}");
            Console.ReadKey();
        }
    }
}