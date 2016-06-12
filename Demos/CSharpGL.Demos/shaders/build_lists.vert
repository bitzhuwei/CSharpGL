#version 330

layout (location = 0) in vec3 position;
layout (location = 1) in vec3 normal;

uniform mat4 model_matrix;
uniform mat4 view_matrix;
uniform mat4 projection_matrix;

uniform float minAlpha = 0.5f;

out vec4 surface_color;

void main(void)
{
    vec3 color = normal;
    if (color.r < 0) { color.r = -color.r; }
    if (color.g < 0) { color.g = -color.g; }
    if (color.b < 0) { color.b = -color.b; }
	vec3 normalized = normalize(color);
	float variance = (normalized.r - normalized.g) * (normalized.r - normalized.g);
	variance += (normalized.g - normalized.b) * (normalized.g - normalized.b);
	variance += (normalized.b - normalized.r) * (normalized.b - normalized.r);
	variance = variance / 2.0f;// range from 0.0f - 1.0f
	float a = (0.75f - minAlpha) * (1.0f - variance) + minAlpha;
    surface_color = vec4(normalized, a);

    gl_Position = projection_matrix * view_matrix * model_matrix * vec4(position, 1.0f);
}
