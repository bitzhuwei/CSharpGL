#version 420

out VS_OUT
{
    vec3    ray_origin;
    vec3    ray_direction;
} vs_out;

uniform vec3 ray_origin;
uniform mat4 ray_lookat;
uniform float aspect = 0.75;

uniform vec3 direction_scale = vec3(1.9, 1.9, 1.0);
uniform vec3 direction_bias = vec3(0.0, 0.0, 0.0);

void main(void)
{
    vec4 vertices[4] = vec4[4](vec4(-1.0, -1.0, 1.0, 1.0),
                               vec4( 1.0, -1.0, 1.0, 1.0),
                               vec4(-1.0,  1.0, 1.0, 1.0),
                               vec4( 1.0,  1.0, 1.0, 1.0));
    vec4 pos = vertices[gl_VertexID];

    gl_Position = pos;
    vs_out.ray_origin = ray_origin * vec3(1.0, 1.0, -1.0);
    // vs_out.ray_origin = vec3(0.0);
    vs_out.ray_direction = (ray_lookat * vec4(pos.xyz * direction_scale * vec3(1.0, aspect, 2.0) + direction_bias, 0.0)).xyz;
    // vs_out.ray_direction = pos.xyz * vec3(1.0, aspect, 4.0);
}
