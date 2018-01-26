using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StencilShadowVolume
{
    partial class ExtrudeVolumeNode
    {
        private const string extrudeVert = @"#version 330

in vec3 Position;                                             

out vec3 PosL;
                                                                                    
void main()                                                                         
{                                                                                   
    PosL = Position;
}
";

        private const string extrudeGeom = @"#version 330

layout (triangles_adjacency) in;    // six vertices in
layout (triangle_strip, max_vertices = 18) out; // 4 per quad * 3 triangle vertices + 6 for near/far caps

in vec3 PosL[]; // an array of 6 vertices (triangle with adjacency)

uniform vec3 gLightPos;
uniform mat4 gProjectionView;
uniform mat4 gWorld;

float EPSILON = 0.0001;

// Emit a quad using a triangle strip
void EmitQuad(vec3 StartVertex, vec3 EndVertex)
{    
    // Vertex #1: the starting vertex (just a tiny bit below the original edge)
    vec3 LightDir = normalize(StartVertex - gLightPos);   
    gl_Position = gProjectionView * vec4((StartVertex + LightDir * EPSILON), 1.0);
    EmitVertex();
 
    // Vertex #2: the starting vertex projected to infinity
    gl_Position = gProjectionView * vec4(LightDir, 0.0);
    EmitVertex();
    
    // Vertex #3: the ending vertex (just a tiny bit below the original edge)
    LightDir = normalize(EndVertex - gLightPos);
    gl_Position = gProjectionView * vec4((EndVertex + LightDir * EPSILON), 1.0);
    EmitVertex();
    
    // Vertex #4: the ending vertex projected to infinity
    gl_Position = gProjectionView * vec4(LightDir , 0.0);
    EmitVertex();

    EndPrimitive();            
}


void main()
{
    vec3 worldPos[6]; 
	worldPos[0] = vec3(gWorld * vec4(PosL[0], 1.0));
    worldPos[1] = vec3(gWorld * vec4(PosL[1], 1.0));
    worldPos[2] = vec3(gWorld * vec4(PosL[2], 1.0));
    worldPos[3] = vec3(gWorld * vec4(PosL[3], 1.0));
    worldPos[4] = vec3(gWorld * vec4(PosL[4], 1.0));
    worldPos[5] = vec3(gWorld * vec4(PosL[5], 1.0));
    vec3 e1 = worldPos[2] - worldPos[0];
    vec3 e2 = worldPos[4] - worldPos[0];
    vec3 e3 = worldPos[1] - worldPos[0];
    vec3 e4 = worldPos[3] - worldPos[2];
    vec3 e5 = worldPos[4] - worldPos[2];
    vec3 e6 = worldPos[5] - worldPos[0];

    vec3 Normal = normalize(cross(e1,e2));
    vec3 LightDir = normalize(gLightPos - worldPos[0]);

    // Handle only light facing triangles
    if (dot(Normal, LightDir) > 0) {

        Normal = cross(e3,e1);

        if (dot(Normal, LightDir) <= 0) {
            vec3 StartVertex = worldPos[0];
            vec3 EndVertex = worldPos[2];
            EmitQuad(StartVertex, EndVertex);
        }

        Normal = cross(e4,e5);
        LightDir = gLightPos - worldPos[2];

        if (dot(Normal, LightDir) <= 0) {
            vec3 StartVertex = worldPos[2];
            vec3 EndVertex = worldPos[4];
            EmitQuad(StartVertex, EndVertex);
        }

        Normal = cross(e2,e6);
        LightDir = gLightPos - worldPos[4];

        if (dot(Normal, LightDir) <= 0) {
            vec3 StartVertex = worldPos[4];
            vec3 EndVertex = worldPos[0];
            EmitQuad(StartVertex, EndVertex);
        }

        // render the front cap
        LightDir = (normalize(worldPos[0] - gLightPos));
        gl_Position = gProjectionView * vec4((worldPos[0] + LightDir * EPSILON), 1.0);
        EmitVertex();

        LightDir = (normalize(worldPos[2] - gLightPos));
        gl_Position = gProjectionView * vec4((worldPos[2] + LightDir * EPSILON), 1.0);
        EmitVertex();

        LightDir = (normalize(worldPos[4] - gLightPos));
        gl_Position = gProjectionView * vec4((worldPos[4] + LightDir * EPSILON), 1.0);
        EmitVertex();
        EndPrimitive();
 
        // render the back cap
        LightDir = worldPos[0] - gLightPos;
        gl_Position = gProjectionView * vec4(LightDir, 0.0);
        EmitVertex();

        LightDir = worldPos[4] - gLightPos;
        gl_Position = gProjectionView * vec4(LightDir, 0.0);
        EmitVertex();

        LightDir = worldPos[2] - gLightPos;
        gl_Position = gProjectionView * vec4(LightDir, 0.0);
        EmitVertex();

        EndPrimitive();
    }
}
";
        private const string extrudeFrag = @"#version 330

out vec4 FragColor;

void main()
{
    if (int(gl_FragCoord.x - 0.5) % 2 == 1 && int(gl_FragCoord.y - 0.5) % 2 != 1) discard;
    if (int(gl_FragCoord.x - 0.5) % 2 != 1 && int(gl_FragCoord.y - 0.5) % 2 == 1) discard;

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
