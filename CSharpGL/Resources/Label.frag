#version 150 core

in vec2 passUV;

uniform sampler2D fontTexture;
uniform vec3 textColor = vec3(1, 1, 1);

out vec4 color;

void main(void)
{
    vec4 textureColor = texture(fontTexture, passUV);

	// TODO: this reduce effect on glyph's edge.
	//if (textureColor.r < 0.1f) discard;

    color = vec4(textColor, textureColor.r);
}
