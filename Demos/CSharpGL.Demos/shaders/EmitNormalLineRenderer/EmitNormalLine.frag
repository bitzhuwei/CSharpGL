#version 150 core

in vec4 pass_Normal;
in GS_FS_VERTEX
{
    vec3 color;
} fragment_in;

out vec4 outColor;
uniform float minAlpha = 0.25f;

void main(void)
{
    // TODO: this is where you should start with fragment shader. Only ASCII code are welcome.
    vec3 color = fragment_in.color;
    if (color.r < 0) { color.r = -color.r; }
    if (color.g < 0) { color.g = -color.g; }
    if (color.b < 0) { color.b = -color.b; }
	vec3 normalized = normalize(color);
	float variance = (normalized.r - normalized.g) * (normalized.r - normalized.g);
	variance += (normalized.g - normalized.b) * (normalized.g - normalized.b);
	variance += (normalized.b - normalized.r) * (normalized.b - normalized.r);
	variance = variance / 2.0f;// range from 0.0f - 1.0f
	float a = (0.75f - minAlpha) * (1.0f - variance) + minAlpha;
    outColor = vec4(color, a);
    // this is where your fragment shader ends.
}

