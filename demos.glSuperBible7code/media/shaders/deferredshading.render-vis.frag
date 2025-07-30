#version 420

layout (location = 0) out vec4 color_out;

layout (binding = 0) uniform usampler2D gbuf_tex0;
layout (binding = 1) uniform sampler2D gbuf_tex1;

struct light_t
{
    vec3    position;
    uint    pad0;
    vec3    color;
    uint    pad1;
};

uniform int num_lights = 64;
uniform int vis_mode = 1;

layout (std140) uniform light_block
{
    light_t     light[64];
};

struct fragment_info_t
{
    vec3 color;
    vec3 normal;
    float specular_power;
    vec3 ws_coord;
    uint material_id;
};

void unpackGBuffer(ivec2 coord,
                   out fragment_info_t fragment)
{
    uvec4 data0 = texelFetch(gbuf_tex0, ivec2(coord), 0);
    vec4 data1 = texelFetch(gbuf_tex1, ivec2(coord), 0);
    vec2 temp;

    temp = unpackHalf2x16(data0.y);
    fragment.color = vec3(unpackHalf2x16(data0.x), temp.x);
    fragment.normal = normalize(vec3(temp.y, unpackHalf2x16(data0.z)));
    fragment.material_id = data0.w;

    fragment.ws_coord = data1.xyz;
    fragment.specular_power = data1.w;
}

vec4 vis_fragment(fragment_info_t fragment)
{
    vec4 result = vec4(0.0);

    switch (vis_mode)
    {
        case 1:
        default:
            result = vec4(fragment.normal * 0.5 + vec3(0.5), 1.0);
            break;
        case 2:
            result = vec4(fragment.ws_coord * 0.02 + vec3(0.5, 0.5, 0.0), 1.0);
            break;
        case 3:
            result = vec4(fragment.color, 1.0);
            break;
        case 4:
            result = vec4(fragment.specular_power,
                          float(fragment.material_id & 15) / 15.0,
                          float(fragment.material_id / 16) / 15.0,
                          1.0);
            break;
    }

    return result;
}

void main(void)
{
    fragment_info_t fragment;

    unpackGBuffer(ivec2(gl_FragCoord.xy), fragment);

    color_out = vis_fragment(fragment);
}
