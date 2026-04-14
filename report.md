# Report

Course: C# Development SS2026 (4 ECTS, 3 SWS)

Student ID: cc241045

BCC Group: Group B

Name: Flo Madner

## Methodology: 
For this project, I used a graph to represent the Sudoku board. 
1. **The Graph**: Each cell on the board is a vertex. I created edges between cells that are in the same row, column, or 3x3 box. These edges represent the constraints.
2. **The Algorithm**: I used a Depth-First Search (DFS) with backtracking. For each empty cell, the program tries a number from 1 to 9.
3. **Validation**: Before putting a number in a cell, the code checks the graph to see if any connected cell already has that same value.

## Additional Features
- **Generic Base Class**: The solver uses a generic base class (`BaseSolver<T>`), which makes the code more organized and easier to extend if I wanted to solve other types of puzzles later.
- **Timing**: The program measures how many milliseconds it takes to solve each puzzle.

## Discussion/Conclusion
The biggest challenge was figuring out how to use the `DataStructureLibrary` correctly. Since I couldn't easily see all the edges at first, I had to add a `GetEdges()` method to the `Graph` class so my solver could check the constraints. 
Once the graph was working, the backtracking algorithm was able to solve even hard puzzles quite quickly.

## Work with: 
- I worked on this project individually.

## Reference: 
- DFS Algorithm: Wikipedia
- Lecture slides on Graph Data Structures
