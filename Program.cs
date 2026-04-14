using System;
using System.Collections.Generic;
using Sudoku.Models;
using Sudoku.Algorithms;
using Sudoku.IO;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sudoku Solver - DFS & Graph Project");
            Console.WriteLine("========================================");
            // Test cases with varying difficulty
            var puzzles = new List<(string Name, string Data)>
            {
                ("Easy", "003020600900305001001806400008102900700000008006708200002609500800203009005010300"),
                ("Medium", "530070000600195000098000060800060003400803001700020006060000280000419005000080079"),
                ("Hard", "100007090030020008009600500005300900010080002600004000300000010041000007007000300")
            };

            DFS solver = new DFS();

            foreach (var puzzle in puzzles)
            {
                Console.WriteLine($"\n>>> Testing Puzzle: {puzzle.Name}");
                Board board = SudokuIO.LoadBoard(puzzle.Data);
                
                Console.WriteLine("Initial State:");
                SudokuIO.PrintBoard(board);

                var startTime = DateTime.Now;
                bool solved = solver.Solve(board);
                var endTime = DateTime.Now;

                if (solved)
                {
                    Console.WriteLine("\nSolution Found:");
                    SudokuIO.PrintBoard(board);
                }
                else
                {
                    Console.WriteLine("\n[Error] No solution exists for this puzzle.");
                }

                Console.WriteLine($"Time taken: {(endTime - startTime).TotalMilliseconds:F2} ms");
                Console.WriteLine(new string('-', 30));
            }
            
            Console.WriteLine("\nAll tests completed.");
        }
    }
}
