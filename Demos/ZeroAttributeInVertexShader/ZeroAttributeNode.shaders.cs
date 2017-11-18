using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZeroAttributeInVertexShader
{
    partial class ZeroAttributeNode
    {
        private const string vertexShader = @"#version 150 core

out vec2 v_texCoord;
uniform mat4 mvp;

void main(void)
{
	vec4 vertices[4] = vec4[4](vec4(-1.0, -1.0, 0.0, 1.0), vec4(1.0, -1.0, 0.0, 1.0), vec4(-1.0, 1.0, 0.0, 1.0), vec4(1.0, 1.0, 0.0, 1.0));
	vec2 texCoord[4] = vec2[4](vec2(0.0, 0.0), vec2(1.0, 0.0), vec2(0.0, 1.0), vec2(1.0, 1.0));

	v_texCoord = texCoord[gl_VertexID];

	gl_Position = mvp * vertices[gl_VertexID];
}
";
        private const string fragmentShader = @"#version 150 core

uniform sampler2D u_texture; 

in vec2 v_texCoord;

out vec4 fragColor;

void main(void)
{
	//fragColor = texture(u_texture, v_texCoord);
	fragColor = vec4(v_texCoord, v_texCoord.x / 2 + v_texCoord.y / 2, 1.0f);
}
";
    }
}
