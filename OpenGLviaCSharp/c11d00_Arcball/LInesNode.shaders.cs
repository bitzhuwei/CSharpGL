using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace c11d00_Arcball
{
    partial class LinesNode
    {
        private const string vertexCode = @"#version 150

//in vec3 inPosition;
in vec3 inColor;

out vec3 passColor;

uniform mat4 mvpMat;
uniform vec3 mouseDownPosition;
uniform vec3 mouseMovePosition;

void main() {
    passColor = inColor;

    if (gl_VertexID == 0) {
        gl_Position = mvpMat * vec4(mouseDownPosition, 1.0);
    }
    else if (gl_VertexID == 1) {
        gl_Position = mvpMat * vec4(mouseDownPosition.x, 0, mouseDownPosition.z, 1.0);
    }
    else if (gl_VertexID == 2) {
        gl_Position = mvpMat * vec4(mouseMovePosition.x, 0, mouseMovePosition.z, 1.0);
    }
    else if (gl_VertexID == 3) {
        gl_Position = mvpMat * vec4(mouseMovePosition, 1.0);
    }
    else { // NOTE: this should not happen.
        gl_Position = mvpMat * vec4(0.0, 0.0, 0.0, 1.0);
    }
}
";

        private const string fragmentCode = @"#version 150

in vec3 passColor;

out vec4 fragColor;

void main() {
	fragColor = vec4(passColor, 1.0);
}
";

    }
}
