module Minecraft.Writer

open Abstractions
open Model
open Prelude
open FSharpPlus

// This modules purpose is to take a collection of blocks and write the corresponding
// .mcfunction file to place those blocks into the minecraft world

// setblock x y z type

module CommandCompiler =
    let createCommand : Commandify =
        fun block ->
            sprintf "setblock ~%d ~%d ~%d %s"
                block.Coord.x
                block.Coord.y
                block.Coord.z
                (block.Kind |> string)
            |> Command
    let blocksToCommandStream = (List.map createCommand) << blocks
    let formatForFile = String.unlines << (map unCommand)

    let blocksToFileOutput = formatForFile << blocksToCommandStream

    let writeCommands (filePath: string) (c: CommandStream) : unit Async =
        async { return () }
