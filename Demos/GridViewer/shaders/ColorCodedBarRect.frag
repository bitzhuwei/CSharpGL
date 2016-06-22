#version 150 core

in float passCoord;

uniform sampler1D codedColorSampler;

out vec4 out_Color;

void main(void) 
{
	float coord = passCoord;
	if (coord >= 1.0f) { coord = 0.99f; }
	out_Color = texture(codedColorSampler, coord);
}
