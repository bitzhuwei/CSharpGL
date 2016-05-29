#version 430 core

in vec3 vert;
in vec2 uv;

out vec2 passUV;

uniform mat4 mvp;

void main(void)
{
    gl_Position = mvp * vec4(vert, 1.0f);

	passUV = uv;
}
