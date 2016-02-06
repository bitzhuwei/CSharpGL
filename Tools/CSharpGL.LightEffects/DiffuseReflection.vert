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
    vec3 N = (viewMatrix * modelMatrix * vec4(in_Normal, 1.0f)).xyz;
    N = normalize(N);
    //计算入射光方向
    vec3 L = lightPosition - worldPos;
    L = normalize(L);
    //计算方向光漫反射光强
    vec3 diffuseColor = Kd * lightColor * max(dot(N, L), 0);
    //计算环境光漫反射光强
    vec3 ambientColor = Kd * globalAmbient;
    pass_Color.xyz = diffuseColor + ambientColor;
    pass_Color.w = 1;
}

