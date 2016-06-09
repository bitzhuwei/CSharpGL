#version 150 core

in vec2 passUV;

uniform sampler2D colorTexture;

out vec4 out_Color;

void main(void) 
{
	out_Color = texture(colorTexture, passUV);
}
