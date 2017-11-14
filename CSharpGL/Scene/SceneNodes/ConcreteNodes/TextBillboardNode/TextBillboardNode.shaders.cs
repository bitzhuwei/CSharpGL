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
        private const string glyphTexture = "tex";
        private const string textColor = "textColor";

        private const string vertexCode =
            @"#version 330 core

uniform mat4 " + projectionMatrix + @";
uniform mat4 " + viewMatrix + @";
uniform mat4 " + modelMatrix + @";
uniform float " + width + @";
uniform float " + height + @";
uniform vec2 " + screenSize + @";

in vec2 inPosition;// character's quad's position(in pixels) relative to left bottom(0, 0).
in vec3 inSTR;// character's quad's texture coordinate.

out vec3 passSTR;

void main(void) {
	vec4 position = projectionMatrix * viewMatrix * modelMatrix * vec4(0, 0, 0, 1);
    position = position / position.w;
    position.xy += (inPosition - vec2(width / 2, height / 2)) / screenSize;
	gl_Position = position;

	passSTR = inSTR;
}
";
        private const string fragmentCode =
            @"#version 330 core

in vec3 passSTR;

uniform sampler2DArray " + glyphTexture + @";
uniform vec3 " + textColor + @";

out vec4 out_Color;

void main(void) {
    float a = texture(glyphTexture, vec3(passSTR.xy, floor(passSTR.z))).a;
    out_Color = vec4(textColor, a);
}
";

        #endregion shaders
    }
}
