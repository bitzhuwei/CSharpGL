#version 150 core

in vec2 passTexCoord;

out vec4 out_Color;

uniform sampler2D tex;
uniform bool original = true;

void main(void) {
	if (original)
	{
		out_Color = texture(tex, passTexCoord);
	}
	else
	{
		vec4 top         = texture(tex, vec2(passTexCoord.x, passTexCoord.y + 1.0 / 200.0));
		vec4 bottom      = texture(tex, vec2(passTexCoord.x, passTexCoord.y - 1.0 / 200.0));
		vec4 left        = texture(tex, vec2(passTexCoord.x - 1.0 / 300.0, passTexCoord.y));
		vec4 right       = texture(tex, vec2(passTexCoord.x + 1.0 / 300.0, passTexCoord.y));
		vec4 topLeft     = texture(tex, vec2(passTexCoord.x - 1.0 / 300.0, passTexCoord.y + 1.0 / 200.0));
		vec4 topRight    = texture(tex, vec2(passTexCoord.x + 1.0 / 300.0, passTexCoord.y + 1.0 / 200.0));
		vec4 bottomLeft  = texture(tex, vec2(passTexCoord.x - 1.0 / 300.0, passTexCoord.y - 1.0 / 200.0));
		vec4 bottomRight = texture(tex, vec2(passTexCoord.x + 1.0 / 300.0, passTexCoord.y - 1.0 / 200.0));
		vec4 sx = -topLeft - 2 * left - bottomLeft + topRight   + 2 * right  + bottomRight;
		vec4 sy = -topLeft - 2 * top  - topRight   + bottomLeft + 2 * bottom + bottomRight;
		vec4 sobel = sqrt(sx * sx + sy * sy);
		out_Color = sobel;
	}
}
