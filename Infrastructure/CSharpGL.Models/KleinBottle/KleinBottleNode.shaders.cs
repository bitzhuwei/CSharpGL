using System.Drawing;
using System.IO;

namespace CSharpGL
{
    /// <summary>
    /// Klein bottle.
    /// </summary>
    partial class KleinBottleNode
    {
        private const string vertexShaderCode = @"#version 150 core

in vec3 inPosition;
in float in_TexCoord;

out float passTexCoord;

uniform mat4 projectionMatrix;
uniform mat4 viewMatrix;
uniform mat4 modelMatrix;

void main(void) {
	gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(inPosition, 1.0);

	passTexCoord = in_TexCoord;
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
