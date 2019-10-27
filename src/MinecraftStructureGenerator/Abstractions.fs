module Minecraft.Abstractions

open Model

// Command should be enriched in the future - Type, relative vs absolute ... etc.
type Command = Command of string
type CommandStream = CommandStream of string

type ICommandCompiler = Blocks -> Command list
type ICommandFormatter = Command list -> CommandStream

type IWriter = CommandStream -> unit IO
