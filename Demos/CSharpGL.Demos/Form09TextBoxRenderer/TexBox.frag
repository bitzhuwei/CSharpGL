#version 150 core

uniform sampler2D fontTexture;

out vec4 color;

void main(void)
{
	vec4 textureColor = texture(fontTexture, gl_PointCoord);
	if(textureColor.a <= 0.1f)
	{ discard; }
	else
	{ color = textureColor; }
}
