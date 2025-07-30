#version 420 core

layout (quads, fractional_odd_spacing, ccw) in;

uniform mat4 mv_matrix;
uniform mat4 proj_matrix;

out vec3 normal;

void main(void)
{
    vec4 mid1 = mix(gl_in[0].gl_Position, gl_in[1].gl_Position, gl_TessCoord.x);
    vec4 mid2 = mix(gl_in[2].gl_Position, gl_in[3].gl_Position, gl_TessCoord.x);
    vec4 pos = mix(mid1, mid2, gl_TessCoord.y);
    pos.xyz = /* normalize*/(pos.xyz) * 0.25;
    normal = normalize(mat3(mv_matrix) * pos.xyz);
    gl_Position = proj_matrix * mv_matrix * pos;
}