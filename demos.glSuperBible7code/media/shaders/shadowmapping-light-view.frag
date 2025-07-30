#version 420

layout (binding = 0) uniform sampler2D tex_depth;

layout (location = 0) out vec4 color;

void main(void)
{
    float d = texelFetch(tex_depth, ivec2(gl_FragCoord.xy * 3.0) + ivec2(850, 1050), 0).r;
    d = (d - 0.95) * 15.0;
    color = vec4(d);
}
