#version 150 core

uniform vec3 lineColor;
out vec4 outputColor;

void main(void)
{
    outputColor = vec4(lineColor, 1.0f);
}

