// for raycasting
#version 400

layout(location = 0) in vec3 position;
layout(location = 1) in vec3 color;

out vec3 passExitPoint;

uniform mat4 MVP;


void main()
{
    passExitPoint = color;
    gl_Position = MVP * vec4(position, 1.0);
}
