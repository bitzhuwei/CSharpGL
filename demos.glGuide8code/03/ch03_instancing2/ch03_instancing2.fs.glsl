#version 330 
 
layout (location = 0) out vec4 color; 
 
in VERTEX 
{ 
    vec3    normal; 
    vec4    color; 
} vertex; 
 
void main(void) 
{ 
    color = vertex.color * (0.1 + abs(vertex.normal.z)) + vec4(0.8, 0.9, 0.7, 1.0) * pow(abs(vertex.normal.z), 40.0); 
}