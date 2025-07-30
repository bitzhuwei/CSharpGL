// Fragment Shader
// Graham Sellers
// OpenGL SuperBible
#version 420 core

in vec4 color;

out vec4 output_color;

void main(void)
{
    output_color = color;
}