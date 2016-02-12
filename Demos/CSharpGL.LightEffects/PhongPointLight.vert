#version 150 core

in vec3 in_Position;
in vec3 in_Normal;
out vec3 pass_worldPos;
out vec3 pass_worldNormal;
out vec3 pass_lightPosition;
uniform mat4 modelMatrix;
uniform mat4 viewMatrix;
uniform mat4 projectionMatrix;
uniform vec3 lightPosition;

void main(void)
{
    gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, 1.0f);
    vec3 worldPos = (viewMatrix * modelMatrix * vec4(in_Position, 1.0f)).xyz;
    vec3 N = (transpose(inverse(viewMatrix * modelMatrix)) * vec4(in_Normal, 1.0f)).xyz;
    N = normalize(N);
    pass_worldPos = worldPos;
    pass_worldNormal = N;
    // light's direction
    vec3 L = (transpose(inverse(viewMatrix)) * vec4(lightPosition, 1.0f)).xyz;// directional light
    L = normalize(L);
    pass_lightPosition = L;
}

