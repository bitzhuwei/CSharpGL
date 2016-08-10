# Renderer Generator
RendererGenerator is a simple console that reads an xml config file and dumps a Renderer.cs, a Model.cs, a vertex shader file(.vert) and a fragment shader file(.frag).
A demo is shown as below:
```
<?xml version="1.0" encoding="utf-8"?>
<rendererGenerator TargetName="Demo" ZeroIndexBuffer="false" DrawMode="Points">
  <VertexProperty NameInShader="in_Position" NameInModel="position" PropertyType="CSharpGL.vec3" />
</rendererGenerator>
```
## TargetName
any identifier that you like(just make sure it's a valid identifier in C#). This name specifies what you want to render.
## ZeroIndexBuffer
If true, this console will dump a Model.cs which uses ZeroIndexBuffer; otherwise, it well dump a Model.cs which uses OneIndexBuffer<>.  
So how to decide? It's easy: set it to `true` if you are using `glDrawArrays()`; set it to `fase` if you are using `glDrawElements()``.
## DrawMode
Options are one of these in DrawMode.
```
public enum DrawMode : uint
{
    Points = OpenGL.GL_POINTS,
    LineStrip = OpenGL.GL_LINE_STRIP,
    LineLoop = OpenGL.GL_LINE_LOOP,
    Lines = OpenGL.GL_LINES,
    LineStripAdjacency = OpenGL.GL_LINE_STRIP_ADJACENCY,
    LinesAdjacency = OpenGL.GL_LINES_ADJACENCY,
    TriangleStrip = OpenGL.GL_TRIANGLE_STRIP,
    TriangleFan = OpenGL.GL_TRIANGLE_FAN,
    Triangles = OpenGL.GL_TRIANGLES,
    TriangleStripAdjacency = OpenGL.GL_TRIANGLE_STRIP_ADJACENCY,
    TrianglesAdjacency = OpenGL.GL_TRIANGLES_ADJACENCY,
    Patches = OpenGL.GL_PATCHES,
    QuadStrip = OpenGL.GL_QUAD_STRIP,
    Quads = OpenGL.GL_QUADS,
    Polygon = OpenGL.GL_POLYGON,
}
```
## VertexProperty
A VertexProperty is an array that describes model's position, color, normal or any other stuff you need.  
There could be more than 1 VertexProperty element in `rendererGenerator`'s sub-node.
### NameInShader
NameInShader is the variable's name in GLSL vertex shader.
```
in vec3 in_Position;
```
### NameInModel
NameInModel is the name in `IBufferable` corresponding to the name in GLSL shader.
For example, `position` maps to `in_position` in vertex shader shown above.
### PropertyType
It's strightforward to understand that PropertyType means variable's type in GLSL shader and `IBufferable`.
# Why bother?
I forgot to assign the result to the `indexBufferPtr` in `IBufferable`'s `GetIndex()` method today, and it took me hours of debugging to find out this annoying mistake.  
Thus I decided to write this tiny generator to help dumping framework of all future renderer types that derives from `CSharpGL.Renderer`.  

