#version 330 
 
// 'position' and 'normal' are regular vertex attributes 
layout (location = 0) in vec4 position; 
layout (location = 1) in vec3 normal; 
 
// Color is a per-instance attribute 
layout (location = 2) in vec4 color; 
 
// model_matrix will be used as a per-instance transformation 
// matrix. Note that a mat4 consumes 4 consecutive locations, so 
// this will actually sit in locations, 3, 4, 5, and 6. 
layout (location = 3) in mat4 model_matrix; 
 
// The view matrix and the projection matrix are constant across a draw 
uniform mat4 view_matrix; 
uniform mat4 projection_matrix; 
 
// The output of the vertex shader (matched to the fragment shader) 
out VERTEX 
{ 
    vec3    normal; 
    vec4    color; 
} vertex; 
 
// Ok, go! 
void main(void) 
{ 
    // Construct a model-view matrix from the uniform view matrix 
    // and the per-instance model matrix. 
    mat4 model_view_matrix = view_matrix * model_matrix; 
 
    // Transform position by the model-view matrix, then by the 
    // projection matrix. 
    gl_Position = projection_matrix * (model_view_matrix * position); 
    // Transform the normal by the upper-left-3x3-submatrix of the 
    // model-view matrix 
    vertex.normal = mat3(model_view_matrix) * normal; 
    // Pass the per-instance color through to the fragment shader. 
    vertex.color = color; 
}