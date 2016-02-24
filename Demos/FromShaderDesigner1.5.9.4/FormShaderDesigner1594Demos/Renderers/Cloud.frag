#version 150 core

in vec3 MCposition;
in float LightIntensity;
out vec4 outputColor;
uniform float TIME_FROM_INIT;
uniform sampler3D Noise;
uniform vec3 SkyColor;
uniform vec3 CloudColor;

void main(void)
{
    float offset = TIME_FROM_INIT * 0.0001f;
    vec3 Offset = vec3(-offset, offset, offset); // uncomment this line for animation
    vec4 noisevec = texture(Noise, MCposition + Offset);
    float intensity = (noisevec[0] + noisevec[1] +
                       noisevec[2] + noisevec[3] + 0.03125f) * 1.5f;
    vec3 color = mix(SkyColor, CloudColor, intensity) * LightIntensity;
    color = clamp(color, 0.0f, 1.0f);
    outputColor = vec4(color, 1.0f);
}

