#version 150 core

in vec3 in_Position;
in vec3 in_Color;
//in vec3 in_Normal;

out vec3 pass_Color;
//out vec3 pass_Normal;

uniform mat4 projectionMatrix;
uniform mat4 viewMatrix;
uniform mat4 modelMatrix;

void main(void)
{
    // TODO: this is where you should start with vertex shader. Only ASCII code are welcome.
    gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, 1.0f);
    pass_Color = in_Color;
	pass_Normal = in_Normal;
    // this is where your vertex shader ends.
}

