using System;
using System.Drawing;
using System.IO;

namespace CSharpGL
{
    public partial class TextBillboardNode
    {
        #region shaders

        private const string projectionMatrix = "projectionMatrix";
        private const string viewMatrix = "viewMatrix";
        private const string modelMatrix = "modelMatrix";
        private const string width = "width";
        private const string height = "height";
        private const string screenSize = "screenSize";
        private const string inPosition = "inPosition";
        private const string inSTR = "inSTR";
        private const string glyphTexture = "glyphTexture";
        private const string textColor = "textColor";

        private const string vertexCode =
            @"#version 330 core

uniform mat4 " + projectionMatrix + @";
uniform mat4 " + viewMatrix + @";
uniform mat4 " + modelMatrix + @";
uniform vec2 " + screenSize + @";

uniform float " + width + @";
uniform float " + height + @";

in vec2 " + inPosition + @";// character's quad's position(in pixels) relative to left bottom(0, 0).
in vec3 " + inSTR + @";// character's quad's texture coordinate.

out vec3 passSTR;

const float value = 0.1;

void main(void) {
	vec4 position = projectionMatrix * viewMatrix * modelMatrix * vec4(0, 0, 0, 1);
    position = position / position.w;
    position.xy += (inPosition * height - vec2(width, height)) / screenSize;
	gl_Position = position;

    passSTR = inSTR;
}
";
        private const string fragmentCode =
            @"#version 330 core

uniform sampler2DArray " + glyphTexture + @";
uniform vec3 " + textColor + @";

in vec3 passSTR;

out vec4 out_Color;

void main(void) {
    float a = texture(glyphTexture, vec3(passSTR.xy, floor(passSTR.z))).a;
    out_Color = vec4(textColor, a);
}
";

        #endregion shaders
    }
}
