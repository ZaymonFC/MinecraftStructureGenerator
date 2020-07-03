[<AutoOpen>]
module Minecraft.Prelude

type 't IO = 't Async

module String =
    let lines delimeter (s: string) : string list =
        s.Split(delimeter |> Array.singleton) |> List.ofArray

    let unlines =
        List.reduce (fun (s1: string) (s2: string) -> sprintf "%s\n%s" s1 s2)
