// for raycasting
#version 400

in vec3 passExitPoint;
layout (location = 0) out vec4 FragColor;


void main()
{
    FragColor = vec4(passExitPoint, 1.0);
}
