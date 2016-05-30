// for raycasting
#version 400

in vec3 passColor;
layout (location = 0) out vec4 FragColor;


void main()
{
    FragColor = vec4(passColor, 1.0);
}
