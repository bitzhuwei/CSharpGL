#version 430 core
layout (triangles) in;
layout (triangle_strip, max_vertices = 6) out;

in VS_OUT {
    vec3 color;
} gs_in[];

out GS_OUT {
    vec3 color;
    flat int viewportID;
} gs_out;

void main() {    
    for(int i = 0; i < 3; i++) {
        gl_ViewportIndex = 0;
        gs_out.viewportID = 0;
        gl_Position = gl_in[i].gl_Position;
        gs_out.color = gs_in[i].color;
        EmitVertex();
    }
    EndPrimitive();
    
    for(int i = 0; i < 3; i++) {
        gl_ViewportIndex = 1;
        gs_out.viewportID = 1;
        gl_Position = gl_in[i].gl_Position * 0.5;
        gs_out.color = gs_in[i].color;
        EmitVertex();
    }
    EndPrimitive();
}