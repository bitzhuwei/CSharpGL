#version 410 core

layout (location = 0) in vec3 position_3;
layout (location = 1) in vec3 normal;

layout (location = 10) in uint draw_id;

out VS_OUT
{
    vec3 normal;
    vec4 color;
} vs_out;

uniform float time = 0.0;

uniform mat4 view_matrix;
uniform mat4 proj_matrix;
uniform mat4 viewproj_matrix;

const vec4 color0 = vec4(0.29, 0.21, 0.18, 1.0);
const vec4 color1 = vec4(0.58, 0.55, 0.51, 1.0);

void main(void)
{
    vec4 position = vec4(position_3, 1.0);
    mat4 m1;
    mat4 m2;
    mat4 m;
    float t = time * 0.1;
    float f = float(draw_id) / 30.0;

    float st = sin(t * 0.5 + f * 5.0);
    float ct = cos(t * 0.5 + f * 5.0);

    float j = fract(f);
    float d = cos(j * 3.14159);

    // Rotate around Y
    m[0] = vec4(ct, 0.0, st, 0.0);
    m[1] = vec4(0.0, 1.0, 0.0, 0.0);
    m[2] = vec4(-st, 0.0, ct, 0.0);
    m[3] = vec4(0.0, 0.0, 0.0, 1.0);

    // Translate in the XZ plane
    m1[0] = vec4(1.0, 0.0, 0.0, 0.0);
    m1[1] = vec4(0.0, 1.0, 0.0, 0.0);
    m1[2] = vec4(0.0, 0.0, 1.0, 0.0);
    m1[3] = vec4(260.0 + 30.0 * d, 5.0 * sin(f * 123.123), 0.0, 1.0);

    m = m * m1;

    // Rotate around X
    st = sin(t * 2.1 * (600.0 + f) * 0.01);
    ct = cos(t * 2.1 * (600.0 + f) * 0.01);

    m1[0] = vec4(ct, st, 0.0, 0.0);
    m1[1] = vec4(-st, ct, 0.0, 0.0);
    m1[2] = vec4(0.0, 0.0, 1.0, 0.0);
    m1[3] = vec4(0.0, 0.0, 0.0, 1.0);

    m = m * m1;

    // Rotate around Z
    st = sin(t * 1.7 * (700.0 + f) * 0.01);
    ct = cos(t * 1.7 * (700.0 + f) * 0.01);

    m1[0] = vec4(1.0, 0.0, 0.0, 0.0);
    m1[1] = vec4(0.0, ct, st, 0.0);
    m1[2] = vec4(0.0, -st, ct, 0.0);
    m1[3] = vec4(0.0, 0.0, 0.0, 1.0);

    m = m * m1;

    // Non-uniform scale
    float f1 = 0.65 + cos(f * 1.1) * 0.2;
    float f2 = 0.65 + cos(f * 1.1) * 0.2;
    float f3 = 0.65 + cos(f * 1.3) * 0.2;

    m1[0] = vec4(f1, 0.0, 0.0, 0.0);
    m1[1] = vec4(0.0, f2, 0.0, 0.0);
    m1[2] = vec4(0.0, 0.0, f3, 0.0);
    m1[3] = vec4(0.0, 0.0, 0.0, 1.0);

    m = m * m1;

    gl_Position = viewproj_matrix * m * position;
    vs_out.normal = mat3(view_matrix * m) * normal;
    vs_out.color = mix(color0, color1, fract(j * 313.431));
}
