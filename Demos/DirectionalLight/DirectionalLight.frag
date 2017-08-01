#version 330 core

uniform vec3 lightDirection; // light direction in world space
uniform vec3 diffuseColor = vec3(1, 0.8431, 0); // diffuse color of surface
uniform vec3 ambientColor = vec3(0.2, 0.2, 0.2);

// inputs from vertex shader
smooth in vec3 vEyeSpaceNormal; // interpolated normal in eye space

layout (location = 0) out vec4 vFragColor; // fargment shader output

void main()
{
	vec3 L = normalize(lightDirection); // light vector

	float diffuse = max(0, dot(normalize(vEyeSpaceNormal), -L));
	//if (vEyeSpaceNormal != normalize(vEyeSpaceNormal)) { diffuse = 1; }

	vFragColor = vec4(ambientColor + diffuse * diffuseColor, 1.0);
}
