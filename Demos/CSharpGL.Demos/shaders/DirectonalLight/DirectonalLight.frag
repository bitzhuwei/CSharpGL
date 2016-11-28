#version 330 core

uniform vec3 ambientLight;
uniform vec3 directionalLightColor;
uniform vec3 directionalLightDirection;
uniform vec3 halfVector;
uniform float shininess;
uniform float strength;

in vec3 passNormal;
in vec3 passColor;

out vec4 outColor;

void main()
{
	float diffuse = max(0.0, dot(passNormal, directionalLightDirection));
	float specular = max(0.0, dot(passNormal, halfVector));
	
	if (diffuse == 0.0) { specular = 0.0; }
	else { specular = pow(specular, shininess); }
	
	vec3 scatteredLight = ambientLight + directionalLightColor * diffuse;
	vec3 reflectedLight = directionalLightColor * specular * strength;
	if (strength == (0.0))
	{
	    outColor = vec4(1.0);
	}
	else
	{	
		vec3 rgb = min(passColor * scatteredLight + reflectedLight, vec3(1.0));
		outColor = vec4(rgb, 1.0);
	}
}
