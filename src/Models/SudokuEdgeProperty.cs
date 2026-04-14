using DataStructureLibrary.Graph;

namespace Sudoku.Models
{
    public class SudokuEdgeProperty : BasicEdgeProperty<Vertex<Cell>>
    {
        // Add any properties if needed, for example, edge type (row, col, block)
        public string EdgeType { get; set; } = "Constraint";

        public override string ToString()
        {
            return $"{EdgeType}: ({(Source != null ? Source.Property.Name : "null")}) <--> ({(Target != null ? Target.Property.Name : "null")})";
        }
    }
}
