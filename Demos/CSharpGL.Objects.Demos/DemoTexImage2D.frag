#version 150 core

out vec4 out_Color;
in vec2 pass_uv;

uniform sampler2D tex;

void main(void) 
{
	vec4 color = texture(tex, pass_uv);
	out_Color = color;
}