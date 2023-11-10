module MazeRequestsTests

open NUnit.Framework

open Maze
open MazeRequests

[<Test>]
let Test5by5seed1 () =
    (*  Maze looks like this
        Size 5x5
        Seed 1
    
        xxx means exit is unreachable
        empty cell means exit is reachable
    
        v - cells to be tested
    
        +---+---+   +---+---+
        |xxx|xxx|   |xxx xvx|
        +   +   +   +   +   +
        |xxx|xvx|   |xxx|xxx|
        +---+---+   +---+---+
        |xxx|       |       |
        +---+   +   +   +   +
        |       |     v     |
        +---+---+   +   +   +
        | v                 |
        +---+---+---+---+---+  *)

    let maze = genRandomMaze 5 (Some 1)

    Assert.AreEqual(false, exitExists 4 0 maze)
    Assert.AreEqual(false, exitExists 1 1 maze)
    Assert.AreEqual(true, exitExists 3 3 maze)
    Assert.AreEqual(true, exitExists 0 4 maze)

[<Test>]
let Test5by5seed2 () =
    (*  Maze looks like this
        Size 5x5
        Seed 2
    
        xxx means exit is unreachable
        empty cell means exit is reachable
    
        v - cells to be tested
    
        +---+---+---+---+---+
        |xvx xxx|xxx xxx|xxx|
        +---+   +---+---+   +
        |xxx|xxx xxx|xxx xxx|
        +---+   +   +---+   +
        |xxx|xxx|xvx|xxx|xxx|
        +---+   +   +---+   +
        |xxx xxx|xxx xxx xxx|
        +   +   +   +   +---+
        |xvx|xxx|xxx|xxx| v |
        +---+---+---+---+   + *)

    let maze = genRandomMaze 5 (Some 2)

    Assert.AreEqual(true, exitExists 4 4 maze)
    Assert.AreEqual(false, exitExists 0 0 maze)
    Assert.AreEqual(false, exitExists 0 4 maze)
    Assert.AreEqual(false, exitExists 2 2 maze)

