using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace Lights
{
    public partial class LightingNode : PickableNode
    {
        private const string vPosition = "vPosition";
        private const string vNormal = "vNormal";
        private const string MVP = "MVP";
        private const string MV = "MV";
        private const string N = "N";
        private const string lightPosition = "lightPosition"; // TODO: we assume light's color is white(vec3(1, 1, 1))
        private const string diffuseColor = "diffuseColor";
        private const string constantAttenuation = "constantAttenuation";
        private const string linearAttenuation = "linearAttenuation";
        private const string quadraticAttenuation = "quadraticAttenuation";
        private const string ambientColor = "ambientColor";

        private const string pointLightVert = @"#version 330 core

in vec3 " + vPosition + @"; / per-vertex position
in vec3 " + vNormal + @"; // per-vertex normal

uniform mat4 " + MVP + @"; // combined model view projection matrix
uniform mat4 " + MV + @"; // model view matrix
uniform mat3 " + N + @"; // normal matrix

smooth out vec3 vEyeSpapcePosition; // position in eye space
smooth out vec3 vEyeSpaceNormal; // normal in eye space

void main()
{
	vEyeSpacePosition = (MV * vec4(vPosition, 1)).xyz;

	vEyeSpaceNormal = N * vNormal;

	gl_Position = MVP * vec4(vPosition, 1);
}";
        private const string pointLightFrag = @"#version 330 core

uniform mat4 " + MV + @"; // model view matrix
uniform vec3 " + lightPosition + @"; // light position in model space
uniform vec3 " + diffuseColor + @"; // diffuse color of surface
uniform float " + constantAttenuation + @" = 1.0;
uniform float " + linearAttenuation + @" = 0;
uniform float " + quadraticAttenuation + @" = 0;
uniform vec3 " + ambientColor + @" = vec3(0.2, 0.2, 0.2);

// inputs from vertex shader
smooth in vec3 vPosition; / interpolated position in eye space
smooth in vec3 vNormal; // interpolated normal in eye space

layout (location = 0) out vec4 vFragColor; // fargment shader output

void main()
{
	vec3 vEyeSpaceLightPosition = (MV * vec4(lightPosition)).xyz;
	vec3 L = vEyeSpaceLightPosition - vEyeSpacePosition;
	float distance = length(L); // distance of point light source.
	L = normalize(L);

	float diffuse = max(0, dot(vEyeSpaceNormal, L));
	float attenuationAmount = 1.0 / (constantAttenuation + linearAttenuation * distance + quadraticAttenuation * distance * distance);
	diffuse *= attenuationAmount;
	if (vEyeSpaceNormal != normalize(vEyeSpaceNormal)) { diffuse = 1; }

	vFragColor = vec4(ambientColor + diffuse * diffuseColor, 1.0);
}
";

    }
}
