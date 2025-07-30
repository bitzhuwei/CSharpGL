using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace TessellatedTriangle {
    partial class TrianglePatchNode {
        private const string vertexCode = @"
#version 410 core

out Vertex
{
    vec3 color;
} vertex;

void main() {
    const vec4 vertices[] = vec4[](
        vec4( 0.5, -0.5, 1.0, 1.0),
        vec4(-0.5, -0.5, 1.0, 1.0),
        vec4( 0.5,  0.5, 1.0, 1.0));
    const vec3 colors[] = vec3[](
        vec3(1, 0, 0),
        vec3(0, 1, 0),
        vec3(0, 0, 1));

    gl_Position = vertices[gl_VertexID];
    vertex.color = colors[gl_VertexID];
}
";

        private const string tessellationControlCode = @"
#version 410 core

layout (vertices = 3) out;

in Vertex
{
    vec3 color;
} vertexIn[];

uniform float inner0 = 5.0;
uniform float outer0 = 5.0;
uniform float outer1 = 5.0;
uniform float outer2 = 5.0;

out Vertex
{
    vec3 color;
} vertexOut[];

void main()
{
    if (gl_InvocationID == 0)
    {
        gl_TessLevelInner[0] = inner0;
        gl_TessLevelOuter[0] = outer0;
        gl_TessLevelOuter[1] = outer1;
        gl_TessLevelOuter[2] = outer2;
    }

    gl_out[gl_InvocationID].gl_Position = gl_in[gl_InvocationID].gl_Position;
    vertexOut[gl_InvocationID].color = vertexIn[gl_InvocationID].color;
}
";

        private const string tessellationEvaluationCode = @"
#version 410 core

layout (triangles, equal_spacing, cw) in;  

in Vertex
{
    vec3 color;
} vertexIn[];

out Vertex
{
    vec3 color;
} vertexOut;
                                                                                       
vec2 interpolate2D(vec2 v0, vec2 v1, vec2 v2)
{
    return vec2(gl_TessCoord.x) * v0 + vec2(gl_TessCoord.y) * v1 + vec2(gl_TessCoord.z) * v2;
}

vec3 interpolate3D(vec3 v0, vec3 v1, vec3 v2)
{
    return vec3(gl_TessCoord.x) * v0 + vec3(gl_TessCoord.y) * v1 + vec3(gl_TessCoord.z) * v2;
}

vec4 interpolate4D(vec4 v0, vec4 v1, vec4 v2)
{
    return vec4(gl_TessCoord.x) * v0 + vec4(gl_TessCoord.y) * v1 + vec4(gl_TessCoord.z) * v2;
}

void main()
{
    gl_Position = interpolate4D(gl_in[0].gl_Position, gl_in[1].gl_Position, gl_in[2].gl_Position);
    vertexOut.color = interpolate3D(vertexIn[0].color, vertexIn[1].color, vertexIn[2].color);
}
";

        private const string fragmentCode = @"
#version 410 core

in Vertex
{
    vec3 color;
} vertexIn;

out vec4 outColor;

void main() {
    outColor = vec4(vertexIn.color, 1.0);
}
";
    }
}
