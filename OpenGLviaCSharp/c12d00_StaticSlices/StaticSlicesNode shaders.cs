using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace c12d00_StaticSlices
{
    partial class StaticSlicesNode
    {
        private const string vertexCode = @"#version 150

in vec3 inPosition;
in vec3 inTexCoord;

out vec3 passTexCoord;

uniform mat4 mvpMat;

void main() {
    gl_Position = mvpMat * vec4(inPosition, 1.0);
    passTexCoord = inTexCoord;
}
";

        private const string fragmentCode = @"#version 150

in vec3 passTexCoord;

uniform sampler1D tex1D;
uniform sampler3D tex3D;

out vec4 fragColor;

void main() {
	float p = texture(tex3D, passTexCoord).r;
    fragColor = texture(tex1D, p);
}
";
    }
}
