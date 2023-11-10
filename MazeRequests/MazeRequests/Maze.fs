module Maze

open System
open System.Text

(* Horizontal and vertical connections between points i and i + 1 *)
type maze =
    { verticalLines: bool array2d
      horizontalLines: bool array2d
      size: int
      entrypoint: bool * int * int }

let genRandomMaze size seed =
    let n = size

    let seed =
        match seed with
        | Some s -> s
        | None -> Random().Next()

    let random = Random(seed)

    let wallProb = 0.5f

    printfn $"{size}x{size} Maze with seed {seed}"

    (* gen enclosed maze with random walls *)
    let verticalLines =
        Array2D.init (n + 1) n (fun x _ -> x = 0 || x = n || random.NextSingle() < wallProb)

    let horizontalLines =
        Array2D.init n (n + 1) (fun _ y -> y = 0 || y = n || random.NextSingle() < wallProb)

    (* open exit *)
    let exit_orientation = random.NextSingle() > 0.5f
    let edge_c = (random.Next() % 2) * n
    let independent_c = random.Next() % n

    let mutable ep: (bool * int * int) option = None

    let positive x = if x > 0 then x else 0

    if exit_orientation then
        verticalLines[edge_c, independent_c] <- false
        ep <- Some(exit_orientation, edge_c - 1 |> positive, independent_c)
    else
        horizontalLines[independent_c, edge_c] <- false
        ep <- Some(exit_orientation, independent_c, edge_c - 1 |> positive)

    { verticalLines = verticalLines
      horizontalLines = horizontalLines
      size = n
      entrypoint = ep.Value }


let mazeToAscii (maze: maze) (accessible: bool array2d) : string =
    let sb = StringBuilder(4 * maze.size * maze.size + 2 * maze.size + 1)

    for i in 0 .. maze.size - 1 do
        (* process horizontal *)
        for j in 0 .. maze.size - 1 do
            sb.Append(if maze.horizontalLines[j, i] then "+---" else "+   ") |> ignore

        sb.Append("+\n") |> ignore
        (* process vertical and visited *)
        for j in 0 .. maze.size - 1 do
            sb.Append(if maze.verticalLines[j, i] then "|" else " ") |> ignore
            sb.Append(if accessible[j, i] then "   " else "xxx") |> ignore

        sb.Append(if maze.verticalLines[maze.size, i] then "|" else " ") |> ignore
        sb.Append("\n") |> ignore

    for j in 0 .. maze.size - 1 do
        sb.Append(
            if maze.horizontalLines[j, maze.size] then
                "+---"
            else
                "+   "
        )
        |> ignore

    sb.Append("+\n") |> ignore

    sb.ToString()
