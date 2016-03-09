#version 150 core

in vec3 pass_color;
out vec4 output_color;

void main(void)
{
    output_color = vec4(pass_color, 1.0f);
}

