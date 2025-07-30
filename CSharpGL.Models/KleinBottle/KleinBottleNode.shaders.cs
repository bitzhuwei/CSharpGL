﻿using System.Drawing;
using System.IO;

namespace CSharpGL {
    /// <summary>
    /// Klein bottle.
    /// </summary>
    partial class KleinBottleNode {
        private const string vertexShaderCode = @"#version 150 core

in vec3 inPosition;
in float inTexCoord;

out float passTexCoord;

uniform mat4 projectionMat;
uniform mat4 viewMat;
uniform mat4 modelMat;

void main(void) {
	gl_Position = projectionMat * viewMat * modelMat * vec4(inPosition, 1.0);

	passTexCoord = inTexCoord;
}
";
        private const string fragmentShaderCode = @"#version 150 core

in float passTexCoord;

uniform sampler1D tex;

out vec4 outColor;

void main(void) {
	outColor = texture(tex, passTexCoord);
}
";
    }
}
