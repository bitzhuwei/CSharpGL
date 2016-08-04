#version 150 core

in vec4 pass_Color;
out vec4 out_Color;

uniform bool renderWireframe = false;

void main(void) {
	if (renderWireframe)
	{
	    out_Color = vec4(1, 1, 1, 1);
	}
	else
	{
	    out_Color = pass_Color;
	}
}
