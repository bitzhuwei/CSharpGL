#version 430 core

layout (location = 0) out vec4 color;

// layout (binding = 0) uniform sampler2D sdf_texture;
layout (binding = 0) uniform sampler2DArray sdf_texture;

// in vec2 uv;
in vec3 uv;

void main(void)
{
    const vec4 c1 = vec4(0.1, 0.1, 0.2, 1.0);
    const vec4 c2 = vec4(0.8, 0.9, 1.0, 1.0);
    float val = texture(sdf_texture, vec3(uv.xyz)).x;

    color = mix(c1, c2, smoothstep(0.52, 0.48, val));
}
