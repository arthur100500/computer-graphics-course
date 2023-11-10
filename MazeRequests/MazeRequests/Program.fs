open MazeSolver
open Maze

[<EntryPoint>]
let main _ =
    let maze = genRandomMaze 1000 (Some 10)
    
    MazeRequests.exitExists 1 1 maze |> printfn "%b"
    MazeRequests.exitExists 999 1 maze |> printfn "%b"
    MazeRequests.exitExists 200 200 maze |> printfn "%b"
    MazeRequests.exitExists 800 800 maze |> printfn "%b"
    MazeRequests.exitExists 1 999 maze |> printfn "%b"
    MazeRequests.exitExists 999 999 maze |> printfn "%b"
    
    (* OK *)
    0