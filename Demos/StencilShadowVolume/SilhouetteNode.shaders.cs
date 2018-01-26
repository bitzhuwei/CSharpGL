using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StencilShadowVolume
{
    partial class SilhouetteNode
    {
        private const string silhouetteVert = @"#version 330

in vec3 Position;                                             

out vec3 WorldPos0;                                                                 

uniform mat4 gWVP;                                                  
uniform mat4 gWorld;                                                
                                                                                    
void main()                                                                         
{                                                                                   
    vec4 PosL   = vec4(Position, 1.0);
    gl_Position = gWVP * PosL;
    WorldPos0   = (gWorld * PosL).xyz;                                
}
";

        private const string silhouetteGeom = @"#version 330

layout (triangles_adjacency) in;
layout (line_strip, max_vertices = 6) out;

in vec3 WorldPos0[];

void EmitLine(int StartIndex, int EndIndex)
{
    gl_Position = gl_in[StartIndex].gl_Position;
    EmitVertex();

    gl_Position = gl_in[EndIndex].gl_Position;
    EmitVertex();

    EndPrimitive();
}

uniform vec3 gLightPos;

void main()
{
    vec3 e1 = WorldPos0[2] - WorldPos0[0];
    vec3 e2 = WorldPos0[4] - WorldPos0[0];
    vec3 e3 = WorldPos0[1] - WorldPos0[0];
    vec3 e4 = WorldPos0[3] - WorldPos0[2];
    vec3 e5 = WorldPos0[4] - WorldPos0[2];
    vec3 e6 = WorldPos0[5] - WorldPos0[0];

    vec3 Normal = cross(e1,e2);
    vec3 LightDir = gLightPos - WorldPos0[0];

    if (dot(Normal, LightDir) > 0.00001) {

        Normal = cross(e3,e1);

        if (dot(Normal, LightDir) <= 0) {
            EmitLine(0, 2);
        }

        Normal = cross(e4,e5);
        LightDir = gLightPos - WorldPos0[2];

        if (dot(Normal, LightDir) <=0) {
            EmitLine(2, 4);
        }

        Normal = cross(e2,e6);
        LightDir = gLightPos - WorldPos0[4];

        if (dot(Normal, LightDir) <= 0) {
            EmitLine(4, 0);
        }
    }
}
";
        private const string silhouetteFrag = @"#version 330

out vec4 FragColor;

void main()
{      
    FragColor = vec4(1, 1, 1, 1);
}
";
        private const string vertexCode = @"#version 330

in vec3 inPosition;
in vec3 inColor;

uniform mat4 mvpMat;

out vec3 passColor;

void main(void) {
	gl_Position = mvpMat * vec4(inPosition, 1.0);
    passColor = inColor;
}
";
        private const string fragmentCode = @"#version 330

in vec3 passColor;

out vec4 out_Color;

void main(void) {
	out_Color = vec4(passColor, 1.0);
}
";
    }
}
