#version 150 core

in vec4 pass_Color;
out vec4 out_Color;

void main(void)
{
    // TODO: this is where you should start with fragment shader. Only ASCII code are welcome.
    // setup color for this fragment
    out_Color = pass_Color;
    // this is where your fragment shader ends.
}

