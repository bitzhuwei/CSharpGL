#version 150 core

uniform sampler2D sprite_texture;

out vec4 color;

void main(void)
{
	vec4 textureColor = texture(sprite_texture, gl_PointCoord);
	if(textureColor.a <= 0.01f)
	{ discard; }
	else
	{ color = textureColor; }
}
