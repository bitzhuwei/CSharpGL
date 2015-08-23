#version 150 core

uniform sampler2D tex;

out vec4 out_Color;

void main(void) 
{
	vec4 color = texture(tex, gl_PointCoord);
	if (color.a == 0.0f)
	{
		discard;
	}
	else
	{
		out_Color = color;
	}
}
