#version 150 core

in vec2 passTexCoord;

out vec4 out_Color;

uniform sampler2D tex;

void main(void) {
	out_Color = texture(tex, passTexCoord);
}
