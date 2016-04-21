#version 150 core

in vec3 position;
in vec3 color;
uniform mat4 mvp;
out vec3 pass_color;
out vec2 pass_position;
uniform float pointSize;

void main(void)
{
    pass_color = color;
    vec4 pos = mvp * vec4(position, 1.0f);
    gl_Position = pos;
    //gl_PointSize = 40;// (1.0f - pos.z / pos.w) * 20;// 20: size factor
    pass_position = vec2(pos.x / pos.w, pos.y / pos.w);
    gl_PointSize = pointSize; 
}

