#version 430 core

layout (binding = 0) uniform sampler2D tex;

layout (location = 0) out vec4 color;

in vec2 uv;

void main(void)
{
    color = texelFetch(tex, ivec2(gl_FragCoord.x, 511 - gl_FragCoord.y), 0).xxxx;
}
