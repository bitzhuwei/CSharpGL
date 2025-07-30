#version 420 core

out VS_OUT
{
    vec3 tc;
} vs_out;

void main(void)
{
    int vid = gl_VertexID;
    int iid = gl_InstanceID;
    float inst_x = float(iid % 4) / 2.0;
    float inst_y = float(iid >> 2) / 2.0;

    const vec4 vertices[] = vec4[](vec4(-0.5, -0.5, 0.0, 1.0),
                                   vec4( 0.5, -0.5, 0.0, 1.0),
                                   vec4( 0.5,  0.5, 0.0, 1.0),
                                   vec4(-0.5,  0.5, 0.0, 1.0));

    vec4 offs = vec4(inst_x - 0.75, inst_y - 0.75, 0.0, 0.0);

    gl_Position = vertices[vid] *
                  vec4(0.25, 0.25, 1.0, 1.0) + offs;
    vs_out.tc = vec3(vertices[vid].xy + vec2(0.5), float(iid));
}
