#version 440 core

layout (binding = 0) uniform sampler2D sparseTex;

layout (binding = 0, std140) uniform TEXURE_BLOCK
{
    uint foo;
};

in vec2 uv;

layout (location = 0) out vec4 o_color;

void main(void)
{
    // o_color = vec4(0.3, 0.6, 0.0, 1.0);
    o_color = textureLod(sparseTex, uv, 0.0);
}
