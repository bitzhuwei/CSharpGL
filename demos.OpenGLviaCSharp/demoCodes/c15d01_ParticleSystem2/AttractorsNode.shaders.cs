﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c15d01_ParticleSystem2 {
    partial class AttractorsNode {
        private const string vertexCode = @"#version 150 core

in vec3 inPosition;
in vec3 inColor;

uniform mat4 mvp;

out vec3 passColor;

void main(void)
{
    gl_Position = mvp * vec4(inPosition, 1.0);

    passColor = inColor;
}
";

        private const string fragmentCode = @"#version 150 core

out vec4 color;

in vec3 passColor;

void main(void)
{
    color = vec4(passColor, 1.0);
}
";
    }
}
