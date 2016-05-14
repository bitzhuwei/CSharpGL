#version 430 core

layout (location = 0) out vec4 color;

layout (binding = 0) uniform sampler2D output_image;

void main(void)
{
    color = abs(texture(output_image, vec2(1.0, -1.0) * vec2(gl_FragCoord.xy) / vec2(textureSize(output_image, 0)))) * 1.0;
}
