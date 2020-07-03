[<AutoOpen>]
module Minecraft.Prelude

type 't IO = 't Async

module String =
    let lines delimeter (s: string) : string list =
        s.Split(delimeter |> Array.singleton) |> List.ofArray

    let unlines =
        List.reduce (fun (s1: string) (s2: string) -> sprintf "%s\n%s" s1 s2)

module File =
    /// Expose an Async Wrapped version of System.IO.File.WriteAllATextAsync
    let writeAsync filePath contents : unit IO =
        System.IO.File.WriteAllTextAsync(filePath, contents, System.Text.Encoding.UTF8)
        |> Async.AwaitTask
