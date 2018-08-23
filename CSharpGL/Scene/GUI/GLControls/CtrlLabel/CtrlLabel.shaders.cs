using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// A rectangle control that displays an image.
    /// </summary>
    public partial class CtrlLabel
    {
        private const string inPosition = "inPosition";
        private const string inSTR = "inSTR";
        private const string glyphTexture = "glyphTexture";
        private const string textColor = "textColor";

        private const string vert =
            @"#version 330 core

in vec2 " + inPosition + @";
in vec3 " + inSTR + @";

out vec3 passSTR;

void main(void) {
	gl_Position = vec4(inPosition, 0.0, 1.0);
    passSTR = inSTR;
}
";
        private const string frag =
            @"#version 330 core

in vec3 passSTR;

uniform sampler2DArray " + glyphTexture + @";
uniform vec3 " + textColor + @";

out vec4 outColor;

void main(void) {
    //outColor = vec4(passSTR, 1.0f);
    //outColor = texture(glyphTexture, vec3(passSTR.xy, floor(passSTR.z)));
    float a = texture(glyphTexture, vec3(passSTR.xy, floor(passSTR.z))).a;
    outColor = vec4(textColor, a);
}
";
    }
}
