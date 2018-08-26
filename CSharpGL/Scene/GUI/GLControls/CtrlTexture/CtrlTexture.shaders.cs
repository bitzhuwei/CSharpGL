using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// A rectangle control that displays an image.
    /// </summary>
    public partial class CtrlTexture
    {
        private const string inPosition = "inPosition";
        private const string inUV = "inUV";
        private const string tex = "tex";

        private const string vert =
            @"#version 330 core

in vec3 " + inPosition + @";
in vec2 " + inUV + @";

out vec2 passUV;

void main(void) {
	gl_Position = vec4(inPosition, 1.0);
	passUV = inUV;
}
";
        private const string frag =
            @"#version 330 core

in vec2 passUV;

uniform sampler2D " + tex + @";

out vec4 outColor;

void main(void) {
	vec4 color = texture(tex, passUV);
    outColor = color;
}
";
    }
}
