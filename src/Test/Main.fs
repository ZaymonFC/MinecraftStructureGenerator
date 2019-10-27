module Test

open Expecto


[<Tests>]
let tests = testList "CX-Data-Insights" [
    Tests.tests
]

[<EntryPoint>]
let main argv =
    printfn "Running tests!"
    let config =
        { defaultConfig with
            verbosity = Logging.LogLevel.Verbose
            colour = Logging.Colour256
        }

    runTestsWithArgs config argv tests