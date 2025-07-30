#version 420 core
// Output
layout (location = 0) out vec4 color;

// Texture
// 410 not support binding
layout (binding = 0) uniform sampler2D tex;

// Input from vertex shader
in VS_OUT
{
    vec3 N;
    vec3 L;
    vec3 V;
    vec2 tc;
} fs_in;

// Material properties
const vec3 diffuse_albedo = vec3(0.5, 0.5, 0.9);
const vec3 specular_albedo = vec3(0.7);
const float specular_power = 300.0;

void main(void)
{
    // Normalize the incoming N, L and V vectors
    vec3 N = normalize(fs_in.N);
    vec3 L = normalize(fs_in.L);
    vec3 V = normalize(fs_in.V);
    vec3 H = normalize(L + V);

    // Compute the diffuse and specular components for each fragment
    vec3 diffuse = max(dot(N, L), 0.0) * diffuse_albedo;
    vec3 specular = pow(max(dot(N, H), 0.0), specular_power) * specular_albedo;

    // Write final color to the framebuffer
    float factor = texture(tex, fs_in.tc).x;
    vec4 lit = vec4(mix(diffuse, diffuse.yzx, factor)+ specular, 1.0);
    color = lit;
}
