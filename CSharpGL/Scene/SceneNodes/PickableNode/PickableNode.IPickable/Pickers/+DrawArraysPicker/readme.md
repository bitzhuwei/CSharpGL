# `DrawArraysPicker`
Perform picking action for `PickableNode` with `DrawArraysCmd` or `MultiDrawArraysCmd`.
The folder name `+DrawArraysPicker` starts with a `+` because it also supports `Multi` version of `glDrawArrays()`.
I don't know what will happen during picking if 'overlap' exists in glMultiDrawArrays(..). I don't care either, because that is a problem that should be solved in modeling stage.
