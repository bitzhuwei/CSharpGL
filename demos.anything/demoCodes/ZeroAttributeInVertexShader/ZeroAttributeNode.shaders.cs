﻿using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZeroAttributeInVertexShader {
    partial class ZeroAttributeNode {
        private const string vertexShader = @"#version 150 core

out vec2 passTexCoord;
uniform mat4 mvp;

void main(void)
{
	vec4 vertices[4] = vec4[4](vec4(-1.0, -1.0, 0.0, 1.0), vec4(1.0, -1.0, 0.0, 1.0), vec4(-1.0, 1.0, 0.0, 1.0), vec4(1.0, 1.0, 0.0, 1.0));
	vec2 texCoord[4] = vec2[4](vec2(0.0, 0.0), vec2(1.0, 0.0), vec2(0.0, 1.0), vec2(1.0, 1.0));

	passTexCoord = texCoord[gl_VertexID];

	gl_Position = mvp * vertices[gl_VertexID];
}
";
        private const string fragmentShader = @"#version 150 core

uniform sampler2D tex; 

in vec2 passTexCoord;

out vec4 outColor;

void main(void)
{
	//outColor = texture(tex, passTexCoord);
	outColor = vec4(passTexCoord, passTexCoord.x / 2 + passTexCoord.y / 2, 1.0f);
}
";
    }
}
