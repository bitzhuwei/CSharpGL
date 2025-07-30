#version 410 core

uniform sampler2D tex_envmap;

in VS_OUT
{
    vec3 normal;
    vec3 view;
} fs_in;

out vec4 color;

void main(void)
{
    // u will be our normalized view vector
    vec3 u = normalize(fs_in.view);

    // Reflect u about the plane defined by the normal at the fragment
    vec3 r = reflect(u, normalize(fs_in.normal));

    vec2 tc;

    tc.y = r.y; r.y = 0.0;
    tc.x = normalize(r).x * 0.5;

    float s = sign(r.z) * 0.5;

    tc.s = 0.75 - s * (0.5 - tc.s);
    tc.t = 0.5 + 0.5 * tc.t;

    // Sample from scaled and biased texture coordinate
    color = texture(tex_envmap, tc);
}
