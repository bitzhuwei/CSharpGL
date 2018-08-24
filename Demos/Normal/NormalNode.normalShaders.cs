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

in vec3 inPosition;
in vec3 inNormal;
out vec3 passNormal;

void main(void)
{
    gl_Position = vec4(inPosition, 1.0f);
    passNormal = inNormal;
}
";
        private const string normalGeometry = @"#version 150 core

layout (triangles) in;
layout (line_strip, max_vertices = 2) out;

uniform float normalLength = 0.2;
uniform vec3 vertexColor = vec3(1, 1, 1);
uniform vec3 pointerColor = vec3(0.5, 0.5, 0.5);
uniform mat4 projectionMat;
uniform mat4 viewMat;
uniform mat4 modelMatrix;

in vec3 passNormal[];

out vec3 passColor;

void main(void)
{
	for (int i = 0; i < gl_in.length(); i++)
	{
		vec4 position = gl_in[i].gl_Position;
		
		passColor = vertexColor;
        gl_Position = projectionMat * viewMat * modelMatrix * position;
		EmitVertex();
        
		passColor = pointerColor;
		vec4 target = vec4(position.xyz + normalize(passNormal[i]) * normalLength, 1.0f);
        gl_Position = projectionMat * viewMat * modelMatrix * target;
		EmitVertex();

		EndPrimitive();
	}
}
";

        private const string normalFragment = @"#version 150 core

in vec3 passColor;

out vec4 outColor;

void main(void)
{
    outColor = vec4(passColor, 1);
}
";
    }
}
