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
layout(location = 0) in vec4 vposition;
void main() {
   gl_Position = vposition;
}
";
        private const string renderGeom =
         @"#version 330
uniform mat4 View;
uniform mat4 Projection;
layout (points) in;
layout (triangle_strip, max_vertices = 4) out;
out vec2 txcoord;
void main() {
   vec4 pos = View*gl_in[0].gl_Position;
   txcoord = vec2(-1,-1);
   gl_Position = Projection*(pos+0.2*vec4(txcoord,0,0));
   EmitVertex();
   txcoord = vec2( 1,-1);
   gl_Position = Projection*(pos+0.2*vec4(txcoord,0,0));
   EmitVertex();
   txcoord = vec2(-1, 1);
   gl_Position = Projection*(pos+0.2*vec4(txcoord,0,0));
   EmitVertex();
   txcoord = vec2( 1, 1);
   gl_Position = Projection*(pos+0.2*vec4(txcoord,0,0));
   EmitVertex();
}
";
        private const string renderFrag =
         @"#version 330
in vec2 txcoord;
layout(location = 0) out vec4 FragColor;
void main() {
   float s = 0.2*(1/(1+15.*dot(txcoord, txcoord))-1/16.);
   FragColor = s*vec4(0.3,0.3,1.0,1);
} 
";
    }
}
