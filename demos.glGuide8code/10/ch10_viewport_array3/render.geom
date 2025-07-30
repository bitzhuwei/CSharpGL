#version 430 core
layout (triangles) in;
layout (triangle_strip, max_vertices = 6) out;

in VS_OUT {
    vec3 color;
} gs_in[];

out flat int passViewportID;
out vec3 passColor;

void main() {    
    for(int i = 0; i < 3; i++) {
        gl_ViewportIndex = 0;
        passViewportID = 0;
        gl_Position = gl_in[i].gl_Position;
        passColor = gs_in[i].color;
        EmitVertex();
    }
    EndPrimitive();
    
    for(int i = 0; i < 3; i++) {
        gl_ViewportIndex = 1;
        passViewportID = 1;
        gl_Position = gl_in[i].gl_Position * 0.5;
        passColor = gs_in[i].color;
        EmitVertex();
    }
    EndPrimitive();
}