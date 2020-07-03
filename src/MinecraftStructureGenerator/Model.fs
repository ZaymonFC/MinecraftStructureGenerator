module Minecraft.Model

type Coord = { x: int; y: int; z: int }
let inline _x f { x = a; y = b; z = c } = f a <&> fun a' -> { x = a'; y = b;  z = c }
let inline _y f { x = a; y = b; z = c } = f b <&> fun b' -> { x = a;  y = b'; z = c }
let inline _z f { x = a; y = b; z = c } = f c <&> fun c' -> { x = a;  y = b;  z = c' }

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
type Block =
    {
        Coord :Coord
        Kind  :Kind
        State :State option
    }
let inline _coord f { Coord = a; Kind = b; State = c } = f a <&> fun a' -> { Coord = a'; Kind = b;  State = c  }
let inline _kind  f { Coord = a; Kind = b; State = c } = f b <&> fun b' -> { Coord = a;  Kind = b'; State = c  }
let inline _state f { Coord = a; Kind = b; State = c } = f c <&> fun c' -> { Coord = a;  Kind = b;  State = c' }

type Blocks = { Blocks: Block list }
let inline blocks b = b.Blocks

module Blocks =
    let zero : unit -> Blocks = fun _ ->
        { Blocks = [{ Coord = { x = 0; y = 0; z = 0; }; Kind = Air; State = None }]}

    let mapBlocks : (Block -> Block) -> Blocks -> Blocks = fun f blocks ->
        { Blocks = blocks.Blocks |> List.map f }

    let makeBlocks : Coord list -> Kind -> Block list = fun coords kind ->
        coords |> List.map (fun x -> { Coord = x; Kind = kind; State = None })
