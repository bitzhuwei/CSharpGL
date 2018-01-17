using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShaderDefineClipPlane
{
    partial class ClippedCubeNode
    {
        private const string vertexCode = @"#version 150

in vec3 inPosition;
in vec3 inColor;

uniform mat4 projectionMat;
uniform mat4 viewMat;
uniform mat4 modelMat;

out vec3 worldPosition;
out vec3 passColor;

void main()
{
    gl_Position = projectionMat * viewMat * modelMat * vec4(inPosition, 1.0);

    worldPosition = vec3(modelMat * vec4(inPosition, 1.0));
    passColor = inColor;
}
";

        private const string fragmentCode = @"#version 150

in vec3 worldPosition;
in vec3 passColor;

uniform vec4 clipPlane; // (x, y, z, w) means (a, b, c, d) in 'aX + bY + cZ + d = 0'.
uniform bool keepGreater = false; // keep the fragments that greater than 0 in the formula.

out vec4 outColor;

void main()
{
    if (keepGreater)
    {
        if (vec4(worldPosition, 1) * clipPlane > 0)
        {
            outColor = passColor;
        }
        else 
        {
            discard;
        }
    }
    else
    {
        if (vec4(worldPosition, 1) * clipPlane < 0)
        {
            outColor = passColor;
        }
        else 
        {
            discard;
        }
    }

}
";
    }
}
