#version 410

layout (location = 0) out vec4 color;

in vec4 gs_color;
in vec3 gs_normal;

void main(void)
{
    color = gs_color * vec4(1,0,gs_normal.z,1);//
    //color = gs_color * (0.2 + pow(abs(gs_normal.z), 4.0)) + vec4(1.0, 1.0, 1.0, 0.0) * pow(abs(gs_normal.z), 37.0);
}