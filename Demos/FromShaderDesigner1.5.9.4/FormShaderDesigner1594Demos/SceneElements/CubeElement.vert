#version 150 core

const float SpecularContribution = 0.3;
const float DiffuseContribution  = 1.0 - SpecularContribution;

in vec3 in_Position;
in vec3 in_Normal;
in vec3 in_Color;  
out vec4 pass_Color;

uniform mat4 modelMatrix;
uniform mat4 viewMatrix;
uniform mat4 projectionMatrix;
uniform vec3 lightPosition;

void main(void) 
{
	vec4 position = vec4(in_Position, 1.0);
	vec4 ecPosition = viewMatrix * modelMatrix * position;
	vec4 tnorm = normalize(viewMatrix *modelMatrix * vec4(in_Normal, 1.0));
	vec3 lightVec = normalize(lightPosition - vec3(ecPosition));
	vec3 reflectVec = lightVec + (lightVec * tnorm) * vec3(tnorm) + vec3(tnorm);//reflect(-lightVec, tnorm);
	vec3 viewVec    = normalize(-vec3(ecPosition));
	float diffuse = dot(lightVec, vec3(tnorm));
	if (diffuse < 0.0) { diffuse = -diffuse; }
    //float diffuse   = max(dot(lightVec, vec3(tnorm)), 0.0);
    float spec      = 0.0;

    if (diffuse > 0.0)
    {
        spec = max(dot(reflectVec, viewVec), 1.0);
        spec = pow(spec, 16.0);
    }

    //float LightIntensity  = diffuse + spec;
    float LightIntensity  = DiffuseContribution * diffuse + SpecularContribution * spec;
	//if (LightIntensity <= 0.5)
	{
	    //LightIntensity = 0.5;
	}

	//pass_Color = vec4(in_Color * 1.0, 1.0);
	pass_Color = vec4(in_Color * LightIntensity, 1.0);

	gl_Position = projectionMatrix * ecPosition;
}