#version 150 core

in vec2 pass_UV;
out vec4 out_Color;
uniform sampler2D texture1;
uniform sampler2D texture2;
uniform float percent;

void main(void) 
{
	vec4 color = texture(texture1, pass_UV) * percent + texture(texture2, pass_UV) * (1.0 - percent);
	out_Color = color;
	//out_Color = texture(texture2, pass_UV);
	//out_Color = texture(texture1, pass_UV);
}
