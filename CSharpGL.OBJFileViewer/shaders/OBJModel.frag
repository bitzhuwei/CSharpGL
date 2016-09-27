#version 150 core

in vec2 pass_uv;
out vec4 out_Color;

uniform sampler2D tex;

void main(void)
{
    // TODO: this is where you should start with fragment shader. Only ASCII code are welcome.
    out_Color = texture(tex, pass_uv);
    // this is where your fragment shader ends.
}

