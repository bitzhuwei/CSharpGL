using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputeShader.EdgeDetection
{
    partial class EdgeDetectNode
    {

        private const string inPosition = "inPosition";
        private const string inUV = "inUV";
        private const string projectionMat = "projectionMat";
        private const string viewMat = "viewMat";
        private const string modelMatrix = "modelMatrix";
        private const string tex = "tex";
        private const string vertexCode =
            @"#version 330 core

in vec3 " + inPosition + @";
in vec2 " + inUV + @";

uniform mat4 " + projectionMat + @";
uniform mat4 " + viewMat + @";
uniform mat4 " + modelMatrix + @";

out vec2 passUV;

void main(void) {
	gl_Position = projectionMat * viewMat * modelMatrix * vec4(inPosition, 1.0);
	passUV = inUV;
}
";
        private const string fragmentCode =
            @"#version 330 core

in vec2 passUV;

uniform sampler2D " + tex + @";

layout(location = 0) out vec4 outColor;
//out vec4 outColor;

void main(void) {
	outColor = texture(tex, passUV);
}
";

    }
}
