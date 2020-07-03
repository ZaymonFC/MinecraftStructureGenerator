module Minecraft.Abstractions

open Model

// Command should be enriched in the future - Type, relative vs absolute ... etc.
type Command = Command of string
let unCommand (Command c) = c

type CommandStream = Command list

type Commandify = Block -> Command
type Streamify = Command -> CommandStream

type CommandFile = string

type Writer = CommandStream -> unit Async
