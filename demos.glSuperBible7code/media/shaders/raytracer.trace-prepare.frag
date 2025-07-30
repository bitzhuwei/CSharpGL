#version 420 core

in VS_OUT
{
    vec3    ray_origin;
    vec3    ray_direction;
} fs_in;

layout (location = 0) out vec3 color;
layout (location = 1) out vec3 origin;
layout (location = 2) out vec3 reflected;
layout (location = 3) out vec3 refracted;
layout (location = 4) out vec3 reflected_color;
layout (location = 5) out vec3 refracted_color;

void main(void)
{
    color = vec3(0.0);
    origin = fs_in.ray_origin;
    reflected = fs_in.ray_direction;
    refracted = vec3(0.0);
    reflected_color = vec3(1.0);
    refracted_color = vec3(0.0);
}
