#version 150 core

in float passTexCoord;

uniform sampler1D tex;

out vec4 outColor;

void main(void) {
	outColor = texture(tex, passTexCoord);
}
