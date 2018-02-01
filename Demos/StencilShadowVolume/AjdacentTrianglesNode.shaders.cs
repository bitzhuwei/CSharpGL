using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lighting.ShadowVolume
{
    partial class AjdacentTrianglesNode
    {

        private const string vertexCode = @"#version 330

in vec3 inPosition;
in vec3 inColor;

uniform mat4 mvpMat;

out vec3 passColor;

void main(void) {
	gl_Position = mvpMat * vec4(inPosition, 1.0);
    passColor = inColor;
}
";
        private const string fragmentCode = @"#version 330

in vec3 passColor;

out vec4 out_Color;

void main(void) {
	out_Color = vec4(passColor, 1.0);
}
";
    }
}
