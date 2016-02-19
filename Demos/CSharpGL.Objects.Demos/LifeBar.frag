#version 150 core

uniform vec3 color;
out vec4 outColor;

void main(void)
{
    // TODO: this is where you should start with fragment shader. Only ASCII code are welcome.
    outColor = vec4(color, 1.0f);
    // this is where your fragment shader ends.
}

