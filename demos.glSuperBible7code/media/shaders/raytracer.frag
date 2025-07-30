#version 420

layout (location = 0) out vec3 color;
layout (location = 1) out vec3 position;
layout (location = 2) out vec3 reflected;
layout (location = 3) out vec3 refracted;
layout (location = 4) out vec3 reflected_color;
layout (location = 5) out vec3 refracted_color;

layout (binding = 0) uniform sampler2D tex_origin;
layout (binding = 1) uniform sampler2D tex_direction;
layout (binding = 2) uniform sampler2D tex_color;

struct ray
{
    vec3 origin;
    vec3 direction;
};

struct sphere
{
    vec3 center;
    float radius;
    vec4 color;
};

struct light
{
    vec3 position;
};

layout (std140, binding = 1) uniform SPHERES
{
    sphere      S[128];
};

layout (std140, binding = 2) uniform PLANES
{
    vec4        P[128];
};

layout (std140, binding = 3) uniform LIGHTS
{
    light       L[120];
} lights;

uniform int num_spheres = 7;
uniform int num_planes = 6;
uniform int num_lights = 5;

float intersect_ray_sphere(ray R,
                           sphere S,
                           out vec3 hitpos,
                           out vec3 normal)
{
    vec3 v = R.origin - S.center;
    float B = 2.0 * dot(R.direction, v);
    float C = dot(v, v) - S.radius * S.radius;
    float B2 = B * B;

    float f = B2 - 4.0 * C;

    if (f < 0.0)
        return 0.0;

    f = sqrt(f);
    float t0 = -B + f;
    float t1 = -B - f;
    float t = min(max(t0, 0.0), max(t1, 0.0)) * 0.5;

    if (t == 0.0)
        return 0.0;

    hitpos = R.origin + t * R.direction;
    normal = normalize(hitpos - S.center);

    return t;
}

bool intersect_ray_sphere2(ray R, sphere S, out vec3 hitpos, out vec3 normal)
{
    vec3 v = R.origin - S.center;
    float a = 1.0; // dot(R.direction, R.direction);
    float b = 2.0 * dot(R.direction, v);
    float c = dot(v, v) - (S.radius * S.radius);

    float num = b * b - 4.0 * a * c;

    if (num < 0.0)
        return false;

    float d = sqrt(num);
    float e = 1.0 / (2.0 * a);

    float t1 = (-b - d) * e;
    float t2 = (-b + d) * e;
    float t;

    if (t1 <= 0.0)
    {
        t = t2;
    }
    else if (t2 <= 0.0)
    {
        t = t1;
    }
    else
    {
        t = min(t1, t2);
    }

    if (t < 0.0)
        return false;

    hitpos = R.origin + t * R.direction;
    normal = normalize(hitpos - S.center);

    return true;
}

float intersect_ray_plane(ray R, vec4 P, out vec3 hitpos, out vec3 normal)
{
    vec3 O = R.origin;
    vec3 D = R.direction;
    vec3 N = P.xyz;
    float d = P.w;

    float denom = dot(D, N);

    if (denom == 0.0)
        return 0.0;

    float t = -(d + dot(O, N)) / denom;

    if (t < 0.0)
        return 0.0;

    hitpos = O + t * D;
    normal = N;

    return t;
}

bool point_visible_to_light(vec3 point, vec3 L)
{
    return true;

    int i;
    ray R;
    vec3 normal;
    vec3 hitpos;

    R.direction = normalize(L - point);
    R.origin = point + R.direction * 0.001;

    for (i = 0; i < num_spheres; i++)
    {
        if (intersect_ray_sphere(R, S[i], hitpos, normal) != 0.0)
        {
            return false;
        }
    }

    //*
    for (i = 0; i < num_planes; i++)
    {
        if (intersect_ray_plane(R, P[i], hitpos, normal) != 0.0)
        {
            return false;
        }
    }
    //*/

    return true;
}

vec3 light_point(vec3 position, vec3 normal, vec3 V, light l)
{
    vec3 ambient = vec3(0.0);

    if (!point_visible_to_light(position, l.position))
    {
        return ambient;
    }
    else
    {
        // vec3 V = normalize(-position);
        vec3 L = normalize(l.position - position);
        vec3 N = normal;
        vec3 R = reflect(-L, N);

        float rim = clamp(dot(N, V), 0.0, 1.0);
        rim = smoothstep(0.0, 1.0, 1.0 - rim);
        float diff = clamp(dot(N, L), 0.0, 1.0);
        float spec = pow(clamp(dot(R, N), 0.0, 1.0), 260.0);

        vec3 rim_color = vec3(0.0); // , 0.2, 0.2);
        vec3 diff_color = vec3(0.125); // , 0.8, 0.8);
        vec3 spec_color = vec3(0.1);

        return ambient + rim_color * rim + diff_color * diff + spec_color * spec;
    }
}

void main(void)
{
    ray R;

    R.origin = texelFetch(tex_origin, ivec2(gl_FragCoord.xy), 0).xyz;
    R.direction = normalize(texelFetch(tex_direction, ivec2(gl_FragCoord.xy), 0).xyz);
    vec3 input_color = texelFetch(tex_color, ivec2(gl_FragCoord.xy), 0).rgb;

    vec3 hit_position = vec3(0.0);
    vec3 hit_normal = vec3(0.0);

    color = vec3(0.0);
    position = vec3(0.0);
    reflected = vec3(0.0);
    refracted = vec3(0.0);
    reflected_color = vec3(0.0);
    refracted_color = vec3(0.0);

    if (all(lessThan(input_color, vec3(0.05))))
    {
        return;
    }

    R.origin += R.direction * 0.01;

    ray refl;
    ray refr;
    vec3 hitpos;
    vec3 normal;
    float min_t = 1000000.0f;
    int i;
    int sphere_index = 0;
    float t;

    for (i = 0; i < num_spheres; i++)
    {
        t = intersect_ray_sphere(R, S[i], hitpos, normal);
        if (t != 0.0)
        {
            if (t < min_t)
            {
                min_t = t;
                hit_position = hitpos;
                hit_normal = normal;
                sphere_index = i;
            }
        }
    }

    // int foobar[] = { 1, 0, 0, 0, 0, 0, 0 }; // 1, 1, 1, 1, 1, 1 };
    int foobar[] = { 1, 1, 1, 1, 1, 1, 1 };

    for (i = 0; i < 6; i++)
    {
        t = intersect_ray_plane(R, P[i], hitpos, normal);
        if (foobar[i] != 0 && t != 0.0)
        {
            if (t < min_t)
            {
                min_t = t;
                hit_position = hitpos;
                hit_normal = normal;
                sphere_index = i * 25;
            }
        }
    }

    if (min_t < 100000.0f)
    {
        vec3 my_color = vec3(0.0);

        for (i = 0; i < num_lights; i++)
        {
            my_color += light_point(hit_position, hit_normal, -R.direction, lights.L[i]);
        }

        my_color *= S[sphere_index].color.rgb;
        color = input_color * my_color;
        vec3 v = normalize(hit_position - R.origin);
        position = hit_position;
        reflected = reflect(v, hit_normal);
        reflected_color = /* input_color * */ S[sphere_index].color.rgb * 0.5;
        refracted = refract(v, hit_normal, 1.73);
        refracted_color = input_color * S[sphere_index].color.rgb * 0.5;
    }

    // color = (R.origin.zzz - 40.0) * 0.05;
    // color = R.direction;
}
