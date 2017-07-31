using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace Lights
{
    public partial class LightingNode
    {
        private const string directionalLightVert = @"#version 330 core

in vec3 " + vPosition + @"; // per-vertex position
in vec3 " + vNormal + @"; // per-vertex normal

uniform mat4 " + MVP + @"; // combined model view projection matrix
uniform mat3 " + N + @"; // normal matrix

smooth out vec3 vEyeSpaceNormal; // normal in eye space

void main()
{
	vEyeSpaceNormal = N * vNormal;

	gl_Position = MVP * vec4(vPosition, 1);
}
";
        private const string directionalLightFrag = @"#version 330 core

uniform mat4 " + MV + @"; // model view matrix
uniform vec3 " + lightDirection + @"; // light direction in model space
uniform vec3 " + diffuseColor + @"; // diffuse color of surface
uniform vec3 " + ambientColor + @" = vec3(0.2, 0.2, 0.2);

// inputs from vertex shader
smooth in vec3 vEyeSpaceNormal; // interpolated normal in eye space

layout (location = 0) out vec4 vFragColor; // fargment shader output

void main()
{
	vec4 vEyeSpaceLightDirection = MV * vec4(lightDirection, 0);
	vec3 L = normalize(vEyeSpaceLightDirection.xyz); // light vector

	float diffuse = max(0, dot(vEyeSpaceNormal, L));
	if (vEyeSpaceNormal != normalize(vEyeSpaceNormal)) { diffuse = 1; }

	vFragColor = vec4(ambientColor + diffuse * diffuseColor, 1.0);
}
";

    }
}
