#version 430 core

uniform sampler2D s;

uniform float exposure = 1;

out vec4 color;

void main(void)
{
    color = texture(s, gl_FragCoord.xy / textureSize(s, 0)) * exposure;
}