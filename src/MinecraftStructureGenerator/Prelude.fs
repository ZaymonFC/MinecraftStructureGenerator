[<AutoOpen>]
module Minecraft.Prelude
// This module exposes constructs within all Minecraft.* modules

type IO<'t> = IO of 't
type AsyncIO<'t> = Async<'t>
