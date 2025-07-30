#version 410 core

out vec4 color;

uniform vec4 draw_color = vec4(0.5, 0.8, 1.0, 1.0);

void main(void)
{
    color = draw_color;
}
