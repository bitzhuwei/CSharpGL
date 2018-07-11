using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace c06d01_2DTextureArray
{
    partial class RectangleNode
    {
        const string vert = @"#version 150

in vec3 inPosition;
in vec2 inUV;

uniform mat4 mvpMat;

out vec2 passUV;

void main(){
    gl_Position = mvpMat * vec4(inPosition, 1.0);
    passUV = inUV;
}
";

        const string frag = @"#version 150

in vec2 passUV;

uniform sampler2D tex;

out vec4 outColor;

void main(){
    vec4 color = texture(tex, passUV);
    if (color.a == 0) { color.a = 0.5; }
    outColor = color;
}
";

    }
}
