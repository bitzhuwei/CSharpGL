using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace c09d00_FullScreenQuad
{
    partial class FullScreenNode
    {

        private const string vertexCode = @"#version 150 core

in vec3 inPosition;
in vec2 inUV;

out vec2 passUV;

void main(void) {
    gl_Position = vec4(inPosition, 1.0);
    passUV = inUV;
}

";
        private const string fragmentCode = @"#version 150

in vec2 passUV;

uniform sampler2D tex;

out vec4 out_Color;

void main(void) {
	out_Color = texture(tex, passUV);
}
";

    }

}
