#version 150 core

in vec3 in_Position;
in vec3 in_Normal;
out vec4 pass_Position;
out vec4 pass_Color;
uniform mat4 modelMatrix;
uniform mat4 viewMatrix;
uniform mat4 projectionMatrix;
uniform vec3 lightPosition;
uniform vec3 lightColor;
uniform vec3 globalAmbient;
uniform float Kd;

void main(void)
{
    gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, 1.0f);
    vec3 worldPos = (viewMatrix * modelMatrix * vec4(in_Position, 1.0f)).xyz;
    vec3 N = (transpose(inverse(viewMatrix * modelMatrix)) * vec4(in_Normal, 1.0f)).xyz;
    N = normalize(N);
    // light's direction
    vec3 L = (transpose(inverse(viewMatrix)) * vec4(lightPosition, 1.0f)).xyz;// directional light
    L = normalize(L);
    // diffuse color from directional light
    vec3 diffuseColor = Kd * lightColor * max(dot(N, L), 0);
    // ambient color
    vec3 ambientColor = Kd * globalAmbient;
    pass_Color.xyz = diffuseColor + ambientColor;
    pass_Color.w = 1;
}

