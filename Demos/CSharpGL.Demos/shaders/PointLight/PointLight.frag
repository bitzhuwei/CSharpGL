#version 330 core

uniform vec3 ambient;
uniform vec3 lightColor;
uniform vec3 lightPosition;
uniform float shininess;
uniform float strength;

uniform vec3 eyeDirection;
uniform float constantAttenuation;
uniform float linearAttenuation;
uniform float quadraticAttenuation;

in vec3 passNormal;
in vec3 passColor;
in vec3 passPosition;

out vec4 outColor;

void main()
{
	vec3 lightDirection = lightPosition - passPosition;
	float lightDistance = length(lightDirection);
	lightDirection = lightDirection / lightDistance;
	
	float attenuation = 1.0 / (constantAttenuation + linearAttenuation * lightDistance + quadraticAttenuation * lightDistance * lightDistance);
	
	vec3 halfVector = normalize(lightDirection + eyeDirection);
	
	float diffuse = max(0.0, dot(passNormal, lightDirection));
	float specular = max(0.0, dot(passNormal, halfVector));
	
	if (diffuse > 0.0) { specular = 0.0; }
	else { specular = pow(specular, shininess) * strength; }
	
	vec3 scatteredLight = ambient + lightColor * diffuse * attenuation;
	vec3 reflectedLight = lightColor * specular * attenuation;
	
	vec3 rgb = min(passColor * scatteredLight + reflectedLight, vec3(1.0));
	outColor = vec4(rgb, 1.0);
}
