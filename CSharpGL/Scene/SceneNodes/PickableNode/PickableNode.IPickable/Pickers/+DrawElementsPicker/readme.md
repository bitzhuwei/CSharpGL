# `DrawElementsPicker`
Perform picking action for `PickableNode` with `DrawElementsCmd` or `MultiDrawElementsCmd`.
The folder name `+DrawElementsPicker` starts with a `+` because it also supports `Multi` version of `glDrawElements()`.
I don't know what will happen during picking if 'overlap' exists in glMultiDrawElements(..). I don't care either, because that is a problem that should be solved in modeling stage.
