#version 150 core

out vec4 out_Color;
in vec3 pass_uv;

uniform sampler3D tex;

void main(void) 
{
	vec4 color = texture(tex, pass_uv);
	out_Color = color;
}