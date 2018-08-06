using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace c15d00_InverseColor
{
    partial class ComputeShaderNode
    {

        private const string inPosition = "inPosition";
        private const string inUV = "inUV";
        private const string projectionMatrix = "projectionMatrix";
        private const string viewMatrix = "viewMatrix";
        private const string modelMatrix = "modelMatrix";
        private const string tex = "tex";
        private const string vertexCode =
            @"#version 330 core

in vec3 " + inPosition + @";
in vec2 " + inUV + @";

uniform mat4 " + projectionMatrix + @";
uniform mat4 " + viewMatrix + @";
uniform mat4 " + modelMatrix + @";

out vec2 passUV;

void main(void) {
	gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(inPosition, 1.0);
	passUV = inUV;
}
";
        private const string fragmentCode =
            @"#version 330 core

in vec2 passUV;

uniform sampler2D " + tex + @";

layout(location = 0) out vec4 out_Color;
//out vec4 out_Color;

void main(void) {
	out_Color = texture(tex, passUV);
}
";

    }
}
