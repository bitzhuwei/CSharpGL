#version 150 core

uniform sampler2D sprite_texture;

out vec4 color;

void main(void)
{
	vec4 top         = texture(sprite_texture, vec2(gl_PointCoord.x, gl_PointCoord.y + 1.0 / 200.0));
vec4 bottom      = texture(sprite_texture, vec2(gl_PointCoord.x, gl_PointCoord.y - 1.0 / 200.0));
vec4 left        = texture(sprite_texture, vec2(gl_PointCoord.x - 1.0 / 300.0, gl_PointCoord.y));
vec4 right       = texture(sprite_texture, vec2(gl_PointCoord.x + 1.0 / 300.0, gl_PointCoord.y));
vec4 topLeft     = texture(sprite_texture, vec2(gl_PointCoord.x - 1.0 / 300.0, gl_PointCoord.y + 1.0 / 200.0));
vec4 topRight    = texture(sprite_texture, vec2(gl_PointCoord.x + 1.0 / 300.0, gl_PointCoord.y + 1.0 / 200.0));
vec4 bottomLeft  = texture(sprite_texture, vec2(gl_PointCoord.x - 1.0 / 300.0, gl_PointCoord.y - 1.0 / 200.0));
vec4 bottomRight = texture(sprite_texture, vec2(gl_PointCoord.x + 1.0 / 300.0, gl_PointCoord.y - 1.0 / 200.0));
vec4 sx = -topLeft - 2 * left - bottomLeft + topRight   + 2 * right  + bottomRight;
vec4 sy = -topLeft - 2 * top  - topRight   + bottomLeft + 2 * bottom + bottomRight;
vec4 sobel = sqrt(sx * sx + sy * sy);
color = sobel;
}
