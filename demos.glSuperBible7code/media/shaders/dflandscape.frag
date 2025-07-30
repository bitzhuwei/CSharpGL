#version 430 core

layout (location = 0) out vec4 color;

layout (binding = 0) uniform sampler2D map_texture;
layout (binding = 1) uniform sampler2D grass_texture;
layout (binding = 2) uniform sampler2D rock_texture;

// in vec2 uv;
in vec3 uv;

void main(void)
{
    vec4 c1 = texture(grass_texture, uv.xy * 12.0);
    vec4 c2 = texture(rock_texture, uv.xy * 12.0);
    float val = texture(map_texture, uv.xy).x;

    color = mix(c1, c2, smoothstep(0.52, 0.48, val * 1.0).x);
}
