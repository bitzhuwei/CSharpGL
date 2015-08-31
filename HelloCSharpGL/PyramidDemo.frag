#version 150 core

in vec4 pass_Color;
out vec4 out_Color;// any name for 'out_Color' is OK, but make sure it's a 'out vec4'

void main(void) 
{
	out_Color = pass_Color;// setup color for this fragment
}
