#version 440 core

layout (binding = 0) uniform sampler2D tex;

in vec2 uv;
layout (location = 0) out vec4 color;

void main(void)
{
    color = texture(tex, uv).xxxx;
}
