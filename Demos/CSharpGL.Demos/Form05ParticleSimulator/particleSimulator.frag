#version 430 core

layout (location = 0) out vec4 color;

in float intensity;

void main(void)
{
    color = vec4(0.0f, 0.2f, 1.0f, 1.0f) * intensity + vec4(0.2f, 0.05f, 0.0f, 1.0f) * (1.0f - intensity);
}
