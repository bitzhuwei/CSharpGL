#version 150 core

layout (triangles) in;
layout (triangle_strip, max_vertices = 240) out;

uniform mat4 model_matrix;
uniform mat4 projection_matrix;
uniform int fur_layers = 30;
uniform float fur_depth = 5;
in VS_GS_VERTEX
{
    vec3 normal;
    vec2 tex_coord;
} vertex_in[];

out GS_FS_VERTEX
{
    vec3 normal;
    vec2 tex_coord;
    Single fur_strength;
} vertex_out;


void main(void)
{
    int i, layer;
    float disp_delta = 1.0f / float(fur_layers);
    float d = 0.0f;
    vec4 position;
    for (layer = 0; layer < fur_layers; layer++)
    {
        for (i = 0; i < gl_in.length(); i++)
        {
            vec3 n = vertex_in[i].normal;
            vertex_out.normal = n;
            vertex_out.tex_coord = vertex_in[i].tex_coord;
            vertex_out.fur_strength = 1.0f - d;
            position = gl_in[i].gl_Position + vec4(n * d * fur_depth, 0.0f);
            gl_Position = projection_matrix * (model_matrix * position);
            EmitVertex();
        }
        d += disp_delta;
        EndPrimitive();
    }
}

