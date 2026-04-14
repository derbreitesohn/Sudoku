using System;
using Sudoku.Models;

namespace Sudoku.IO
{
    public static class SudokuIO
    {
        public static Board LoadBoard(string input)
        {
            Board board = new Board();
            int index = 0;
            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    char ch = input[index++];
                    if (ch >= '1' && ch <= '9')
                    {
                        board.SetCellValue(r, c, ch - '0', true);
                    }
                    else
                    {
                        board.SetCellValue(r, c, 0, false);
                    }
                }
            }
            return board;
        }

        public static void PrintBoard(Board board)
        {
            board.Print();
        }
    }
}
