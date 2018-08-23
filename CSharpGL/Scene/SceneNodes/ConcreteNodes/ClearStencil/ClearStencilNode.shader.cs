using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace CSharpGL
{
    partial class ClearStencilNode
    {
        private const string vertexCode =
            @"#version 150 core

const float value = 1;

void main(void) {
	vec2 vertexes[4] = vec2[4](vec2(value, value), vec2(-value, value), vec2(-value, -value), vec2(value, -value));
	vec2 texCoord[4] = vec2[4](vec2(1.0, 1.0), vec2(0.0, 1.0), vec2(0.0, 0.0), vec2(1.0, 0.0));

    vec2 diffPos = vertexes[gl_VertexID];
	gl_Position = vec4(diffPos, 0, 1);
}
";
        private const string fragmentCode =
            @"#version 150 core

out vec4 outColor;

void main(void) {
    outColor = vec4(0, 0, 0, 0);
}
";
    }
}
