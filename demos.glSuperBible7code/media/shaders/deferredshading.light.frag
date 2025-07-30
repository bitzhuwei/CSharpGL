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

vec4 light_fragment(fragment_info_t fragment)
{
    int i;
    vec4 result = vec4(0.0, 0.0, 0.0, 1.0);

    if (fragment.material_id != 0)
    {
        for (i = 0; i < num_lights; i++)
        {
            vec3 L = light[i].position - fragment.ws_coord;
            float dist = length(L);
            L = normalize(L);
            vec3 N = normalize(fragment.normal);
            vec3 R = reflect(-L, N);
            float NdotR = max(0.0, dot(N, R));
            float NdotL = max(0.0, dot(N, L));
            float attenuation = 50.0 / (pow(dist, 2.0) + 1.0);

            vec3 diffuse_color  = 1.0 * light[i].color * fragment.color * NdotL * attenuation;
            vec3 specular_color = vec3(1.0) /* * light[i].color */ * pow(NdotR, fragment.specular_power) * attenuation;

            result += vec4(diffuse_color + specular_color, 0.0);
        }
    }

    return result;
}

void main(void)
{
    fragment_info_t fragment;

    unpackGBuffer(ivec2(gl_FragCoord.xy), fragment);

    color_out = light_fragment(fragment);
}
