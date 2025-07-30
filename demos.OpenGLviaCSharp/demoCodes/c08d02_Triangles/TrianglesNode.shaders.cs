using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace c08d02_Triangles {
    partial class TrianglesNode {

        private const string randomVert = @"#version 150 core

in vec3 inPosition;
in vec3 inColor;

uniform mat4 mvpMat;

out vec3 passColor;

void main(void) {
    // transform vertex' position from model space to clip space.
    gl_Position = mvpMat * vec4(inPosition, 1.0);

    passColor = inColor;
}

";
        private const string randomFrag = @"#version 150

in vec3 passColor;

out vec4 outColor;

void main(void) {
	outColor = vec4(passColor, 1.0);
}
";
        private const string gl_VertexIDVert = @"// vertex shader that gets color value according to gl_VertexID.
#version 150 core

in vec3 inPosition;

uniform mat4 mvpMat;

out vec4 passColor;

void main(void) {
    // transform vertex' position from model space to clip space.
    gl_Position = mvpMat * vec4(inPosition, 1.0);

    // gets color value according to gl_VertexID.
    int index = gl_VertexID;
    passColor = vec4(
        float(index & 0xFF) / 255.0, 
        float((index >> 8) & 0xFF) / 255.0, 
        float((index >> 16) & 0xFF) / 255.0, 
        float((index >> 24) & 0xFF) / 255.0);
}
";
        private const string gl_VertexIDFrag = @"#version 150

in vec4 passColor;

out vec4 outColor;

void main(void) {
	outColor = passColor;
}
";

    }

}
