#version 150 core

out vec4 out_Color;

uniform sampler2D tex;
uniform vec3 textColor;

void main(void) {
	float transparency = texture2D(tex, gl_PointCoord).r;
	if (transparency == 0.0f)
	{
		discard;
	}
	else
	{
		out_Color = vec4(1, 1, 1, transparency) * vec4(textColor, 1.0f);
	}
}
