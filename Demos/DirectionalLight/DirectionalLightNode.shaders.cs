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

in vec3 " + inPosition + @"; // per-vertex position
in vec3 " + inNormal + @"; // per-vertex normal

uniform mat4 " + mvpMat + @"; // combined model view projection matrix
uniform mat3 " + normalMatrix + @"; // normal matrix

smooth out vec3 eyeSpaceNormal; // normal in eye space

void main()
{
	eyeSpaceNormal = normalMatrix * inNormal;

	gl_Position = mvpMat * vec4(inPosition, 1);
}
";
        private const string directionalLightFrag = @"#version 330 core

uniform vec3 " + halfVector + @";
uniform float " + shiness + @" = 6;
uniform float " + strength + @" = 1;
uniform vec3 " + lightDirection + @"; // direction towards light source in view space
uniform vec3 " + lightColor + @";
uniform vec3 " + diffuseColor + @" = vec3(1, 0.8431, 0); // diffuse color of surface
uniform vec3 " + ambientColor + @" = vec3(0.2, 0.2, 0.2);

// inputs from vertex shader
smooth in vec3 eyeSpaceNormal; // interpolated normal in eye space

layout (location = 0) out vec4 outColor; // fargment shader output

void main()
{
	vec3 L = normalize(lightDirection); // light vector

	float diffuse = max(0, dot(normalize(eyeSpaceNormal), L));
    float specular = 0;
    if (diffuse > 0)
    {
        specular = max(0, dot(normalize(halfVector), eyeSpaceNormal));
        specular = pow(specular, shiness) * strength;
    }
    
    outColor = vec4(((ambientColor + diffuse) * diffuseColor + specular) * lightColor, 1.0);
}
";

    }
}
