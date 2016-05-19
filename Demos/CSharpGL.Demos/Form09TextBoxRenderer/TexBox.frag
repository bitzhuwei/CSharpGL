#version 150 core

in vec2 passUV;

uniform sampler2D fontTexture;

out vec4 color;

void main(void)
{
	vec4 textureColor = texture(fontTexture, passUV);
	if(textureColor.a <= 0.1f)
	{ color = vec4(1,1,1,1);}//textureColor; }
	//{ discard; }
	else
	{ color = vec4(1,1,1,1);}//textureColor; }
}
