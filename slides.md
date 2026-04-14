# Presentation: Sudoku Solver

## Intro
- **Project**: Sudoku Solver
- **Main Goal**: Solve Sudoku puzzles using a graph-based DFS algorithm.
- **Tools**: C# and .NET 10.0.

## Logic
- I used the `DataStructureLibrary/Graph` to handle Sudoku rules.
- **Vertices**: Every cell on the board.
- **Edges**: Connections for the same row, column, or 3x3 box.

## Solving (DFS)
- The solver uses a recursive Depth-First Search with backtracking.
- It tries values 1-9 in each empty spot.
- If it hits a dead end, it goes back and tries the next number.

## Implementation
- **Generics**: I used a generic base class for the solver.
- **Graph library**: I extended the lecture's graph class to access edges for constraint checking.

## Testing
- Tested on Easy, Medium, and Hard puzzles.
- Solutions were found within 10-600ms on my machine.

## Conclusion
- Successfully used a graph structure for puzzle rules.
- Separated board data from the solving logic.
