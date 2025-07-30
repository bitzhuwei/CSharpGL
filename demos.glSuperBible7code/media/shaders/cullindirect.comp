#version 440 core

layout (local_size_x = 16) in;

struct CandidateDraw
{
    vec3 sphereCenter;
    float sphereRadius;
    uint firstVertex;
    uint vertexCount;
};

struct DrawArraysIndirectCommand
{
    uint vertexCount;
    uint instanceCount;
    uint firstVertex;
    uint baseInstance;
};

layout (binding = 0, std430) buffer CandidateDraws
{
    CandidateDraw draw[];
};

layout (binding = 1, std430) writeonly buffer OutputDraws
{
    DrawArraysIndirectCommand command[];
};

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

layout (binding = 0, offset = 0) uniform atomic_uint commandCounter;

void main(void)
{
#if 1
    mat4 view_matrix = transform_array[0];
    mat4 proj_matrix = transform_array[1];
    mat4 view_proj_matrix = transform_array[2];
#endif

    const CandidateDraw thisDraw = draw[gl_GlobalInvocationID.x];
    const mat4 thisModelMatrix = model_matrix[gl_GlobalInvocationID.x];

    vec4 position = view_proj_matrix * thisModelMatrix * vec4(thisDraw.sphereCenter, 1.0);

    if ((abs(position.x) - thisDraw.sphereRadius) < (position.w * 1.0) &&
        (abs(position.y) - thisDraw.sphereRadius) < (position.w * 1.0))
    {
        uint outDrawIndex = atomicCounterIncrement(commandCounter);

        command[outDrawIndex].vertexCount = thisDraw.vertexCount;
        command[outDrawIndex].instanceCount = 1;
        command[outDrawIndex].firstVertex = thisDraw.firstVertex;
        command[outDrawIndex].baseInstance = uint(gl_GlobalInvocationID.x);
    }
}
