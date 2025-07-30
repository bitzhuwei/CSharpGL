#version 410

// Uniforms
uniform mat4 model_matrix[4];
uniform mat4 projection_matrix;

// Regular vertex attributes
layout (location = 0) in vec4 position;
layout (location = 1) in vec3 normal;

// Instanced vertex attributes
layout (location = 3) in vec4 instance_weights;
layout (location = 4) in vec4 instance_color;

// Outputs to the fragment shader
out vec3 vs_fs_normal;
out vec4 vs_fs_color;

void main(void)
{
    int n;
    mat4 m = mat4(0.0);
    vec4 pos = position;
// Normalize the weights so that their sum total is 1.0
    vec4 weights = normalize(instance_weights);
    for (n = 0; n < 4; n++)
    {
// Calulate a weighted average of the matrices
        m += (model_matrix[n] * weights[n]);
    }
// Use that calculated matrix to transform the object.
    vs_fs_normal = normalize((m * vec4(normal, 0.0)).xyz);
    vs_fs_color = instance_color;
    gl_Position = projection_matrix * (m * pos);
}