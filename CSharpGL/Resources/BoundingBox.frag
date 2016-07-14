#version 150 core

uniform vec3 boundingBoxColor = vec3(1, 1, 1);

out vec4 out_Color;

void main(void) 
{
	out_Color = vec4(boundingBoxColor, 1.0f);
}
