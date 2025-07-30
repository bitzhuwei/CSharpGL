#version 410 core

layout (triangles) in;
layout (line_strip, max_vertices = 4) out;

uniform mat4 mv_matrix;
uniform mat4 proj_matrix;

in VS_OUT
{
    vec3 normal;
    vec4 color;
} gs_in[];

out GS_OUT
{
    vec3 normal;
    vec4 color;
} gs_out;

uniform float normal_length = 0.2;

void main(void)
{
    mat4 mvp = proj_matrix * mv_matrix;
    vec3 ab = gl_in[1].gl_Position.xyz - gl_in[0].gl_Position.xyz;
    vec3 ac = gl_in[2].gl_Position.xyz - gl_in[0].gl_Position.xyz;
    vec3 face_normal = normalize(cross(ab, ac));

    vec4 tri_centroid = (gl_in[0].gl_Position +
                         gl_in[1].gl_Position +
                         gl_in[2].gl_Position) / 3.0;

    gl_Position = mvp * tri_centroid;
    gs_out.normal = gs_in[0].normal;
    gs_out.color = gs_in[0].color;
    EmitVertex();

    gl_Position = mvp * (tri_centroid +
                         vec4(face_normal * normal_length, 0.0));
    gs_out.normal = gs_in[0].normal;
    gs_out.color = gs_in[0].color;
    EmitVertex();
    EndPrimitive();

    gl_Position = mvp * gl_in[0].gl_Position;
    gs_out.normal = gs_in[0].normal;
    gs_out.color = gs_in[0].color;
    EmitVertex();

    gl_Position = mvp * (gl_in[0].gl_Position +
                         vec4(gs_in[0].normal * normal_length, 0.0));
    gs_out.normal = gs_in[0].normal;
    gs_out.color = gs_in[0].color;
    EmitVertex();
    EndPrimitive();
}