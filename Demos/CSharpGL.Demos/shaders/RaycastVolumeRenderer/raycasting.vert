#version 400


layout (location = 0) in vec3 position;
// have to use this variable!!!, or it will be very hard to debug for AMD video card
layout (location = 1) in vec3 boundingBox;  


out vec3 passEntryPoint;

uniform mat4 MVP;

void main()
{
    passEntryPoint = boundingBox;
    gl_Position = MVP * vec4(position, 1.0);
}
