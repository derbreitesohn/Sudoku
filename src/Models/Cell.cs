using DataStructureLibrary.Graph;
namespace Sudoku.src.Models;

public class Cell : BasicVertexProperty
{

    public Cell()
    {
        // base logic to fall back to
    }

    // Sudoku 3x3
    public int Row { get; set; }
    public int Col { get; set; }
    public int Val { get; set; }
    public bool IsFixed { get; set; }
}