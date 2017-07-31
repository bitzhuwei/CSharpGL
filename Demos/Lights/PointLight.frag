#version 330 core

layout (location = 0) out vec4 vFragColor; // fargment shader output

uniform mat4 MV; // model view matrix
uniform vec3 lightPosition; // light position in model space
uniform vec3 diffuseColor; // diffuse color of surface
uniform float constantAttenuation = 1.0;
uniform float linearAttenuation = 0;
uniform float quadraticAttenuation = 0;
uniform vec3 ambientColor = vec3(0.2, 0.2, 0.2);

// inputs from vertex shader
smooth in vec3 vPosition; / interpolated position in eye space
smooth in vec3 vNormal; // interpolated normal in eye space

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
