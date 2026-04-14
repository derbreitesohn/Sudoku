using DataStructureLibrary.Graph;

namespace Sudoku.Models
{
    public class Cell : BasicVertexProperty
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Value { get; set; }
        public bool IsFixed { get; set; }

        public Cell()
        {
            Value = 0;
            IsFixed = false;
        }

        public Cell(int row, int col, int value = 0, bool isFixed = false)
        {
            Row = row;
            Col = col;
            Value = value;
            IsFixed = isFixed;
            Name = $"({row},{col})";
        }

        public override string ToString()
        {
            return $"Cell({Row},{Col}) = {Value} {(IsFixed ? "[Fixed]" : "")}";
        }
    }
}
