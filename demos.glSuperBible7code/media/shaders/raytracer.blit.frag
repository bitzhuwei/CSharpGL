#version 420 core

layout (binding = 0) uniform sampler2D tex_composite;

layout (location = 0) out vec4 color;

void main(void)
{
    color = texelFetch(tex_composite, ivec2(gl_FragCoord.xy), 0);
}