[<Test>]
let Test30by30seed1 () =
    (*  Maze looks like this
        Size 30x30
        Seed 1
    
        xxx means exit is unreachable
        empty cell means exit is reachable
    
        v - cells to be tested
          0   1   2   3   4   5   6   7   8   9   10  11  12  13  14  15  16  17  18  19  20  21  22  23  24  25  26  27  28  29
        +---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+   +---+---+---+---+---+---+---+---+---+---+
        |xvx|xxx xxx xxx xxx xxx|xxx|xxx xxx|xxx xxx xxx|xxx|xxx|xxx xxx|xxx|xxx|     v     |                               |xxx|
        +---+   +---+---+   +   +   +   +---+   +---+   +   +   +---+   +   +---+   +   +   +   +---+   +   +---+---+   +---+   +
        |xxx|xxx xxx|xxx xxx xxx|xxx xxx|xxx|xxx|xxx xxx xxx xxx xxx xxx xxx xxx|                   |       |xxx xxx| v |xxx xxx|
        +---+   +---+   +---+---+---+   +   +   +   +   +   +---+---+---+---+---+   +   +   +---+   +   +   +---+---+---+---+---+
        |xxx|xxx xxx|xxx|xxx xxx xxx|xxx|xxx xxx xxx xxx|xxx|xxx xxx|xxx|   |       |   |               |       |xxx xvx xxx|xxx|
        +---+   +   +   +---+---+---+---+---+---+   +---+---+   +   +---+   +   +---+---+   +   +   +   +---+---+---+---+---+   +
        |xxx xxx|xxx|xxx|xxx|xxx xxx xxx|xxx|xxx|xxx|xxx xxx|xxx xxx|xxx|   |       |xxx|     v |   |   |xxx xxx xxx|xxx|xxx xxx|
        +---+   +   +   +---+---+---+---+   +   +---+---+   +   +---+   +   +   +---+   +---+---+---+---+---+   +   +---+   +   +
        |xxx xxx xxx|xxx xxx|xxx|xxx xxx|xxx xxx|xxx xxx|xxx|xxx xxx xxx|       |xxx xxx xxx xxx xxx xxx|xxx xxx|xxx xxx xxx xxx|
        +   +---+   +   +---+   +---+   +   +   +---+   +---+---+   +   +   +   +---+---+   +   +---+---+   +---+---+---+   +   +
        |xxx|xxx xxx|xxx|xxx|xxx xxx xxx|xxx|xxx|xxx|xxx xxx|xxx xxx xxx|           |xxx xxx xxx xxx xxx xxx xxx xxx|xxx|xxx xxx|
        +---+---+---+   +---+---+   +   +   +   +   +---+---+   +   +---+---+---+---+   +---+   +---+---+---+   +   +   +   +   +
        |xxx|xxx xxx xxx xxx|xxx xxx|xxx xxx|xxx|xxx xxx xxx xxx xxx|xxx|xxx|xxx|xxx xxx|xxx|xxx xxx xxx|xxx xxx|xxx|xxx|xxx|xxx|
        +   +---+   +---+---+---+---+---+   +   +   +---+---+---+---+   +---+   +   +---+   +---+---+---+   +---+---+   +---+---+
        |xxx xxx|xxx|xxx|xxx|xxx|xxx xxx|xxx|xxx|xxx|xxx xvx|xxx xxx|xxx|xxx|xxx|xxx|xxx|xxx xxx|xxx|xxx xxx|xxx xxx xxx xxx xxx|
        +   +   +   +   +---+---+---+---+   +   +   +---+   +   +---+   +---+   +   +---+   +   +---+   +   +   +   +---+   +   +
        |xxx|xxx xxx xxx|xxx|xxx|xxx xxx|xxx|xxx xxx|xxx|xxx|xxx|xxx|xxx xxx xxx|xxx xxx|xxx|xxx|xxx xxx xxx xxx|xxx|xxx xxx|xxx|
        +   +---+---+   +   +---+   +---+---+   +---+   +---+   +   +   +   +   +   +---+---+   +   +---+   +   +---+---+---+---+
        |xxx xxx xxx xxx|xxx|xxx xxx|xxx|xxx xxx|xxx xxx|xxx xxx xxx|xxx|xxx xxx|xxx xxx xxx xxx|xxx|xxx|xxx|xxx xxx|xxx|xxx|xxx|
        +   +---+---+---+   +   +   +---+   +---+---+---+---+   +---+   +   +   +   +---+   +---+---+   +---+---+   +---+---+---+
        |xxx|xxx|xxx xxx|xxx|xxx|xxx|xxx xxx|xxx xxx xxx xxx|xxx|xxx xxx xxx|xxx|xxx|xxx xxx|xxx xxx xxx|xxx xxx xxx xxx xxx xxx|
        +   +---+   +---+   +---+---+   +   +   +---+   +   +---+---+---+   +---+   +---+---+   +---+   +---+   +   +---+---+   +
        |xxx|xxx xxx|xxx|xxx xxx xxx xxx xxx|xxx xxx|xxx|xxx xxx|xxx|xxx xxx xxx|xxx xxx xxx xxx|xxx|xxx xxx|xxx|xxx|xxx|xxx xxx|
        +---+   +   +   +   +---+   +   +   +   +---+---+   +---+---+---+   +---+   +---+---+   +---+   +   +   +---+   +   +   +
        |xxx|xxx xxx|xxx|xxx|xxx xxx|xxx xxx xxx|xxx|xxx|xxx|xxx|xxx xxx xxx|xxx xxx xxx xxx|xxx|xxx xxx|xxx|xxx xxx|xxx|xxx xxx|
        +---+   +   +   +---+   +---+---+---+---+---+   +---+---+---+---+---+---+---+   +---+---+   +---+   +   +---+   +   +---+
        |xxx xxx|xxx|xxx|xxx xxx|xxx|xxx|xxx|xxx|xxx xxx|xxx|xxx|xxx|xxx xxx xxx|xxx xxx|xvx xxx xxx|xxx xxx xxx|xxx|xxx xxx xxx|
        +   +---+   +   +---+---+   +   +---+   +---+   +---+   +---+   +---+   +---+   +---+---+   +   +   +   +   +---+   +   +
        |xxx xxx|xxx|xxx xxx xxx|xxx xxx|xxx xxx xxx xxx|xxx|xxx|xxx|xxx|xxx xxx xxx|xxx|xxx|xxx xxx|xxx xxx xxx|xxx|xxx|xxx|xxx|
        +   +---+   +   +   +---+---+---+---+---+---+   +---+---+---+   +---+   +   +   +---+---+---+   +---+   +   +---+   +   +
        |xxx xxx xxx xxx|xxx|xxx xxx|xxx xxx|xxx|xxx|xxx|xxx|xxx|xxx xxx|xxx xxx xxx|xxx|xxx|xxx xxx xxx xxx xxx xxx|xxx xxx|xxx|
        +---+   +   +   +---+   +   +   +   +   +   +---+---+   +   +   +   +   +   +---+---+   +   +   +---+   +   +---+---+---+
        |xxx|xxx xxx|xxx|xxx xxx xxx|xxx xxx xxx xxx xxx|xxx xxx xxx xxx xxx|xxx|xxx|xxx xxx xxx|xxx|xxx xxx xxx xxx xxx|xxx xxx|
        +---+---+   +---+---+---+---+---+---+   +   +   +   +   +---+---+   +   +---+---+---+   +---+   +   +---+   +   +---+   +
        |xxx xxx|xxx xxx|xxx xxx|xxx xxx|xxx xxx|xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx|xxx|xxx|xxx|xxx xxx|xxx xxx|xxx xxx|xxx|
        +   +   +   +   +---+   +---+   +---+---+---+   +   +   +   +   +   +---+   +---+---+   +---+---+   +   +   +---+   +---+
        |xxx xxx|xxx xxx|xxx xxx xxx xxx xxx xxx|xxx|xxx xxx|xxx|xxx|xxx xxx|xxx xxx xxx|xxx xxx|xxx xxx xxx xxx xxx xxx|xxx xxx|
        +---+---+   +---+   +   +   +---+   +   +---+   +---+---+   +   +   +   +   +   +---+---+---+   +---+---+---+   +   +---+
        |xxx xxx|xxx|xxx|xxx|xxx xxx|xxx|xxx|xxx|xxx xxx xxx|xxx xxx|xxx|xxx xxx|xxx xxx xxx xxx|xxx|xxx|xxx xxx xxx|xxx xxx|xxx|
        +---+   +   +   +   +   +   +---+---+---+---+   +---+---+---+   +   +---+---+---+   +   +   +---+---+---+---+   +---+---+
        |xxx xxx xxx|xxx xxx|xxx|xxx xxx|xxx|xxx|xxx|xxx|xxx xxx xxx xxx|xxx xxx xxx|xxx|xxx|xxx xxx xxx|xxx|xxx xxx|xxx|xxx|xxx|
        +   +---+---+---+---+---+---+---+   +---+   +---+---+---+   +   +---+---+---+---+---+---+---+   +   +   +   +   +   +   +
        |xxx|xxx|xxx|xxx|xxx|xxx|xxx|xxx|xxx|xxx xxx|xxx|xxx|xxx xxx xxx xxx xxx|xxx|xxx xxx|xxx xxx|xxx xxx|xxx|xxx|xxx xxx|xxx|
        +   +   +   +   +---+---+---+   +   +---+   +---+---+   +   +---+---+   +---+---+---+   +---+   +---+   +   +   +---+---+
        |xxx|xxx|xxx|xxx|xxx xxx xxx|xxx xxx xxx|xxx|xxx|xxx|xxx|xxx xxx xxx xxx|xxx xxx|xxx xxx xxx|xxx xxx|xxx xxx xxx xxx|xxx|
        +   +   +---+---+   +   +   +---+---+   +---+   +---+   +---+---+---+   +   +---+   +---+---+   +---+---+---+   +   +---+
        |xxx|xxx xxx|xxx xxx|xxx xxx|xxx xxx|xxx|xxx|xxx|xxx|xxx xxx|xxx|xxx xxx xxx xxx|xxx xxx xxx|xxx xxx|xxx xxx xxx xxx xxx|
        +   +---+   +   +   +   +---+---+---+   +---+---+   +   +   +   +---+   +---+---+   +   +---+   +---+   +   +---+---+---+
        |xxx xxx|xxx|xxx xxx|xxx|xxx|xxx|xxx|xxx|xxx xxx xxx xxx xxx|xxx|xxx|xxx|xxx xxx xxx xxx|xxx|xxx xxx xxx xxx|xxx xxx xxx|
        +   +   +---+---+---+---+   +---+---+   +---+---+   +---+   +---+   +---+   +   +---+   +   +---+---+---+---+   +   +   +
        |xxx|xxx|xxx|xxx|xxx xxx xxx xxx|xxx xxx|xxx|xxx xxx|xxx|xxx xxx xxx xxx|xxx xxx|xxx|xxx xxx|xxx xxx xxx xxx|xxx xxx xxx|
        +---+---+   +   +   +   +---+   +---+---+---+   +---+   +   +---+---+   +---+   +---+---+---+---+---+   +---+   +---+   +
        |xxx xxx xxx|xxx xxx xxx xxx|xxx xxx|xxx xxx xxx xxx xxx xxx xxx|xxx|xxx|xxx xxx xxx xxx|xxx xxx xxx|xxx|xxx xxx xxx xxx|
        +---+---+   +   +---+   +   +---+---+   +   +   +   +   +   +   +---+---+---+   +---+---+---+   +   +---+   +---+   +---+
        |xxx|xxx|xxx|xxx xxx|xxx xxx xxx xxx|xxx|xxx|xxx|xxx xxx xxx xxx xxx xxx xxx|xxx xxx|xxx|xxx|xxx xxx|xxx xxx xxx|xxx|xxx|
        +   +   +---+   +---+---+   +   +   +---+---+   +---+---+---+   +   +   +---+   +   +   +---+   +   +   +---+   +   +---+
        |xxx xxx xxx xxx xxx|xxx|xxx|xxx xxx xxx|xxx|xxx|xxx|xxx xxx xxx|xxx|xxx xxx xxx xxx xxx xxx|xxx xxx xxx xxx|xxx|xxx xxx|
        +---+   +   +   +   +---+---+   +---+   +---+---+   +---+   +   +---+---+---+   +   +---+---+---+   +   +   +   +---+---+
        |xvx xxx|xxx xxx xxx xxx|xxx|xxx|xxx|xxx xxx xxx xxx xxx xxx xxx xxx xxx xxx|xxx|xxx|xxx xxx|xxx xxx xxx xxx xxx|xxx|xvx|
        +---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+---+ *)

    let maze = genRandomMaze 30 (Some 1)

    Assert.AreEqual(false, exitExists 0 0 maze)
    Assert.AreEqual(true, exitExists 19 0 maze)
    Assert.AreEqual(true, exitExists 27 1 maze)
    Assert.AreEqual(false, exitExists 27 2 maze)
    Assert.AreEqual(true, exitExists 21 3 maze)
    Assert.AreEqual(false, exitExists 12 7 maze)
    Assert.AreEqual(false, exitExists 0 29 maze)
    Assert.AreEqual(false, exitExists 20 14 maze)
    Assert.AreEqual(false, exitExists 29 29 maze)
