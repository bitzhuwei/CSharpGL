#version 410 core

out vec4 outColor;

in GS_FS_VERTEX
{
    vec3 color;
    //vec2 tex_coord;
    //flat float fur_strength;
} fragment_in;

void main(void)
{
	vec3 color = fragment_in.color;
    if (color.r < 0) { color.r = -color.r; }
    if (color.g < 0) { color.g = -color.g; }
    if (color.b < 0) { color.b = -color.b; }
    outColor = vec4(color, 1.0f);
}
