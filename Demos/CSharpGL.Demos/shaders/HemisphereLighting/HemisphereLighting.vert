#version 330 core
uniform vec3 LightPosition;
uniform vec3 SkyColor;
uniform vec3 GroundColor;
uniform mat4 projection;
uniform mat4 view;
uniform mat4 model;
uniform mat3 NormalMatrix;

in vec3 inPosition;
in vec3 inNormal;

out vec3 passColor;

void main()
{
	vec3 position = vec3(model * vec4(inPosition, 1.0));
	vec3 tnorm = normalize(NormalMatrix* inNormal);
	vec3 lightVec = normalize(LightPosition - position);
	float costheta = dot(tnorm, lightVec);
	float a = costheta * 0.5 + 0.5;
	passColor = mix(GroundColor, SkyColor, a);
	gl_Position = projection * view * model * vec4(inPosition, 1.0);
}