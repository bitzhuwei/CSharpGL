﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace Lighting.ShadowMapping.InsidePyramid {
    partial class TriangleNode {
        private const string regularVert = @"#version 150

in vec3 inPosition;
in vec3 inColor;

uniform mat4 mvpMat;

out vec3 passColor;

void main() {
    gl_Position = mvpMat * vec4(inPosition, 1.0);
    passColor = inColor;
}
";

        private const string regularFrag = @"#version 150

in vec3 passColor;

out vec4 outColor;

void main() {
    outColor = vec4(passColor, 1.0);
}
";

    }
}
