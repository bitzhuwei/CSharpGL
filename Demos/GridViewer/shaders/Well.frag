#version 150 core

in vec3 passBrightness;

uniform vec4 wellColor = vec4(1, 1, 1, 1);

out vec4 out_Color;

void main(void) 
{
    out_Color = vec4(passBrightness, 1.0f) * wellColor;
}
