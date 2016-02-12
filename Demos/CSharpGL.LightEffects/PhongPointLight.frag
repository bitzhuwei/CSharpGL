#version 150 core

in vec3 pass_worldPos;
in vec3 pass_worldNormal;
in vec3 pass_lightPosition;
out vec4 out_Color;
uniform vec3 lightColor;
uniform vec3 globalAmbient;
uniform float Kd;
uniform float Ks;
uniform float shininess;

void main(void)
{
    // diffuse color from directional light
    vec3 diffuseColor = Kd * lightColor * max(dot(pass_worldNormal, pass_lightPosition), 0);
    // ambient color
    vec3 ambientColor = Kd * globalAmbient;
    out_Color.xyz = diffuseColor + ambientColor;
    out_Color.w = 1;
    // eye's direction
    vec3 V = normalize(vec3(0.0f, 0.0f, 0.0f) - pass_worldPos);
    // reflection direction
    vec3 R = normalize(2 * max(dot(pass_worldNormal, pass_lightPosition), 0) * pass_worldNormal - pass_lightPosition);
    // pecular color
    vec3 specularColor = lightColor * pow(max(dot(V, R), 0), shininess);
    out_Color.xyz = Ks * specularColor + Kd * diffuseColor + Kd * ambientColor;
    out_Color.w = 1;
}

