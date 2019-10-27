module Tests

open Expecto
open Expecto.Flip

let tests = testList "Tests" [
    testAsync "should pass" {
        true |> Expect.isTrue "Should be true"
    }
]
