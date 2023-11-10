# Maze Request
Program that generates mazes with some cells having access to exit and some not

## Structure

### Maze.fs
Type `maze` represents square maze with random walls, contains vertical and horizontal walls 2D array, coordinates of exit cell and its size
- `verticalLines` - stores vertical lines
- `horizontalLines` - stores horizontal lines
- `size` - stores size of one dimension
- `entrypoint` - stores cell for entrypoint

Function `genRandomMaze` generates random maze of given size and seeds

Function `mazeToAscii` renders maze to ASCII with the solution if exists
- walls are done with `----` or `|`
- `xxx` means that the cell is unreachable from exit
```
+---+---+   +---+---+
|xxx|xxx|   |xxx xxx|
+   +   +   +   +   +
|xxx|xxx|   |xxx|xxx|
+---+---+   +---+---+
|xxx|       |       |
+---+   +   +   +   +
|       |           |
+---+---+   +   +   +
|                   |
+---+---+---+---+---+
```

### MazeSolver.fs

Function `solve` creates a solution for maze given. Solution is array2D of accessible cells

Algorithm stars from the enter, and marches to the accessible cells `left`/`right`/`up`/`down`.
It stores positions reached in the 2d array `accessible`, and cells it will research in hash set `current`

While `current` is not empty
- Pick one from `current`
- For all directions (`left`/`right`/`up`/`down`), if cell is accessible (no wall exists between) and is not already `true` in `accessible` we add it to `current`
- Then cell is set to `true` in `accessible`
- Then remove cell from current

Complexity of algorithm is `O(N)`, where `N` is cell count.

### MazeRequests.fs

Function `exitExists` is the online reachability request
For given maze, it solves it using `MazeSolver.solve`, memoizes result and uses it for next requests.


### Tests

Project contains 3 tests with 5x5 and 30x30 mazes