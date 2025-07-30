#version 430 core

layout (local_size_x = 1024) in;

shared vec3 shared_data[gl_WorkGroupSize.x * 2];

layout (binding = 0, rgba32f) readonly uniform image2D input_image;
layout (binding = 1, rgba32f) writeonly uniform image2D output_image;

void main(void)
{
    uint id = gl_LocalInvocationID.x;
    uint rd_id;
    uint wr_id;
    uint mask;
    ivec2 P0 = ivec2(id * 2, gl_WorkGroupID.x);
    ivec2 P1 = ivec2(id * 2 + 1, gl_WorkGroupID.x);

    const uint steps = uint(log2(gl_WorkGroupSize.x)) + 1;
    uint step = 0;

    vec4 i0 = imageLoad(input_image, P0);
    vec4 i1 = imageLoad(input_image, P1);

    shared_data[P0.x] = i0.rgb;
    shared_data[P1.x] = i1.rgb;

    barrier();

    for (step = 0; step < steps; step++)
    {
        mask = (1 << step) - 1;
        rd_id = ((id >> step) << (step + 1)) + mask;
        wr_id = rd_id + 1 + (id & mask);

        shared_data[wr_id] += shared_data[rd_id];

        barrier();
    }

    imageStore(output_image, P0.yx, vec4(shared_data[P0.x], i0.a));
    imageStore(output_image, P1.yx, vec4(shared_data[P1.x], i1.a));
}
