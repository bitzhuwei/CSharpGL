#version 150 core

in vec3 in_Position;
in vec3 in_Normal;
uniform mat4 projectionMatrix;
uniform mat4 viewMatrix;
uniform mat4 modelMatrix;
out float LightIntensity;
out vec3 MCposition;
uniform vec3 LightPos;
uniform float Scale;

void main(void)
{
    gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, 1.0f);
    vec4 ECposition = viewMatrix * modelMatrix * vec4(in_Position, 1.0f);
    MCposition = in_Position * Scale;
    vec3 tnorm = normalize(vec3(viewMatrix * modelMatrix * vec4(in_Normal, 1.0f)));
    LightIntensity = dot(normalize(LightPos - vec3(ECposition)), tnorm) * 1.5f;
}

