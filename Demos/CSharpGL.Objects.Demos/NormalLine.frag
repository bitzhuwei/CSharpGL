#version 410 core

out vec4 color;

uniform vec4 fur_color = vec4(0.8, 0.8, 0.9, 1.0);

in GS_FS_VERTEX
{
    vec3 color;
    //vec2 tex_coord;
    //flat float fur_strength;
} fragment_in;

void main(void)
{
    //vec4 rgba = texture(fur_texture, fragment_in.tex_coord);
    //float t = rgba.a;
    //t *= fragment_in.fur_strength;
    //color = fur_color * vec4(1.0, 1.0, 1.0, t);
	//color = vec4(1, 1, 1 ,1) + 0.01f * vec4(fragment_in.normal, 1.0f) * fur_color;
	color = vec4(fragment_in.color, 1.0f);// * fur_color;
	//color = vec4(1, 1, 1, 1);
}
