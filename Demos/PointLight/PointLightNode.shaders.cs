using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace PointLight
{
    public partial class PointLightNode
    {
        private const string pointLightVert = @"#version 150 core

in vec3 inPosition;
in vec3 inNormal;

uniform mat4 projectionMatrix;
uniform mat4 viewMatrix;
uniform mat4 modelMatrix;
uniform mat4 normalMatrix;

out vec3 passPosition; // position in eye space.
out vec3 passNormal; // normal in eye space.

void main(void)
{
    gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(inPosition, 1.0f);

    passPosition = (viewMatrix * modelMatrix * vec4(inPosition, 1.0f)).xyz;
    passNormal = (normalMatrix * vec4(inNormal, 0)).xyz;
}
";
        private const string pointLightFrag = @"#version 150 core

uniform float shiness = 6;
uniform float strength = 1;
uniform vec3 ambientColor = vec3(0.2, 0.2, 0.2);
uniform vec3 diffuseColor = vec3(1, 0.8431, 0);
uniform vec3 lightPosition = vec3(0, 0, 0); // light's position in eye space.
uniform vec3 lightColor;
uniform float constantAttenuation = 1.0;
uniform float linearAttenuation = 0.0001;
uniform float quadraticAttenuation = 0.0001;

in vec3 passPosition;
in vec3 passNormal;

out vec4 outColor;

void main(void)
{
    vec3 normal = normalize(passNormal);
    vec3 L = lightPosition - passPosition;
    float diffuse = max(0, dot(normalize(L), normal));
    float distance = length(L);
    float attenuationAmount = 1.0 / (constantAttenuation + linearAttenuation * distance + quadraticAttenuation * distance * distance);
	diffuse *= attenuationAmount;

    float specular = 0;
    if (diffuse > 0)
    {
        vec3 halfVector = normalize(L + vec3(0, 0, 1));// vec3(0, 0, 1) is camera's direction.
        specular = max(0, dot(halfVector, normal));
        specular = pow(specular, shiness) * strength;
    }
	
    outColor = vec4(((ambientColor + diffuse) * diffuseColor + specular) * lightColor, 1);
}
";

    }
}
