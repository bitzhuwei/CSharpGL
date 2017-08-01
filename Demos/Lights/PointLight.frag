#version 330 core

uniform mat4 V; // view matrix
uniform vec3 lightPosition; // light position in world space
uniform vec3 diffuseColor; // diffuse color of surface
uniform float constantAttenuation = 1.0;
uniform float linearAttenuation = 0;
uniform float quadraticAttenuation = 0;
uniform vec3 ambientColor = vec3(0.2, 0.2, 0.2);

// inputs from vertex shader
smooth in vec3 vEyeSpacePosition; // interpolated position in eye space
smooth in vec3 vEyeSpaceNormal; // interpolated normal in eye space

layout (location = 0) out vec4 vFragColor; // fargment shader output

void main()
{
	vec3 vEyeSpaceLightPosition = (V * vec4(lightPosition, 1)).xyz;
	vec3 L = vEyeSpaceLightPosition - vEyeSpacePosition;
	float distance = length(L); // distance of point light source.
	L = normalize(L);

	float diffuse = max(0, dot(normalize(vEyeSpaceNormal), L));
	float attenuationAmount = 1.0 / (constantAttenuation + linearAttenuation * distance + quadraticAttenuation * distance * distance);
	diffuse *= attenuationAmount;
	//if (vEyeSpaceNormal != normalize(vEyeSpaceNormal)) { diffuse = 1; }

	vFragColor = vec4(ambientColor + diffuse * diffuseColor, 1.0);
}
