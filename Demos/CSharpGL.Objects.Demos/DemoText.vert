#version 150 core

in vec3 in_Position;
in vec3 in_Normal;
out VS_GS_VERTEX
{
    vec3 normal;
} vertex_out;

uniform mat4 modelMatrix;
uniform mat4 viewMatrix;
uniform mat4 projectionMatrix;

void main(void)
{
    // TODO: this is where you should start with vertex shader. Only ASCII code are welcome.
    gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, 1.0f);
    vertex_out.normal = in_Normal;
    // this is where your vertex shader ends.
}

