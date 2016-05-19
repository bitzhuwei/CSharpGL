#version 150 core

in vec2 position;
uniform mat4 mvp;
uniform float lackAxis = 2.0f;

void main(void)
{
	if (lackAxis == 0.0f)
	{ gl_Position = mvp * vec4(0.0f, position.x, position.y, 1.0f); }
	else if (lackAxis == 1.0f)
	{ gl_Position = mvp * vec4(position.x, 0.0f, position.y, 1.0f); }
	else // if (lackAxis == 2.0f)
	{ gl_Position = mvp * vec4(position.x, position.y, 0.0f, 1.0f); }
}
