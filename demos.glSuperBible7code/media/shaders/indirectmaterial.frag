#version 440 core

layout (location = 0) out vec4 o_color;

struct MaterialProperties
{
    vec4        ambient;
    vec4        diffuse;
    vec4        specular;
};

layout (binding = 2) uniform MATERIALS
{
    MaterialProperties material[100];
};

in VS_OUT
{
    smooth vec3 N;
    smooth vec3 L;
    smooth vec3 V;
    int material_id;
} fs_in;

void main(void)
{
    // Read material properties from array
    vec3 ambient = material[fs_in.material_id].ambient.rgb;
    vec3 specular_albedo = material[fs_in.material_id].specular.rgb;
    vec3 diffuse_albedo = material[fs_in.material_id].diffuse.rgb;
    float specular_power = material[fs_in.material_id].specular.a;

    // Normalize the incoming N, L and V vectors
    vec3 N = normalize(fs_in.N);
    vec3 L = normalize(fs_in.L);
    vec3 V = normalize(fs_in.V);
    vec3 H = normalize(L + V);

    // Compute the diffuse and specular components for each fragment
    vec3 diffuse = max(dot(N, L), 0.0) * diffuse_albedo;
    vec3 specular = pow(max(dot(N, H), 0.0), specular_power * 1.0) * specular_albedo;

    o_color = vec4(ambient + specular + diffuse, 1.0);
}
