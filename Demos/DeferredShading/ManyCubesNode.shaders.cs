using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace DeferredShading
{
    partial class ManyCubesNode
    {
        private const string firstPassVert = @"#version 330 core

in vec3 vPosition; // per-vertex position
in vec3 vColor; // per-vertex normal

uniform mat4 MVP; // combined model view projection matrix

out vec3 passColor;

void main()
{
	gl_Position = MVP * vec4(vPosition, 1);
    passColor = vColor;
}
";
        private const string firstPassFrag = @"#version 330 core

in vec3 passColor;

layout (location = 0) out vec3 vFragColor;

void main()
{
    vFragColor = passColor;
}
";

        private const string secondPassVert = @"#version 330 core

in vec2 texCoord;

out vec2 passTexCoord;

const float value = 1;

void main(void) {
	vec2 vertexes[4] = vec2[4](vec2(value, value), vec2(-value, value), vec2(-value, -value), vec2(value, -value));
	vec2 texCoord[4] = vec2[4](vec2(1.0, 1.0), vec2(0.0, 1.0), vec2(0.0, 0.0), vec2(1.0, 0.0));
    gl_Position = vec4(vertexes[gl_VertexID], 0, 1);

    passTexCoord = texCoord;
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
