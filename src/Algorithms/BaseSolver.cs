using Sudoku.Models;

namespace Sudoku.Algorithms
{
    public abstract class BaseSolver<T>
    {
        public abstract bool Solve(T puzzle);
    }
}
