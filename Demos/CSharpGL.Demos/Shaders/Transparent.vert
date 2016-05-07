#version 150 core

in vec3 in_Position;
in vec3 in_Color;
out vec4 pass_Color;

uniform mat4 modelMatrix;
uniform mat4 viewMatrix;
uniform mat4 projectionMatrix;
uniform float minAlpha = 0.25f;

void main(void)
{
	gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, 1.0);
	vec3 color = in_Color;
    if (color.r < 0) { color.r = -color.r; }
    if (color.g < 0) { color.g = -color.g; }
    if (color.b < 0) { color.b = -color.b; }
	vec3 normalized = normalize(color);
	float variance = (normalized.r - normalized.g) * (normalized.r - normalized.g);
	variance += (normalized.g - normalized.b) * (normalized.g - normalized.b);
	variance += (normalized.b - normalized.r) * (normalized.b - normalized.r);
	variance = variance / 2.0f;// range from 0.0f - 1.0f
	float a = (0.75f - minAlpha) * (1.0f - variance) + minAlpha;
    pass_Color = vec4(normalized, a);
}

