using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SudokuTester.classes;

namespace SudokuTester
{
    class Program
    {

        static void Main(string[] args)
        {
            if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
            {
                if (File.Exists(args[0].ToString()))
                {
                    using (SudokuValidator validator = new SudokuValidator())
                    {
                        validator.InputFile = args[0].ToString();
                        Console.WriteLine(validator.IsValidSudoku());
                    }
                }
                else
                {
                    Console.WriteLine("Input file not found.");
                }
            }
            else 
            {
                Console.WriteLine("An input file was expected.\n\nUsage:\n\tSudokuTester.exe <path_to_your_input_file>");
            }
            Console.ReadKey();
        }

    }
}
