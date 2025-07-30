#version 410 core

layout (location = 0) out vec4 color;

flat in int shape;

void main(void)
{
    color = vec4(gl_PointCoord, 0, 1);

    vec2 p = gl_PointCoord * 2.0 - vec2(1.0);
    if (shape == 0)
    {
        if (dot(p, p) > 1.0) discard;
    }
    else if (shape == 1)
    {
        if (dot(p, p) > sin(atan(p.y, p.x) * 5.0)) discard;
    }
    else if (shape == 2)
    {
        if (abs(0.8 - dot(p, p)) > 0.2) discard;
    }
    else if (shape == 3)
    {
        if (abs(p.x) < abs(p.y)) discard;
    }
}