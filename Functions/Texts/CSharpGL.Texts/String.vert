#version 150 core

in vec2 position;
in vec4 color;
out vec4 passColor;
in vec2 texCoord;
out vec2 passTexCoord;
uniform mat4 mvp;

void main(void)
{
    gl_Position = mvp * vec4(position.x, position.y, 0.0f, 1.0f);
    passColor = color;
    passTexCoord = texCoord;
}

