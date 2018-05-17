using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace c03d05_WindowSpace
{
    partial class RectNode
    {
        private const string vertexCode = @"#version 150 core

in vec2 inPosition;
in vec3 inColor;

out vec3 passColor;

void main(void) {
    gl_Position = vec4(inPosition, 0.0, 1.0);
    passColor = inColor;
}

";
        private const string fragmentCode = @"#version 150

in vec3 passColor;

out vec4 out_Color;

void main(void) {
	out_Color = vec4(passColor, 1.0);
}
";
    }
}
