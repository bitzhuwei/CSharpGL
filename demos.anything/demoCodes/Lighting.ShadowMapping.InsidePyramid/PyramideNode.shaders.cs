using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace Lighting.ShadowMapping.InsidePyramid {
    partial class PyramideNode {
        private const string regularVert = @"#version 150

in vec3 inPosition;

uniform mat4 mvpMat;

void main() {
    gl_Position = mvpMat * vec4(inPosition, 1.0);
}
";

        private const string regularFrag = @"#version 150

uniform vec3 color = vec3(1, 1, 1);

out vec4 outColor;

void main() {
    outColor = vec4(color, 1.0);
}
";

    }
}
