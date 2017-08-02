using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace DirectionalLight
{
    public partial class DirectionalLightNode
    {
        private const string directionalLightVert = @"#version 330 core

in vec3 " + vPosition + @"; // per-vertex position
in vec3 " + vNormal + @"; // per-vertex normal

uniform mat4 " + MVP + @"; // combined model view projection matrix
uniform mat3 " + normalMatrix + @"; // normal matrix

smooth out vec3 vEyeSpaceNormal; // normal in eye space

void main()
{
	vEyeSpaceNormal = normalMatrix * vNormal;

	gl_Position = MVP * vec4(vPosition, 1);
}
";
        private const string directionalLightFrag = @"#version 330 core

uniform vec3 " + halfVector + @";
uniform float " + shiness + @" = 6;
uniform float " + strength + @" = 1;
uniform vec3 " + lightDirection + @"; // light direction in view space
uniform vec3 " + diffuseColor + @" = vec3(1, 0.8431, 0); // diffuse color of surface
uniform vec3 " + ambientColor + @" = vec3(0.2, 0.2, 0.2);

// inputs from vertex shader
smooth in vec3 vEyeSpaceNormal; // interpolated normal in eye space

layout (location = 0) out vec4 vFragColor; // fargment shader output

void main()
{
	vec3 L = normalize(lightDirection); // light vector

	float diffuse = max(0, dot(normalize(vEyeSpaceNormal), -L));
    float specular = 0;
    if (diffuse > 0)
    {
        specular = max(0, dot(normalize(halfVector), vEyeSpaceNormal));
        specular = pow(specular, shiness) * strength;
    }
    
    vFragColor = vec4((ambientColor + diffuse) * diffuseColor + specular, 1.0);
}
";

    }
}
