﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace Accumulation {
    partial class AccumulationNode {
        private const string renderVert = @"#version 150 core

in vec3 inPosition;
in vec3 inColor;

uniform mat4 projectionMat;
uniform mat4 viewMat;
uniform mat4 modelMat;

out vec3 passColor;

void main(void) {
	gl_Position = projectionMat * viewMat * modelMat * vec4(inPosition, 1.0);
    passColor = inColor;
}
";
        private const string renderFrag = @"#version 150 core

in vec3 passColor;

out vec4 outColor;

void main(void)
{
    outColor = vec4(passColor, 0.1);
}
";
    }
}
