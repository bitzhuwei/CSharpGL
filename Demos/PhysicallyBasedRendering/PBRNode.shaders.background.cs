using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhysicallyBasedRendering
{
    partial class PBRNode
    {
        private const string backgroundVertexCode = @"#version 330 core

layout(location = 0) in vec3 vPosition;

uniform mat4 ViewMatrix;
uniform mat4 ProjMatrix;

out vec3 WorldPos;

void main()
{
    WorldPos = vPosition;
    mat4 view = mat4(mat3(ViewMatrix));
    vec4 clipPos = ProjMatrix * view * vec4(vPosition, 1.0f);
	gl_Position = clipPos.xyww;
}
";

        private const string backgroundFragmentCode = @"#version 330 core

in vec3 WorldPos;

uniform samplerCube backgroundCubeMap;

out vec4 fColor;

void main()
{
    vec3 envColor = texture(backgroundCubeMap, WorldPos).rgb;

    //ToneMap
    envColor = envColor / (envColor + vec3(1.0, 1.0, 1.0));

    envColor = pow(envColor,vec3(1.0/2.2));

    fColor = vec4(envColor,1.0f);
} 
";

    }
}
