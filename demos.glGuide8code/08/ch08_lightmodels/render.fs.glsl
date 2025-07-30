#version 430 core

layout (location = 0) out vec4 color;

in vec3 vs_worldpos;
in vec3 vs_normal;

uniform vec4 color_ambient = vec4(0.1, 0.2, 0.5, 1.0);
uniform vec4 color_diffuse = vec4(0.2, 0.3, 0.6, 1.0);
uniform vec4 color_specular = vec4(0.0); // vec4(1.0, 1.0, 1.0, 1.0);
uniform float shininess = 77.0f;

uniform vec3 light_position = vec3(12.0f, 32.0f, 560.0f);

void main(void)
{
    vec3 light_direction = normalize(light_position - vs_worldpos);
    vec3 normal = normalize(vs_normal);
    vec3 half_vector = normalize(light_direction + normalize(vs_worldpos));
    float diffuse = max(0.0, dot(normal, light_direction));
    float specular = pow(max(0.0, dot(vs_normal, half_vector)), shininess);
    color = color_ambient + diffuse * color_diffuse + specular * color_specular;
}