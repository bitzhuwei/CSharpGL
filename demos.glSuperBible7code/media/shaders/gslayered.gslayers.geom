#version 430 core

layout (invocations = 16, triangles) in;
layout (triangle_strip, max_vertices = 3) out;

in VS_OUT
{
    vec4 color;
    vec3 normal;
} gs_in[];

out GS_OUT
{
    vec4 color;
    vec3 normal;
} gs_out;

layout (binding = 0) uniform BLOCK
{
    mat4 proj_matrix;
    mat4 mv_matrix[16];
};

void main(void)
{
    int i;

    const vec4 colors[16] = vec4[16](
        vec4(0.0, 0.0, 1.0, 1.0), vec4(0.0, 1.0, 0.0, 1.0),
        vec4(0.0, 1.0, 1.0, 1.0), vec4(1.0, 0.0, 1.0, 1.0),
        vec4(1.0, 1.0, 0.0, 1.0), vec4(1.0, 1.0, 1.0, 1.0),
        vec4(0.0, 0.0, 0.5, 1.0), vec4(0.0, 0.5, 0.0, 1.0),
        vec4(0.0, 0.5, 0.5, 1.0), vec4(0.5, 0.0, 0.0, 1.0),
        vec4(0.5, 0.0, 0.5, 1.0), vec4(0.5, 0.5, 0.0, 1.0),
        vec4(0.5, 0.5, 0.5, 1.0), vec4(1.0, 0.5, 0.5, 1.0),
        vec4(0.5, 1.0, 0.5, 1.0), vec4(0.5, 0.5, 1.0, 1.0)
    );

    for (i = 0; i < gl_in.length(); i++)
    {
        gs_out.color = colors[gl_InvocationID];
        gs_out.normal = mat3(mv_matrix[gl_InvocationID]) * gs_in[i].normal;
        gl_Position = proj_matrix * mv_matrix[gl_InvocationID] * gl_in[i].gl_Position;
        gl_Layer = gl_InvocationID;
        EmitVertex();
    }

    EndPrimitive();
}
