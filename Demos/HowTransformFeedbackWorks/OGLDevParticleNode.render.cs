using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace HowTransformFeedbackWorks
{
    partial class OGLDevParticleNode
    {
        private const string renderVert = @"
#version 330

in vec4 vposition;

void main() {
    gl_Position = vposition;
}
";
        private const string renderGeom =
         @"#version 330
layout (points) in;
layout (triangle_strip, max_vertices = 4) out;

uniform mat4 Projection;
uniform mat4 View;

out vec2 txcoord;

void main() {
    vec4 pos = View * gl_in[0].gl_Position;
    txcoord = vec2(-1, -1);
    gl_Position = Projection * (pos + 0.2 * vec4(txcoord, 0, 0));
    EmitVertex();
    txcoord = vec2( 1, -1);
    gl_Position = Projection * (pos + 0.2 * vec4(txcoord, 0, 0));
    EmitVertex();
    txcoord = vec2(-1,  1);
    gl_Position = Projection * (pos + 0.2 * vec4(txcoord, 0, 0));
    EmitVertex();
    txcoord = vec2( 1,  1);
    gl_Position = Projection * (pos + 0.2 * vec4(txcoord, 0, 0));
    EmitVertex();

    EndPrimitive();
}
";
        private const string renderFrag =
         @"#version 330
in vec2 txcoord;
layout(location = 0) out vec4 FragColor;
void main() {
    const vec4 color1 = vec4(0.6, 0.0, 0.0, 1.0);
    const vec4 color2 = vec4(0.9, 0.7, 1.0, 0.0);
    float distance = sqrt(dot(txcoord, txcoord));
    if (distance > 0.25) discard;
    FragColor = mix(color1, color2, smoothstep(0.1, 0.25, distance));
}
";
    }
}
