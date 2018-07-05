using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c14d03_ParticleSystem
{
    partial class ParticleNode
    {
        private const string renderVert = @"
#version 330

in vec3 inPosition;
in vec4 inVelocity;

out float life;

void main() {
    gl_Position = vec4(inPosition, 1.0);
    life = inVelocity.w;
}
";
        private const string renderGeom =
         @"#version 330
layout (points) in;
layout (triangle_strip, max_vertices = 4) out;

uniform mat4 projectionMat;
uniform mat4 viewMat;

in float life[];

out vec2 texCoord;
out float passLife;

void main() {
    passLife = life[0];

    vec4 pos = viewMat * gl_in[0].gl_Position;
    texCoord = vec2(-1, -1);
    gl_Position = projectionMat * (pos + 0.2 * vec4(texCoord, 0, 0));
    EmitVertex();
    texCoord = vec2( 1, -1);
    gl_Position = projectionMat * (pos + 0.2 * vec4(texCoord, 0, 0));
    EmitVertex();
    texCoord = vec2(-1,  1);
    gl_Position = projectionMat * (pos + 0.2 * vec4(texCoord, 0, 0));
    EmitVertex();
    texCoord = vec2( 1,  1);
    gl_Position = projectionMat * (pos + 0.2 * vec4(texCoord, 0, 0));
    EmitVertex();

    EndPrimitive();
}
";
        private const string renderFrag =
         @"#version 330

in vec2 texCoord;
in float passLife;

out vec4 outColor;

uniform vec4 color1 = vec4(0.3, 0.7, 0.1, 0.4);
uniform vec4 color2 = vec4(0.8, 0.2, 0.9, 0.1);

void main() {
    float distance = dot(texCoord, texCoord);
    if (distance > 0.5) discard;
    vec4 color = color1 * distance + color2 * (1.0 - distance);
    color.a *= (passLife / 2);
    outColor = color;
} 
";
    }
}
