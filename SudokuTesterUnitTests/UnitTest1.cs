using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuTester.classes;

namespace SudokuTesterUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        SudokuValidator app = new SudokuValidator();
        List<Row> blocks = null;

        [TestMethod]
        public void Test_BuildBlocks()
        {
            using (app)
            {
                app.InputFile = @"E:\_WINDOWS_APPS\SudokuTester\TestFiles\input_sudoku_ValidWithBlankRows.txt";
                blocks = app.BuildBlocks();
                Assert.AreEqual(blocks.Count, 9);
                blocks = null;
            }
        }

        [TestMethod]
        public void Test_BuildBlocksBlankRows()
        {
            using (app)
            {
                string exMsg = String.Empty;
                app.InputFile = @"E:\_WINDOWS_APPS\SudokuTester\TestFiles\input_sudoku_InvalidEmptyRows.txt";
                try
                {
                    blocks = app.BuildBlocks();
                } catch (Exception ex)
                {
                    exMsg = ex.Message;
                }
                Assert.AreEqual(exMsg, "The file provided contains all blank rows");
                blocks = null;
            }
        }

        [TestMethod]
        public void Test_BuildBlocksBlankFile()
        {
            using (app)
            {
                string exMsg = String.Empty;
                app.InputFile = @"E:\_WINDOWS_APPS\SudokuTester\TestFiles\input_sudoku_InvalidEmptyFile.txt";
                try
                {
                    blocks = app.BuildBlocks();
                }
                catch (Exception ex)
                {
                    exMsg = ex.Message;
                }
                Assert.AreEqual(exMsg, "The file provided has no data.");
                blocks = null;
            }
        }

        [TestMethod]
        public void Test_HasValidColumns()
        {
            using (app)
            {
                app.InputFile = @"E:\_WINDOWS_APPS\SudokuTester\TestFiles\input_sudoku_ValidWithBlankRows.txt";
                blocks = app.BuildBlocks();
                Assert.IsTrue(app.HasValidColumns(blocks));
                blocks = null;
            }
        }

        [TestMethod]
        public void Test_HasValidBlock()
        {
            using (app)
            {
                app.InputFile = @"E:\_WINDOWS_APPS\SudokuTester\TestFiles\input_sudoku_ValidWithBlankRows.txt";
                blocks = app.BuildBlocks();
                Assert.IsTrue(app.HasValidBlock(blocks));
                blocks = null;
            }
        }

        [TestMethod]
        public void Test_ValidFileWithBlankRows()
        {
            using (app)
            {
                app.InputFile = @"E:\_WINDOWS_APPS\SudokuTester\TestFiles\input_sudoku_ValidWithBlankRows.txt";
                Assert.IsTrue(app.IsValidSudoku());
                blocks = null;
            }
        }

        [TestMethod]
        public void Test_InvalidFileWithLessRows()
        {
            using (app)
            {
                app.InputFile = @"E:\_WINDOWS_APPS\SudokuTester\TestFiles\input_sudoku_InvalidLessRows.txt";
                Assert.IsFalse(app.IsValidSudoku());
                blocks = null;
            }
        }

        [TestMethod]
        public void Test_InvalidFileWithDuplicateNumbers()
        {
            using (app)
            {
                app.InputFile = @"E:\_WINDOWS_APPS\SudokuTester\TestFiles\input_sudoku_InvalidDuplicateNumbers.txt";
                Assert.IsFalse(app.IsValidSudoku());
                blocks = null;
            }
        }

        [TestMethod]
        public void Test_ValidFileWithNoBlankRows()
        {
            using (app)
            {
                app.InputFile = @"E:\_WINDOWS_APPS\SudokuTester\TestFiles\input_sudoku_ValidWithNoBlankRows.txt";
                Assert.IsTrue(app.IsValidSudoku());
                blocks = null;
            }
        }

        [TestMethod]
        public void Test_InvalidFileWithLessColumns()
        {
            using (app)
            {
                app.InputFile = @"E:\_WINDOWS_APPS\SudokuTester\TestFiles\input_sudoku_InvalidLessColumns.txt";
                Assert.IsFalse(app.IsValidSudoku());
                blocks = null;
            }
        }

        [TestMethod]
        public void Test_InvalidFileWithInvalidCharacters()
        {
            using (app)
            {
                app.InputFile = @"E:\_WINDOWS_APPS\SudokuTester\TestFiles\input_sudoku_InvalidCharacters.txt";
                Assert.IsFalse(app.IsValidSudoku());
                blocks = null;
            }
        }

        [TestMethod]
        public void Test_InvalidFileWithInvalidEmptyRows()
        {
            using (app)
            {
                app.InputFile = @"E:\_WINDOWS_APPS\SudokuTester\TestFiles\input_sudoku_InvalidEmptyRows.txt";
                Assert.IsFalse(app.IsValidSudoku());
                blocks = null;
            }
        }

        [TestMethod]
        public void Test_InvalidFileWithInvalidEmptyFile()
        {
            using (app)
            {
                app.InputFile = @"E:\_WINDOWS_APPS\SudokuTester\TestFiles\input_sudoku_InvalidEmptyFile.txt";
                Assert.IsFalse(app.IsValidSudoku());
                blocks = null;
            }
        }

    }
}
