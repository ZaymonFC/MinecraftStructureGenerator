module Writer

open Expecto

open Minecraft
open Minecraft.Model

let tests = testList "Command Writer" [
    testAsync "should create correct command" {
        let block : Block = {
            Coord = { x = 0; y = 0; z = 0 }
            Kind = Cobblestone
            State = None
        }

        let (Abstractions.Command command) = block |> Writer.CommandCompiler.createCommand

        "Setblock command not correct"
        |> Expect.equal command "setblock ~0 ~0 ~0 cobblestone"
    }

    testAsync "should create correct file stream" {
        let blocks : Blocks =
            { Blocks =
                [
                    { Coord = { x = 0; y = 0; z = 0 }
                      Kind = Air
                      State = None }

                    { Coord = { x = 2; y = 2; z = 5 }
                      Kind = Dirt
                      State = None }
                ] }

        let fileStream = blocks |> Writer.CommandCompiler.blocksToFileOutput

        "Command creation did not result in correct file output"
        |> Expect.equal fileStream "setblock ~0 ~0 ~0 air\nsetblock ~2 ~2 ~5 dirt"

    }
]
