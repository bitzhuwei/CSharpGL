using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace DeferredShading
{
    partial class FullScreenNode
    {

        private const string secondPassVert = @"#version 330 core

out vec2 passTexCoord;

const float value = 1;

void main(void) {
	vec2 vertexes[4] = vec2[4](vec2(value, value), vec2(-value, value), vec2(-value, -value), vec2(value, -value));
	vec2 texCoord[4] = vec2[4](vec2(1.0, 1.0), vec2(0.0, 1.0), vec2(0.0, 0.0), vec2(1.0, 0.0));
    gl_Position = vec4(vertexes[gl_VertexID], 0, 1);

    passTexCoord = texCoord[gl_VertexID];
}
";


        private const string secondPassFrag = @"#version 330 core

uniform sampler2D colorSampler;

in vec2 passTexCoord;

out vec4 vFragColor;

void main(void) {
    vFragColor = texture(colorSampler, passTexCoord);
}
";

    }
}
