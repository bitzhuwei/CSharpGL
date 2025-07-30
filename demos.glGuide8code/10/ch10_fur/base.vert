#version 410

layout (location = 0) in vec4 position_in;
layout (location = 1) in vec3 normal_in;
layout (location = 2) in vec2 texcoord_in;

uniform mat4 model_matrix;
uniform mat4 projection_matrix;

out VS_FS_VERTEX
{
    vec3 normal;
} vertex_out;

void main(void)
{
    vertex_out.normal = normal_in;
    gl_Position = projection_matrix * (model_matrix * position_in);
}