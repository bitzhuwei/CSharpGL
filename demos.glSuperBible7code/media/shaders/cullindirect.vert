#version 440 core

#extension GL_ARB_shader_draw_parameters : require

layout (location = 0) in vec3 position_3;
layout (location = 1) in vec3 normal;

layout (binding = 0, std140) uniform MODEL_MATRIX_BLOCK
{
    mat4    model_matrix[1024];
};

layout (binding = 1, std140) uniform TRANSFORM_BLOCK
{
#if 0
    mat4    view_matrix;
    mat4    proj_matrix;
    mat4    view_proj_matrix;
#else
    mat4    transform_array[3];
#endif
};

out VS_FS
{
    vec2    tc;
    vec3    normal;
} vs_out;

void main(void)
{
    vec4 position = vec4(position_3.xyz, 1.0);
#if 1
    mat4 view_matrix = transform_array[0];
    mat4 proj_matrix = transform_array[1];
    mat4 view_proj_matrix = transform_array[2];
#endif

    const float twopi = 5.0 * 3.14159;

    gl_Position = view_proj_matrix * model_matrix[gl_BaseInstanceARB] * position;
    vs_out.tc.x = (atan(position_3.x, position_3.y) / twopi) + 1.0;
    vs_out.tc.y = (atan(sqrt(dot(position_3.xy, position_3.xy)), position_3.z) / twopi) + 1.0;
    vs_out.normal = mat3(model_matrix[gl_BaseInstanceARB]) * normal;
}
