#version 150 core

in vec3 passColor;

out vec4 out_Color;

uniform bool renderWireframe = false;

void main(void) 
{
    if (renderWireframe)
	{
	    out_Color = vec4(1, 1, 1, 1.0f);
	}
	else
	{
	    out_Color = vec4(passColor, 1.0f);
	}
}
