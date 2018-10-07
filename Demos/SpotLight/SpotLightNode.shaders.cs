using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace SpotLight
{
    public partial class SpotLightNode
    {
        private const string spotLightVert = @"#version 150 core

in vec3 inPosition;
in vec3 inNormal;

uniform mat4 projectionMat;
uniform mat4 viewMat;
uniform mat4 modelMat;
uniform mat4 normalMatrix;

out vec3 passPosition; // position in eye space.
out vec3 passNormal; // normal in eye space.

void main(void)
{
    gl_Position = projectionMat * viewMat * modelMat * vec4(inPosition, 1.0f);

    passPosition = (viewMat * modelMat * vec4(inPosition, 1.0f)).xyz;
    passNormal = (normalMatrix * vec4(inNormal, 0)).xyz;
}
";
        private const string spotLightFrag = @"#version 150 core

uniform float shiness = 6;
uniform float strength = 0.1;
uniform vec3 ambientColor = vec3(0.2, 0.2, 0.2);
uniform vec3 materialColor = vec3(1, 0.8431, 0);
uniform vec3 lightPosition = vec3(0, 0, 0); // light's position in eye space.
uniform vec3 lightColor = vec3(1, 1, 1); // white light.
uniform float constantAttenuation = 1.0;
uniform float linearAttenuation = 0.0001;
uniform float quadraticAttenuation = 0.0001;
uniform vec3 spotDirection; // spot light direction in eye space
uniform float spotCutoff = 0.5; // spot light cutoff
uniform float spotExponent = 1; // spot light exponent

in vec3 passPosition;
in vec3 passNormal;

out vec4 outColor;

void main(void)
{
    vec3 normal = normalize(passNormal);
    vec3 L = lightPosition - passPosition;
	vec3 D = normalize(spotDirection);
	// calculate the overlap between the spot and the light direciton
	float spotEffect = dot(-L, D);
	if (spotEffect > spotCutoff)
    {
        float diffuse = max(0, dot(normalize(L), normal));
        float distance = length(L);
        float attenuationAmount = 1.0 / (constantAttenuation + linearAttenuation * distance + quadraticAttenuation * distance * distance);
        attenuationAmount *= pow(spotEffect, spotExponent);
	    diffuse *= attenuationAmount;
        
        float specular = 0;
        if (diffuse > 0)
        {
            vec3 halfVector = normalize(L + vec3(0, 0, 1));// vec3(0, 0, 1) is camera's direction.
            specular = max(0, dot(halfVector, normal));
            specular = pow(specular, shiness) * strength;
            specular *= attenuationAmount;
	    }

        outColor = vec4(ambientColor * materialColor + diffuse * materialColor * lightColor + specular * lightColor, 1);
    }
	else
    {
        outColor = vec4(ambientColor * materialColor, 1.0);
    }
}
";

    }
}
