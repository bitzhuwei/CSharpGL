#version 430 core

layout (binding = 0) uniform sampler2D input_image;

layout (location = 0) out vec4 color;

uniform float focal_distance = 50.0;
uniform float focal_depth = 30.0;

void main(void)
{
    // s will be used to scale our texture coordinates before
    // looking up data in our SAT image.
    vec2 s = 1.0 / textureSize(input_image, 0);
    // C is the center of the filter
    vec2 C = gl_FragCoord.xy;

    // First, retrieve the value of the SAT at the center
    // of the filter. The last channel of this value stores
    // the view-space depth of the pixel.
    vec4 v = texelFetch(input_image, ivec2(gl_FragCoord.xy), 0).rgba;

    // M will be the radius of our filter kernel
    float m;

    // For this application, we clear our depth image to zero
    // before rendering to it, so if it's still zero we haven't
    // rendered to the image here. Thus, we set our radius to 
    // 0.5 (i.e., a diameter of 1.0) and move on.
    if (v.w == 0.0)
    {
        m = 0.5;
    }
    else
    {
        // Calculate a circle of confusion
        m = abs(v.w - focal_distance);

        // Simple smoothstep scale and bias. Minimum radius is
        // 0.5 (diameter 1.0), maximum is 8.0. Box filter kernels
        // greater than about 16 pixels don't look good at all.
        m = 0.5 + smoothstep(0.0, focal_depth, m) * 7.5;
    }

    // Calculate the positions of the four corners of our
    // area to sample from.
    vec2 P0 = vec2(C * 1.0) + vec2(-m, -m);
    vec2 P1 = vec2(C * 1.0) + vec2(-m, m);
    vec2 P2 = vec2(C * 1.0) + vec2(m, -m);
    vec2 P3 = vec2(C * 1.0) + vec2(m, m);

    // Scale our coordinates.
    P0 *= s;
    P1 *= s;
    P2 *= s;
    P3 *= s;

    // Fetch the values of the SAT at the four corners
    vec3 a = textureLod(input_image, P0, 0).rgb;
    vec3 b = textureLod(input_image, P1, 0).rgb;
    vec3 c = textureLod(input_image, P2, 0).rgb;
    vec3 d = textureLod(input_image, P3, 0).rgb;

    // Calculate the sum of all pixels inside the kernel.
    vec3 f = a - b - c + d;

    // Scale radius -> diameter.
    m *= 2;

    // Divide through by area
    f /= float(m * m);

    // Outut final color
    color = vec4(f, 1.0);
}
