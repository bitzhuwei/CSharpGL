#version 150 core

in vec3 passColor;

uniform bool renderWireframe = false;

out vec4 out_Color;

void main(void) {
	if (renderWireframe)
	{
	    out_Color = vec4(1.0, 1.0, 1.0, 1.0);
	}
	else 
	{
	    out_Color = vec4(passColor, 1.0);
	}
}
