using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c02d02_MultipleTextures
{
    partial class CubeNode
    {
        private const string vertexCode = @"
#version 150

in vec3 inPosition;
in vec2 inTexCoord;

uniform mat4 mvpMatrix;

out vec2 passTexCoord;
out vec3 passPos;

void main() {
    gl_Position = mvpMatrix * vec4(inPosition, 1.0); 

    passTexCoord = inTexCoord;
    passPos = inPosition;
}
";

        private const string fragmentCode = @"
#version 150

uniform sampler2D texture0;
uniform sampler1D texture1;
uniform sampler2D texture2;


in vec2 passTexCoord;
in vec3 passPos;

out vec4 outColor;

void main() {
    //outColor = color;
    vec4 c0 = texture(texture0, passTexCoord);
    float texCoord = (sqrt(passPos.x * passPos.x + passPos.y * passPos.y + passPos.z * passPos.z) - 0.5) / (sqrt(0.5 * 0.5 * 3) - 0.5);
    vec4 c1 = texture(texture1, texCoord);
    vec4 c2 = texture(texture2, passTexCoord);

    outColor = vec4((c0 + c1 + c2).xyz / 3, 1);
}
";
    }
}
