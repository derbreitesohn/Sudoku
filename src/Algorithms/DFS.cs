using System;
using Sudoku.Models;

namespace Sudoku.Algorithms
{
    public class DFS : BaseSolver<Board>
    {
        public override bool Solve(Board board)
        {
            return Backtrack(board, 0, 0);
        }

        private bool Backtrack(Board board, int row, int col)
        {
            // stop at the end of the board
            if (row == 9) return true;

            // Move to next cell
            int nextRow = col == 8 ? row + 1 : row;
            int nextCol = col == 8 ? 0 : col + 1;

            // If current cell is fixed, skip it
            if (board.Cells[row, col].Property.IsFixed)
            {
                return Backtrack(board, nextRow, nextCol);
            }

            // Try values 1 to 9
            for (int val = 1; val <= 9; val++)
            {
                if (board.IsValid(row, col, val))
                {
                    board.SetCellValue(row, col, val);
                    if (Backtrack(board, nextRow, nextCol))
                    {
                        return true;
                    }
                    // Backtrack
                    board.SetCellValue(row, col, 0);
                }
            }

            return false;
        }
    }
}
