using System;

namespace ChallengeCalculator
{
    class Program
    {
        //example args "-alt | -denyNegatives false -upperBound 10"
        static void Main(string[] args)
        {
            string altDelimiter = "";
            bool denyNegatives = true;
            double upperBound = 1000;
            //Args checking could be done more robustly and with more error checking.
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-alt" && args.Length - 1 >= i + 1)//Check that there is another value after arg name
                    altDelimiter = args[i + 1];
                else if (args[i] == "-denyNegatives" && args.Length - 1 >= i + 1)//Check that there is another value after arg name
                    denyNegatives = bool.Parse(args[i + 1]); //Skipping check to see if parse works. Exception is good for now for bad input.
                else if (args[i] == "-upperBound" && args.Length - 1 >= i + 1)//Check that there is another value after arg name
                    upperBound = double.Parse(args[i + 1]); //Skipping check to see if parse works. Exception is good for now for bad input.
            }


            //Enter on windows is expressed as \r\n where the requirents state \n for new line. Since there is no good way I can find to accept a \n for newline
            // as console input I will use the enter key's \r\n to do the same. Linux line endings are \n and windows tends to use \r\n.
            //Another possible way would be to unescape \\n from the input from console and proceed from there.

            while (true)
            {
                Calculator calc = new Calculator(altDelimiter, denyNegatives, upperBound);
                Console.WriteLine("Enter numbers with ',' or '\\n' between them to be added together, x to finish and start over.");

                string input = string.Empty;
                while (true)
                {
                    string line = Console.ReadLine();
                    if (line.ToLower() == "x")
                        break;
                    input += line + '\n'; // Adding newline from enter key.
                }
                var result = calc.ProcessInput(input);
                Console.Write(result.Answer + Environment.NewLine + result.Formula + Environment.NewLine);
            }
        }
    }
}