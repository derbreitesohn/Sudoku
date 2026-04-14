using System;
using System.Collections.Generic;
using System.Linq;
using DataStructureLibrary.Graph;

namespace Sudoku.Models
{
    public class Board
    {
        public Graph<Cell, SudokuEdgeProperty> SudokuGraph { get; private set; }
        public Vertex<Cell>[,] Cells { get; private set; }

        public Board()
        {
            SudokuGraph = new Graph<Cell, SudokuEdgeProperty>();
            Cells = new Vertex<Cell>[9, 9];
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            // 1. Create 81 vertices
            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    var vertex = SudokuGraph.AddVertex($"({r},{c})");
                    vertex.Property.Row = r;
                    vertex.Property.Col = c;
                    vertex.Property.Value = 0;
                    vertex.Property.IsFixed = false;
                    Cells[r, c] = vertex;
                }
            }

            // 2. Add edges for Sudoku constraints (Row, Column, and 3x3 Box)
            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    AddConstraints(r, c);
                }
            }
        }

        private void AddConstraints(int row, int col)
        {
            var source = Cells[row, col];

            // Row constraints
            for (int c = 0; c < 9; c++)
            {
                if (c != col)
                {
                    SudokuGraph.AddEdge(source, Cells[row, c]);
                }
            }

            // Column constraints
            for (int r = 0; r < 9; r++)
            {
                if (r != row)
                {
                    SudokuGraph.AddEdge(source, Cells[r, col]);
                }
            }

            // Box constraints (3x3)
            int boxRow = (row / 3) * 3;
            int boxCol = (col / 3) * 3;

            for (int r = boxRow; r < boxRow + 3; r++)
            {
                for (int c = boxCol; c < boxCol + 3; c++)
                {
                    if (r != row || c != col)
                    {
                        SudokuGraph.AddEdge(source, Cells[r, c]);
                    }
                }
            }
        }

        public bool IsValid(int row, int col, int val)
        {
            var vertex = Cells[row, col];
            
            // Get all edges where this vertex is the source
            // Any target of these edges cannot have the same value
            foreach (var edge in SudokuGraph.GetEdges())
            {
                if (edge.Property.Source == vertex && edge.Property.Target != null)
                {
                    if (edge.Property.Target.Property.Value == val)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void SetCellValue(int row, int col, int val, bool isFixed = false)
        {
            Cells[row, col].Property.Value = val;
            Cells[row, col].Property.IsFixed = isFixed;
        }

        public void Print()
        {  // How to determine where to  print the number 
            for (int r = 0; r < 9; r++)
            {
                if (r % 3 == 0 && r != 0) Console.WriteLine("------+-------+------");
                for (int c = 0; c < 9; c++)
                {
                    if (c % 3 == 0 && c != 0) Console.Write("| ");
                    int val = Cells[r, c].Property.Value;
                    Console.Write(val == 0 ? ". " : val + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
