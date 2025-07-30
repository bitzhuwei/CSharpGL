#version 430 core

//uniform vec4 color = vec4(1, 0, 0, 1); // default: red color.
in vec3 passColor;

out vec4 outColor;

void main() {
    outColor = vec4(passColor, 1.0);// color; // fill the fragment with specified color.
}