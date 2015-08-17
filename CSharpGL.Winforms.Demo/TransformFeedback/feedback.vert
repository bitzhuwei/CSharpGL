#version 400 core

#define POSITION	0
#define COLOR		3
#define FRAG_COLOR	0

precision highp float;
precision highp int;
layout(std140, column_major) uniform;

layout(location = POSITION) in vec4 Position;
layout(location = COLOR) in vec4 Color;

out block
{
	vec4 Color;
} Out;

void main()
{	
	gl_Position = Position;
	Out.Color = Color;
}

