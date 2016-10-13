#version 150 core

in float passTexCoord;

uniform sampler1D tex;

out vec4 out_Color;

void main(void) {
	out_Color = texture(tex, passTexCoord);
}
