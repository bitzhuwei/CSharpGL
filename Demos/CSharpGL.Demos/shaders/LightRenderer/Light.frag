#version 150 core

in float passTexCoord;

out vec4 out_Color;

void main(void) {
	out_Color = texture(tex, passTexCoord);
}
