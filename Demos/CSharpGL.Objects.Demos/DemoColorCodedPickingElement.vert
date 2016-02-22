#version 150 core

in vec3 in_Position;
in vec3 in_Color;  
out vec4 pass_Color;

uniform mat4 MVP;
uniform float pickedVertexIDMin = -1;
uniform float pickedVertexIDMax = -1;
uniform float picked = 0;

void main(void) 
{
	gl_Position = MVP * vec4(in_Position, 1.0);

	int min = int(pickedVertexIDMin);
	int max = int(pickedVertexIDMax);
	if (min <= gl_VertexID && gl_VertexID <= max)
	//if (picked == 1)
	{
		pass_Color = vec4(1, 0, 0, 1);
	}
	else
	{
		pass_Color = vec4(in_Color, 1.0);
	}
}