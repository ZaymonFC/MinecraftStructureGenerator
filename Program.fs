
module Minecraft =
    type Coord = { x: int; y: int; z: int }

    type State = string

    type Block = {
        Coord :Coord
        Kind  :string
        State :State option
    }

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    0 // return an integer exit code
