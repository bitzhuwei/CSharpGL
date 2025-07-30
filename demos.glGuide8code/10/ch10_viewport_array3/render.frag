#version 430 core
out vec4 FragColor;

in flat int passViewportID;
in vec3 passColor;

void main() {
    if(passViewportID == 0)
        FragColor = vec4(passColor, 1.0);
    else
        FragColor = vec4(passColor * 0.7, 1.0);
}