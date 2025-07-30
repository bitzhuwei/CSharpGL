#version 430 core

layout (binding = 0) uniform sampler2D tex;

layout (location = 0) out vec4 color;

in vec2 uv;

void main(void)
{
    color = texture(tex, uv);
}
