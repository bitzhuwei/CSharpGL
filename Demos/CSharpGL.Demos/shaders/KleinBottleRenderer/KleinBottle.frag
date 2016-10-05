#version 150 core

in vec2 passTexCoord;

uniform sampler2D tex;

out vec4 out_Color;

void main(void) {
	out_Color = texture(tex, passTexCoord);
}
