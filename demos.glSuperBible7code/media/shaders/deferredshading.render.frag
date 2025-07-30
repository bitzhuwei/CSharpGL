#version 420 core

layout (location = 0) out uvec4 color0;
layout (location = 1) out vec4 color1;

in VS_OUT
{
    vec3    ws_coords;
    vec3    normal;
    vec3    tangent;
    vec2    texcoord0;
    flat uint    material_id;
} fs_in;

layout (binding = 0) uniform sampler2D tex_diffuse;

void main(void)
{
    uvec4 outvec0 = uvec4(0);
    vec4 outvec1 = vec4(0);

    vec3 color = texture(tex_diffuse, fs_in.texcoord0).rgb;

    outvec0.x = packHalf2x16(color.xy);
    outvec0.y = packHalf2x16(vec2(color.z, fs_in.normal.x));
    outvec0.z = packHalf2x16(fs_in.normal.yz);
    outvec0.w = fs_in.material_id;

    outvec1.xyz = fs_in.ws_coords;
    outvec1.w = 30.0;

    color0 = outvec0;
    color1 = outvec1;
}
