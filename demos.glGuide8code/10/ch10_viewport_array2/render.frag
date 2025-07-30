#version 430 core
in GS_OUT {
    vec3 color;
    flat int viewportID;
} fs_in;

out vec4 FragColor;

void main() {
    if(fs_in.viewportID == 0)
        FragColor = vec4(fs_in.color, 1.0);
    else
        FragColor = vec4(fs_in.color * 0.7, 1.0);
}