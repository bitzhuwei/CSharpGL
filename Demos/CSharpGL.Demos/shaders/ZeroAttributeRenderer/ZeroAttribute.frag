#version 430 core

uniform sampler2D u_texture; 

in vec2 v_texCoord;

out vec4 fragColor;

void main(void)
{
	//fragColor = texture(u_texture, v_texCoord);
	fragColor = vec4(v_texCoord, v_texCoord.x / 2 + v_texCoord.y / 2, 1.0f);
}
