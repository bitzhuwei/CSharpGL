#version 150 core

in vec3 position;
in vec3 color;
uniform mat4 mvp;
out vec3 pass_color;

void main(void)
{
    gl_Position = mvp * vec4(position, 1.0f);
    pass_color = color;
}

