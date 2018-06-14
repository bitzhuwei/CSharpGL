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
out float outLine;

uniform mat4 mvpMat;
uniform vec3 outMouseDownPosition;
uniform vec3 inMouseDownPosition;
uniform vec3 inMouseMovePosition;
uniform vec3 outMouseMovePosition;

void main() {
    passColor = inColor;
    outLine = 0;
    int id = gl_VertexID;
    if (id == 0) {
        gl_Position = mvpMat * vec4(outMouseDownPosition, 1.0);
        outLine = 1;
    }
    else if (id == 1) {
        gl_Position = mvpMat * vec4(outMouseDownPosition.x, 0, outMouseDownPosition.z, 1.0);
        outLine = 1;
    }
    else if (id == 2) {
        gl_Position = mvpMat * vec4(inMouseDownPosition, 1.0);
    }
    else if (id == 3) {
        gl_Position = mvpMat * vec4(inMouseDownPosition.x, 0, inMouseDownPosition.z, 1.0);
    }
    else if (id == 4) {
        gl_Position = mvpMat * vec4(outMouseMovePosition.x, 0, outMouseMovePosition.z, 1.0);
        outLine = 1;
    }
    else if (id == 5) {
        gl_Position = mvpMat * vec4(outMouseMovePosition, 1.0);
        outLine = 1;
    }
    else if (id == 6) {
        gl_Position = mvpMat * vec4(inMouseMovePosition.x, 0, inMouseMovePosition.z, 1.0);
    }
    else if (id == 7) {
        gl_Position = mvpMat * vec4(inMouseMovePosition, 1.0);
    }
    else { // NOTE: this should not happen.
        gl_Position = mvpMat * vec4(0.0, 0.0, 0.0, 1.0);
    }
}
";

        private const string fragmentCode = @"#version 150

in vec3 passColor;
in float outLine;

out vec4 fragColor;

void main() {
    if (outLine > 0) {
        //if (int(gl_FragCoord.x + gl_FragCoord.y) % 2 == 1) discard;
    }

	fragColor = vec4(passColor, 1.0);
}
";

    }
}
