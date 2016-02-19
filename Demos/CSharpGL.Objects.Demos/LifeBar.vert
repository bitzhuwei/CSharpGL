#version 150 core

in vec3 in_Position;
uniform mat4 modelMatrix;
uniform mat4 viewMatrix;
uniform mat4 projectionMatrix;

void main(void)
{
    // TODO: this is where you should start with vertex shader. Only ASCII code are welcome.
    gl_Position = vec4(in_Position, 1.0f);
    // this is where your vertex shader ends.
}

