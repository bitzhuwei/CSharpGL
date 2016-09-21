#version 430 core

layout (location = 0) out vec4 color;
in vec2 passUV;

layout (binding = 0) uniform sampler2D output_image;

void main(void)
{
	color = texture(output_image, passUV);
}
