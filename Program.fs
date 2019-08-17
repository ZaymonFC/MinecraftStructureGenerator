
module Minecraft =
    type Coord = { x: int; y: int; z: int }

    type Kind =
        | Cobblestone
        | Air
        | Dirt
    with
        override this.ToString () =
            match this with
            | Cobblestone -> "cobblestone"
            | Air -> "air"
            | Dirt -> "dirt"

    type State = string

    type Block = {
        Coord :Coord
        Kind  :Kind
        State :State option
    }

    type Blocks = { UnBlocks: Block list }

    let mapBlocks : (Block -> Block) -> Blocks -> Blocks = fun f blocks ->
        { UnBlocks = blocks.UnBlocks |> List.map f }

    let makeBlocks : Coord list -> Kind -> Block list = fun coords kind ->
        coords |> List.map (fun x -> { Coord = x; Kind = kind; State = None })

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    0 // return an integer exit code
