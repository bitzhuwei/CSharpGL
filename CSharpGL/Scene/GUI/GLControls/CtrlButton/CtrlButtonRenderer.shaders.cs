using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// A rectangle control that displays an image.
    /// </summary>
    public partial class CtrlButtonRenderer
    {
        private const string inPosition = "inPosition";
        private const string inColor = "inColor";

        private const string vert =
            @"#version 330 core

in vec3 " + inPosition + @";
in vec3 " + inColor + @";

out vec3 passColor;

void main(void) {
	gl_Position = vec4(inPosition, 1.0);
    passColor = inColor;
}
";
        private const string frag =
            @"#version 330 core

in vec3 passColor;

out vec4 out_Color;

void main(void) {
    out_Color = vec4(passColor, 1.0);
}
";
    }
}
