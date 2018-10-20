using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstSightOfAssimpNet
{
    partial class PositionNode
    {
        private const string vertexCode = @"#version 150

in vec3 inPosition;
in vec3 inNormal;

uniform mat4 mvpMat;
uniform mat4 normalMat; // transpose(inverse(modelMat))

out vec3 passNormal;

void main() {
    gl_Position = mvpMat * vec4(inPosition, 1.0);
    passNormal = vec3(normalMat * vec4(inNormal, 0.0));
}
";

        private const string fragmentCode = @"#version 150

in vec3 passNormal;

uniform vec3 lihtDirection = vec3(1, 1, 1);
uniform vec3 diffuseColor;

out vec4 outColor;

void main() {
    float diffuse = max(dot(normalize(lihtDirection), normalize(passNormal)), 0);
    outColor = vec4(diffuseColor * diffuse, 1.0);
}
";

    }
}
