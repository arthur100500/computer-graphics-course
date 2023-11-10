module Maze

type maze =
    { verticalLines: bool array2d
      horizontalLines: bool array2d
      size: int
      entrypoint: bool * int * int }

val genRandomMaze: int -> int option -> maze

val mazeToAscii: maze -> bool array2d -> string
