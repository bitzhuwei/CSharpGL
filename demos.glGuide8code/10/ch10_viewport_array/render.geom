#version 410

layout (triangles, invocations = 4) in;
layout (triangle_strip, max_vertices = 3) out;

uniform mat4 model_matrix[4];
uniform mat4 projection_matrix;

in vec3 vs_normal[];

out vec4 gs_color;
out vec3 gs_normal;

const vec4 colors[4] = vec4[4]
(
    vec4(1.0, 0.7, 0.3, 1.0),
    vec4(1.0, 0.2, 0.3, 1.0),
    vec4(0.1, 0.6, 1.0, 1.0),
    vec4(0.3, 0.7, 0.5, 1.0)
);

void main(void)
{
    for (int i = 0; i < 4; i++)
    {
        gl_ViewportIndex = i;
        gs_color = colors[i];
        gs_normal = (model_matrix[i] * vec4(vs_normal[i], 0.0)).xyz;
        for (int i = 0; i < gl_in.length(); i++) {
            gl_Position = projection_matrix *
                      (model_matrix[i] * gl_in[i].gl_Position);
            EmitVertex();
        }
        EndPrimitive();
    }
}