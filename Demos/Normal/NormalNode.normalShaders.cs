using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace Normal
{
    public partial class NormalNode
    {
        private const string normalVertex = @"#version 150 core

in vec3 vPosition;
in vec3 vNormal;
out VS_GS_VERTEX
{
    vec3 normal;
} vertex_out;

void main(void)
{
    gl_Position = vec4(vPosition, 1.0f);
    vertex_out.normal = vNormal;
}
";
        private const string normalGeometry = @"#version 150 core

layout (triangles) in;
layout (lines, max_vertices = 2) out;

uniform mat4 projectionMatrix;
uniform mat4 viewMatrix;
uniform mat4 modelMatrix;
uniform float normalLength = 0.5;

in VS_GS_VERTEX
{
    vec3 normal;
} vertex_in[];

out GS_FS_VERTEX
{
    vec3 color;
} vertex_out;

void main(void)
{
	for (int i = 0; i < gl_in.length(); i++)
	{
		vec4 position = gl_in[i].gl_Position;
		vec4 target = vec4(position.xyz + normalize(vertex_in[i].normal) * normalLength, 1.0f);
		
		vertex_out.color = vec3(1, 1, 1);
        gl_Position = projectionMatrix * viewMatrix * modelMatrix * position;
		EmitVertex();
        
		vertex_out.color = vec3(1, 0, 0);
        gl_Position = projectionMatrix * viewMatrix * modelMatrix * target;
		EmitVertex();

		EndPrimitive();
	}
}
";

        private const string normalFragment = @"#version 150 core

in GS_FS_VERTEX
{
    vec3 color;
} fragment_in;

out vec4 outColor;

void main(void)
{
    outColor = vec4(fragment_in.color, 1);
}
";

    }
}
