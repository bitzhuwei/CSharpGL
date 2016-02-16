#version 150 core

in vec4 pass_Color;
out vec4 out_Color;

void main(void)
{
    // TODO: this is where you should start with fragment shader. Only ASCII code are welcome.
    vec4 color = pass_Color;
    if (color.x < 0) { color.x = -color.x; }
    if (color.y < 0) { color.y = -color.y; }
    if (color.z < 0) { color.z = -color.z; }
    out_Color = pass_Color;
    // this is where your fragment shader ends.
}

