using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace TessellatedTriangle
{
    partial class TrianglePatchNode
    {
        private const string vertexCode = @"
#version 410 core

void main() {
    const vec4 vertices[] = vec4[](
        vec4( 0.25, -0.25, 0.5, 1.0),
        vec4(-0.25, -0.25, 0.5, 1.0),
        vec4( 0.25,  0.25, 0.5, 1.0));
    gl_Position = vertices[gl_VertexID];
}
";

        private const string tessellationControlCode = @"
#version 410 core

layout (vertices = 3) out;

void main()
{
    if (gl_InvocationID == 0)
    {
        gl_TessLevelInner[0] = 5.0;
        gl_TessLevelOuter[0] = 5.0;
        gl_TessLevelOuter[1] = 5.0;
        gl_TessLevelOuter[2] = 5.0;
    }

    gl_out[gl_InvocationID].gl_Position = gl_in[gl_InvocationID].gl_Position;
}
";

        private const string tessellationEvaluationCode = @"
#version 410 core

layout (triangles, equal_spacing, cw) in;  

void main()
{
    gl_Position = (gl_TessCoord.x * gl_in[0].gl_Position) +
        (gl_TessCoord.y * gl_in[1].gl_Position) +
        (gl_TessCoord.z * gl_in[2].gl_Position);
}
";

        private const string fragmentCode = @"
#version 410 core

uniform vec4 color = vec4(1, 0, 0, 1); // default: red color.

out vec4 outColor;

void main() {
    outColor = color; // fill the fragment with specified color.
}
";
    }
}
