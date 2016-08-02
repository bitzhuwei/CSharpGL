#version 150 core

in float passTexCoord;

out vec4 out_Color;

uniform bool renderWireframe = true;
uniform sampler1D codedColorSampler;

void main(void) 
{
    if (renderWireframe)
	{
	    out_Color = vec4(1, 1, 1, 1.0f);
	}
	else
	{
	    //out_Color = vec4(passColor, 1.0f);
		vec4 color = texture(codedColorSampler, passTexCoord);
		out_Color = color;
	}
}
