#version 430 core

layout(std430) buffer SSBO { vec4 positions[]; };
layout(std430) buffer SSBO2 { vec4 colors[]; };

uniform mat4 mvpMatrix;
uniform int posStartIndex;
uniform int colorStartIndex;

out vec3 passColor;

void main() {
    int primitiveStartIndex = 0; // should be a uniform var
    vec3 pos = positions[posStartIndex + gl_VertexID].xyz;
    vec3 color = colors[colorStartIndex + gl_VertexID].rgb;
    gl_Position = mvpMatrix * vec4(pos, 1.0); 
    passColor = color;
}