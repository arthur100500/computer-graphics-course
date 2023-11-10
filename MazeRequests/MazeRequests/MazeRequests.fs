module MazeRequests

open System.Collections.Generic
open Maze

let mazeSolutions = Dictionary<maze, bool array2d>()

let solveMemo maze =
    match mazeSolutions.TryGetValue maze with
    | false, _ ->
        let solution = MazeSolver.solve maze
        mazeSolutions.Add(maze, solution)
        solution
    | true, v -> v

let exitExists x y maze =
    let solution = solveMemo maze
    solution[x, y]