module MazeSolver

open System
open Maze
open System.Collections.Generic

let solve (maze : maze) =
    let accessible = Array2D.init maze.size maze.size (fun _ _ -> false)
    let current = HashSet<Tuple<int, int>>()
    
    let checkBounds x y =
        x >= 0 && x < maze.size && y >= 0 && y < maze.size
    
    let makeStep (y, x) =
        let positive x = if x > 0 then x else 0
        
        let inner r u (lines : bool array2d) =
            if checkBounds (y + u) (x + r) 
               && not lines[y + positive u, x + positive r]
               && not accessible[(y + u), (x + r)] then
               current.Add (y + u, x + r) |> ignore

        accessible[y, x] <- true
        
        inner 0 1 maze.verticalLines (* Up *)
        inner 0 -1 maze.verticalLines(* Down *)
        inner 1 0 maze.horizontalLines (* Left *)
        inner -1 0 maze.horizontalLines (* Right *)

        current.Remove (y, x) |> ignore
        
    let rec buildAccessibility () =
        if current.Count > 0 then
            Seq.head current |> makeStep
            buildAccessibility ()
            
    let _, entryY, entryX = maze.entrypoint
    current.Add (entryY, entryX) |> ignore
    
    buildAccessibility () 
    
    accessible
    