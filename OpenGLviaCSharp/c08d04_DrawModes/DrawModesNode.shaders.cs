using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace c08d04_DrawModes
{
    partial class DrawModesNode
    {

        private const string vertexCode = @"#version 150 core

in vec3 inPosition;
in vec3 inColor;

uniform mat4 mvpMatrix;

out vec3 passColor;

void main(void) {
    // transform vertex' position from model space to clip space.
    gl_Position = mvpMatrix * vec4(inPosition, 1.0);

    passColor = inColor;

    gl_PointSize = 15;
}

";
        private const string fragmentCode = @"#version 150

in vec3 passColor;

out vec4 out_Color;

void main(void) {
	out_Color = vec4(passColor, 1.0);
}
";

        private const string flatVertexCode = @"#version 150 core

in vec3 inPosition;
in vec3 inColor;

uniform mat4 mvpMatrix;

flat out vec3 passColor;

void main(void) {
    // transform vertex' position from model space to clip space.
    gl_Position = mvpMatrix * vec4(inPosition, 1.0);

    passColor = inColor;

    gl_PointSize = 15;
}

";
        private const string flatFragmentCode = @"#version 150

flat in vec3 passColor;

out vec4 out_Color;

void main(void) {
	out_Color = vec4(passColor, 1.0);
}
";
    }

}
