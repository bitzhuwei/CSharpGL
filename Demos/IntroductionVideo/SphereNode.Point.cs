using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntroductionVideo {
    public partial class SphereNode {
        private const string vsPoint =
            @"#version 330 core

in vec3 inPosition;

uniform mat4 projectionMatrix;
uniform mat4 viewMatrix;
uniform mat4 modelMatrix;

void main(void) {
	gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(inPosition, 1.0);
}
";
        private const string fsPoint =
            @"#version 330 core

uniform vec3 color = vec3(1, 1, 1);

layout(location = 0) out vec4 outColor;
//out vec4 outColor;

void main(void) {
    outColor = vec4(color, 1);
}
";
    }
}

