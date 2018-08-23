using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace c08d01_PickPoint
{
    partial class PointsNode
    {

        private const string randomVert = @"#version 150 core

in vec3 inPosition;
in vec3 inColor;

uniform mat4 mvpMatrix;
uniform int highlightIndex = -1;

out vec3 passColor;

void main(void) {
    // transform vertex' position from model space to clip space.
    gl_Position = mvpMatrix * vec4(inPosition, 1.0);

    if (highlightIndex == gl_VertexID) {
        passColor = vec3(1, 1, 1);
        gl_PointSize = 14;
    }
    else {
        gl_PointSize = 7;
        passColor = inColor;
    }
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
out vec4 passColor;
uniform mat4 mvpMatrix;
uniform int highlightIndex = -1;

void main(void) {
    // transform vertex' position from model space to clip space.
    gl_Position = mvpMatrix * vec4(inPosition, 1.0);

    if (highlightIndex == gl_VertexID) {
        gl_PointSize = 14;
        passColor = vec4(1, 1, 1, 1);
    }
    else {
        gl_PointSize = 7;
        // gets color value according to gl_VertexID.
        int index = gl_VertexID;
        passColor = vec4(
            float(index & 0xFF) / 255.0, 
            float((index >> 8) & 0xFF) / 255.0, 
            float((index >> 16) & 0xFF) / 255.0, 
            float((index >> 24) & 0xFF) / 255.0);
    }
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
