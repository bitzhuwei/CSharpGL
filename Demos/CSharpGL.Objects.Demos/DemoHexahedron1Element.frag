#version 150 core

in vec4 pass_Color;
out vec4 out_Color;
uniform float renderWirframe;

void main(void) 
{
	if (renderWirframe > 0.0)
	{
		out_Color = vec4(1, 1, 1, 1);
	}
	else
	{
		out_Color = pass_Color;
	}
}