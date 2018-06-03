using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c11d00_Arcball
{
    public partial class HalfSphereNode
    {
        private const string inPosition = "inPosition";
        private const string mvpMatrix = "mvpMatrix";
        private const string vertexCode =
            @"#version 330 core

in vec3 " + inPosition + @";

uniform mat4 " + mvpMatrix + @";

out vec3 passColor;

void main(void) {
	gl_Position = mvpMatrix * vec4(inPosition, 1.0);
}
";
        //if (inColor.x >= 0) { color.x = inColor.x; } else { color.x = -inColor.x / 2.0; }
        //if (inColor.y >= 0) { color.y = inColor.y; } else { color.y = -inColor.y / 2.0; }
        //if (inColor.z >= 0) { color.z = inColor.z; } else { color.z = -inColor.z / 2.0; }
        private const string fragmentCode =
            @"#version 330 core

uniform vec3 color = vec3(1, 1, 1);

out vec4 out_Color;

void main(void) {
	 out_Color = vec4(color, 1.0);
}
";
    }
}
