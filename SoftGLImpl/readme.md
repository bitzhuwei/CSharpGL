# soft implementation of openGL in C#

## SoftGLImpl

- openGL API functions are wrapped in `SoftGL` like `SoftGL.glGenBuffers(GLsizei n, GLuint* names);`

- platform-specific functions

`IntPtr GetProcAddress(string procName);` `IntPtr CreateContext(IntPtr windowHandle, int width, int height, object genParams, HashSet<string>? config)` `void MakeCurrent(IntPtr hDC, IntPtr hRC)` `void DeleteContext(IntPtr hRC)` etc.

## GLObjectsImpl

openGL objects(buffer/shader/texture etc.)

## GLSL*

transform GLSL code to C# code.
```csharp
var parser = new ShaderParser();
string source = File.ReadAllText("blinnphong.vert");
List<Token> tokens = parser.Analyze(source);
SyntaxTree tree = parser.Parse(tokens, source);
var translation_unit = parser.Extract(tree, tokens, source);
var builder = new StringBuilder();
using (var writer = new StringWriter(builder)) {
    var config = new BlankConfig(inlineBlank: 0, forceNewline: false);
    var context = new FormatContext(tabUnit: 4, tabCount: 0, tokens);
    translation_unit.FullFormat(config, writer, context);
}
var csCode = builder.ToString();
```

## ShadingLanguage

base types for GLSL in C#.


# how openGL works

```csharp
// init
// shaders
uint programId = glCreateProgram();
uint shaderId = glCreateShader(shaderType);
glShaderSource(shaderId, 1, new[] { source }, new[] { source.Length });
glCompileShader(shaderId);
glGetShaderiv(shaderId, GL.GL_COMPILE_STATUS, parameters);
glAttachShader(programId, item.ShaderId);
glLinkProgram(programId);
glGetProgramiv(programId, GL.GL_LINK_STATUS, parameters);
// buffers
glGenBuffers(1, ids);
glBindBuffer(target, ids[0]);
glBufferData(target, array.ByteLength, array.Header, (uint)usage);
glBindBuffer(target, 0);
glGenBuffers(1, ids);
glBindBuffer(target, ids[0]);
glBufferData(target, array.ByteLength, array.Header, (uint)usage);
glBindBuffer(target, 0);
// vao
glGenVertexArrays(1, ids);
glBindVertexArray(this.Id); // this vertex array object will record all stand-by actions.
location = glGetAttribLocation(this.ProgramId, attributeName);
glBindBuffer(GL.GL_ARRAY_BUFFER, this.BufferId);
glVertexAttribPointer(loc + i, detail.dataSize, detail.dataType, false, detail.stride, new IntPtr(i * detail.startOffsetUnit));
glEnableVertexAttribArray(loc + i);
glBindBuffer(GL.GL_ARRAY_BUFFER, 0);
glBindVertexArray(0); // this vertex array object has recorded all stand-by actions.

// render: program + vao + glDrawElements/glDrawArrays
glUseProgram(this.ProgramId);
location = glGetUniformLocation(this.ProgramId, uniformName);
glUniformMatrix4fv(location, m.Length / 16, false, m);
glBindVertexArray(this.Id);
glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, indexBuffer.BufferId);
    glDrawElements(mode, count, type, indices);
glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, 0);
glBindVertexArray(0);
glUseProgram(0);
```
