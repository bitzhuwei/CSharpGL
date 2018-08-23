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
in vec2 inUV;

uniform mat4 projectionMat;
uniform mat4 viewMat;
uniform mat4 modelMat;

out vec3 worldSpacePosition;
out vec2 passUV;

void main()
{
    gl_Position = projectionMat * viewMat * modelMat * vec4(inPosition, 1.0);

    worldSpacePosition = vec3(modelMat * vec4(inPosition, 1.0));
    passUV = inUV;
}
";

        private const string fragmentCode = @"#version 150

in vec3 worldSpacePosition;
in vec2 passUV;

uniform sampler2D tex;
uniform vec4 clipPlane = vec4(1, 1, 1, 0); // (x, y, z, w) means (a, b, c, d) in 'aX + bY + cZ + d = 0'.
uniform bool keepGreater = true; // keep the fragments that greater than 0 in the formula.

out vec4 outColor;

void main()
{
    vec4 v = vec4(worldSpacePosition, 1) * clipPlane;
    float sum = v.x + v.y + v.z + v.w;
    if ((keepGreater && (sum > 0))
        || ((!keepGreater) && (sum < 0)))
    {
        outColor = texture(tex, passUV);
    }
    else
    {
        if (int(gl_FragCoord.x + gl_FragCoord.y) % 2 == 1) discard;

        outColor = texture(tex, passUV);
    }
}
";
    }
}
