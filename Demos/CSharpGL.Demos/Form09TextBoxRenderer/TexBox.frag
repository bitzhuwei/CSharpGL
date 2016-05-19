#version 150 core

in vec2 passUV;

uniform sampler2D fontTexture;

out vec4 color;

void main(void)
{
	vec4 textureColor = texture(fontTexture, passUV);
	if(textureColor.r <= 0.1f)
	{ discard; }
	else
	{ color = textureColor; }
}
