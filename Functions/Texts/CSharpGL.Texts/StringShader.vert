#version 150 core

in vec3 position;
in vec3 color;
out vec3 passColor;
in vec2 texCoord;
out vec2 passTexCoord;
uniform mat4 mvp;

void main(void)
{
    gl_Position = mvp * vec4(position, 1.0f);
    passColor = color;
    passTexCoord = texCoord;
}

