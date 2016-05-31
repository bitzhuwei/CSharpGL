#version 400


layout (location = 0) in vec3 position;
// have to use this variable!!!, or it will be very hard to debug for AMD video card
layout (location = 1) in vec3 color;  


out vec3 EntryPoint;
out vec4 ExitPointCoord;

uniform mat4 MVP;

void main()
{
    EntryPoint = color;
    gl_Position = MVP * vec4(position, 1.0);
    ExitPointCoord = gl_Position;  
}
