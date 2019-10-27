module Minecraft.Abstractions

open Model

// Command should be enriched in the future - Type, relative vs absolute ... etc.
type Command = Command of string
type CommandStream = CommandStream of string

type CommandCompiler = Blocks -> Command list
type CommandFormatter = Command list -> CommandStream

type Writer = CommandStream -> unit IO
