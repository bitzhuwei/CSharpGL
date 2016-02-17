#version 150 core

in vec4 pass_Normal;
in GS_FS_VERTEX
{
    vec3 color;
} fragment_in;

out vec4 outColor;

void main(void)
{
    // TODO: this is where you should start with fragment shader. Only ASCII code are welcome.
    vec3 color = fragment_in.color;
    if (color.r < 0) { color.r = -color.r; }
    if (color.g < 0) { color.g = -color.g; }
    if (color.b < 0) { color.b = -color.b; }
    outColor = vec4(color, 1.0f);
    // this is where your fragment shader ends.
}

