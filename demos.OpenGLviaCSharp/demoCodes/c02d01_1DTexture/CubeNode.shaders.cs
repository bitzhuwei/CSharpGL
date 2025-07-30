using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c02d01_1DTexture {
    partial class CubeNode {
        private const string vertexCode = @"
#version 150

in vec3 inPosition;

uniform mat4 mvpMatrix;

out vec3 passPos;

void main() {
    gl_Position = mvpMatrix * vec4(inPosition, 1.0); 

    passPos = inPosition;
}
";

        private const string fragmentCode = @"
#version 150

//uniform vec4 color = vec4(1, 0, 0, 1); // default: red color.
uniform sampler1D tex;

in vec3 passPos;

out vec4 outColor;

void main() {
    float passTexCoord = (sqrt(passPos.x * passPos.x + passPos.y * passPos.y + passPos.z * passPos.z) - 0.5) / (sqrt(0.5 * 0.5 * 3) - 0.5);
    outColor = texture(tex, passTexCoord);
}
";
    }
}
