using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace TerrainLoading
{
    partial class TerainNode
    {
        private const string vert = @"#version 330 core
  
//uniforms
uniform mat4 mvpMat;					//combined modelview projection matrix
uniform ivec2 terrainSize;	//half terrain size
uniform sampler2D heightMapTexture;	//heightmap texture
uniform float scale;				//scale for the heightmap height

void main()
{   
    float u = float(gl_VertexID % terrainSize.x) / float(terrainSize.x - 1);
    float v = float(gl_VertexID / terrainSize.x) / float(terrainSize.y - 1);
	float height = (texture(heightMapTexture, vec2(u, v)).r - 0.5) * scale;

    float x = (u - 0.5) * terrainSize.x;
    float z = (v - 0.5) * terrainSize.y;

	gl_Position = mvpMat*vec4(x, height, z, 1);			
}
";

        private const string frag = @"#version 330 core
 
layout (location=0) out vec4 outColor;	//fragment shader output

void main()
{
   outColor = vec4(1, 1, 1, 1);
}
";
    }
}
