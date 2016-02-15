#version 150 core

uniform mat4 model_matrix;
uniform mat4 projection_matrix;
uniform int fur_layers;
uniform float fur_depth;
in VS_GS_VERTEX[] vertex_in;
out GS_FS_VERTEX vertex_out;

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

