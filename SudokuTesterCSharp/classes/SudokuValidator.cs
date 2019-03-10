using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace SudokuTester.classes
{
    public class SudokuValidator : IDisposable
    {
        const string VALID_NUMBERS = "123456789";
        static Regex regex = new Regex("^[1-9]+$", RegexOptions.Compiled);
        List<Row> blocks = null;

        public string InputFile { get; set; }

        public List<Row> BuildBlocks()
        {
            string[] lines = File.ReadAllLines(InputFile);
            // Check if there is any data in the file
            if (lines.Length > 0)
            {
                blocks = new List<Row>();
                foreach (string line in lines)
                {
                    if (line.Trim().Length > 0)
                    {
                        Row block = new Row();
                        char[] orignalNumbers = line.ToCharArray();
                        block.Cell = orignalNumbers;
                        blocks.Add(block);
                    }
                }
                if (blocks.Count == 0)
                {
                    throw new Exception("The file provided contains all blank rows");
                }
                return blocks;
            }
            else
            {
                throw new Exception("The file provided has no data.");
            }
        }

        public bool IsValidSudoku()
        {
            try
            {
                blocks = BuildBlocks();
                foreach (Row block in blocks)
                {
                    // Check if we have 9 numbers
                    if (block.Cell.Length == 9)
                    {
                        char[] numbers = new char[block.Cell.Length];
                        block.Cell.CopyTo(numbers, 0);
                        Array.Sort(numbers);
                        string temp = new string(numbers);
                        // Check if we have only numbers 1 to 9 (no need to check for duplicates here as the next condition will find it)
                        if (!regex.IsMatch(temp))
                        {
                            Console.WriteLine("File contains either 0 or non numeric values.");
                            return false;
                        }
                        // This check will detect any duplicate numbers
                        if (temp != VALID_NUMBERS)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid File - Contains Less Numbers than expected.");
                        return false;
                    }
                }
                if (blocks.Count == 9)
                {
                    // We now have 9 valid rows in the blocks
                    // We now need to check the column validity
                    if (HasValidColumns(blocks))
                    {
                        // We now have all valid columns
                        // Next we need to validate 3x3 blocks i.e the first 3 numbers of 3 consecutive rows
                        if (HasValidBlock(blocks))
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid file - Contains More or Less rows of numbers.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public bool HasValidColumns(List<Row> blocks)
        {
            char[] row1 = blocks[0].Cell;
            char[] row2 = blocks[1].Cell;
            char[] row3 = blocks[2].Cell;
            char[] row4 = blocks[3].Cell;
            char[] row5 = blocks[4].Cell;
            char[] row6 = blocks[5].Cell;
            char[] row7 = blocks[6].Cell;
            char[] row8 = blocks[7].Cell;
            char[] row9 = blocks[8].Cell;

            for (int c = 0; c < 9; c++)
            {
                char[] col = (row1[c].ToString() + row2[c].ToString() + row3[c].ToString() + row4[c].ToString() + row5[c].ToString() + row6[c].ToString() + row7[c].ToString() + row8[c].ToString() + row9[c].ToString()).ToCharArray();
                Array.Sort(col);
                string temp = new string(col);
                if (temp != VALID_NUMBERS)
                {
                    return false;
                }
            }
            return true;
        }

        public bool HasValidBlock(List<Row> blocks)
        {
            for (int r = 0; r < 9; r += 3)
            {
                for (int c = 0; c < 9; c += 3)
                {
                    string b1_1 = blocks[r].Cell[c].ToString() + blocks[r].Cell[c + 1].ToString() + blocks[r].Cell[c + 2].ToString();
                    string b1_2 = blocks[r + 1].Cell[c].ToString() + blocks[r + 1].Cell[c + 1].ToString() + blocks[r + 1].Cell[c + 2].ToString();
                    string b1_3 = blocks[r + 2].Cell[c].ToString() + blocks[r + 2].Cell[c + 1].ToString() + blocks[r + 2].Cell[c + 2].ToString();

                    char[] block = (b1_1 + b1_2 + b1_3).ToCharArray();
                    Array.Sort(block);

                    string temp = new string(block);
                    if (temp != VALID_NUMBERS)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        #region Dispose Code
        bool _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~SudokuValidator()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // No other IDisposable object to dispose
            }

            // release any unmanaged objects
            // set the object references to null
            blocks = null;

            _disposed = true;
        }
        #endregion
    }
}
