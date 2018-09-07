# CSharpGL
This is the `CSharpGL` library. Compile it and you will get a CSharpGL.dll file.  
`CSharpGL` is the abstract part of any OpenGL initialization projects.
# What's in it?
## Basic data structures
Event, matrix, vector, unmanaged array, bounding box, pixel, etc.
## OpenGL API
abxtract OpenGL API functions because OpenGL is a specification, not a concrete implementation.
## interface of Canvas
Canvas means a `Control` type in WinForm.
## Scene
The world we see.  
THere are objects in 3D world space and GUI widgets in 2D screen space.  
### Camera
Where the camera\eye is.
### GlyphMap
Provides glyphs in a 2D texture array and the uv coordinates. You can get any font's glyph map with `GlyphServer` type provided in CSharpGL.
### GUI
Widgets in 2D screen space, such as CtrlImage, CtrlButton, CtrlLabel etc.
### Lights
Diffrent kinds of lights.
### Manipulaters
Help control how camera or object in 3D world space move\rotate.
### Scene Nodes
Differenct nodes construct a tree data structure, which is the core data of the 3D scene.  
`ModernNode` supports rendering in modern OpenGL.
`PickableNode` supports rendering in modern OpenGL and picking single primitive in the mesh.
### Actions
Diffrenct actions traverse the tree metioned in `Scene Nodes` and generate diffrent results.  
The `TransformAction` updates all nodes' location\direction\scale states. This usually is the first action to run.  
The `RenderAction` renders the tree to canvas. This usually is the last action to run.  
Put multiple actions together in the right order and diffrenct kinds of expected results can be done.
