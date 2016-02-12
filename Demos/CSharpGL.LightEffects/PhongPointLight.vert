#version 150 core

in vec3 in_Position;
in vec3 in_Normal;
out vec4 pass_Color;
uniform mat4 modelMatrix;
uniform mat4 viewMatrix;
uniform mat4 projectionMatrix;
uniform vec3 lightPosition;
uniform vec3 lightColor;
uniform vec3 globalAmbient;
uniform float Kd;
uniform float Ks;
uniform float shininess;

void main(void)
{
    gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, 1.0f);
    vec3 worldPos = (viewMatrix * modelMatrix * vec4(in_Position, 1.0f)).xyz;
    vec3 N = (transpose(inverse(viewMatrix * modelMatrix)) * vec4(in_Normal, 1.0f)).xyz;
    N = normalize(N);
    // light's direction
    vec3 L = (viewMatrix * vec4(lightPosition, 1.0f)).xyz - worldPos;// point light
    L = normalize(L);
    // eye's direction
    vec3 V = normalize(vec3(0.0f, 0.0f, 0.0f) - worldPos);
    // reflection direction
    vec3 R = normalize(2 * max(dot(N, L), 0) * N - L);
    // diffuse color from directional light
    vec3 diffuseColor = lightColor * max(dot(N, L), 0);
    // ambient color
    vec3 ambientColor = globalAmbient;
    // pecular color
    vec3 specularColor = lightColor * pow(max(dot(V, R), 0), shininess);
    pass_Color.xyz = Ks * specularColor + Kd * diffuseColor + Kd * ambientColor;
    pass_Color.w = 1;
}

