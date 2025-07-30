﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c12d01_SliceAndCamera {
    partial class GroundNode {
        private const string vertexCode = @"
#version 150

in vec3 inPosition;
in vec3 inColor;

uniform mat4 mvpMat;

void main() {
    gl_Position = mvpMat * vec4(inPosition, 1.0); 
}
";

        private const string fragmentCode = @"
#version 150

uniform vec3 color = vec3(1.0, 0.843, 0);

out vec4 outColor;

void main() {
    outColor = vec4(color, 1.0);
}
";
    }
}
