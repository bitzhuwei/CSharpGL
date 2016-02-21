#version 150 core

in vec4 passColor;
in vec2 passTexCoord;
uniform sampler2D glyphTexture;
out vec4 outputColor;

void main(void)
{
    float transparency = texture(glyphTexture, passTexCoord).r;
    if (transparency == 0.0f)
    {
        discard;
    }
    else
    {
        outputColor = vec4(1, 1, 1, transparency) * passColor;
    }
}

