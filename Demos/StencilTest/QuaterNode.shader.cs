﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace StencilTest
{
    partial class QuaterNode
    {
        private const string vertexCode =
            @"#version 330 core

const float value = 1;

void main(void) {
	vec2 vertexes[4] = vec2[4](vec2(value, value), vec2(-value, value), vec2(-value, -value), vec2(value, -value));
	vec2 texCoord[4] = vec2[4](vec2(1.0, 1.0), vec2(0.0, 1.0), vec2(0.0, 0.0), vec2(1.0, 0.0));

    vec2 diffPos = vertexes[gl_VertexID];
	gl_Position = vec4(diffPos / 2, 0, 1);
}
";
        private const string fragmentCode =
            @"#version 330 core

out vec4 out_Color;

void main(void) {
    out_Color = vec4(1, 1, 1, 1);
}
";
    }
}
