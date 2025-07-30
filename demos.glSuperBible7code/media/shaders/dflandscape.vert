#version 430 core

out vec3 uv;

layout (location = 0) uniform mat3 uv_transform;
layout (location = 1) uniform mat4 mvp_matrix;

void main(void)
{
    const vec2 pos[] = vec2[](vec2(-1.0, -1.0),
                              vec2(1.0, -1.0),
                              vec2(-1.0, 1.0),
                              vec2(1.0, 1.0));

    vec3 uv3 = uv_transform * vec3(pos[gl_VertexID], 1.0) + vec3(1.0, 1.0, 0.0) * vec3(0.5, -0.5, 1.0);
    uv.xy = uv3.xy / uv3.z;
    uv.z = float(gl_InstanceID);
    gl_Position = mvp_matrix * vec4(pos[gl_VertexID] + vec2(gl_InstanceID * 2, 0.0), 0.0, 1.0);
}
