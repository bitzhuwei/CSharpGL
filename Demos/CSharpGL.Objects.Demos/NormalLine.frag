#version 150 core

in vec4 pass_Normal;
out vec4 out_Color;

void main(void)
{
    // TODO: this is where you should start with fragment shader. Only ASCII code are welcome.
    out_Color = pass_Normal;
    // this is where your fragment shader ends.
}

