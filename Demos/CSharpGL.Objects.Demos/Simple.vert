#version 150 core

in vec3 in_Position;
in vec3 in_Color;
in vec3 in_Normal;
out vec4 pass_Color;
uniform mat4 modelMatrix;
uniform mat4 viewMatrix;
uniform mat4 projectionMatrix;

void main(void)
{
    // TODO: this is where you should start with vertex shader. Only ASCII code are welcome.
    gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, 1.0f);
    pass_Color = vec4(in_Color, 1.0f);
    // this is where your vertex shader ends.
}

