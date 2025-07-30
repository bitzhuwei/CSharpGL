#version 410 core

uniform sampler2D s;

out vec4 color;

in vec2 tex_coord;

void main(void)
{
    color = texture(s, tex_coord);
}