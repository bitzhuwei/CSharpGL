#version 410 core

in vec3 in_Position;
in vec3 in_Normal;
//in vec2 texcoord_in;

uniform mat4 modelMatrix;
uniform mat4 viewMatrix;
uniform mat4 projectionMatrix;

out VS_GS_VERTEX
{
    vec3 normal;
    //vec2 tex_coord;
} vertex_out;

void main(void)
{
    vertex_out.normal = in_Normal;
    //vertex_out.tex_coord = texcoord_in;
    //gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, 1.0f);
    gl_Position = vec4(in_Position, 1.0f);
}

