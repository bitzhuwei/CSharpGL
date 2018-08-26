using System;
using System.Drawing;
using System.IO;

namespace CSharpGL
{
    public partial class TextBillboardNode
    {
        #region shaders

        private const string projectionMat = "projectionMat";
        private const string viewMat = "viewMat";
        private const string modelMat = "modelMat";
        private const string width = "width";
        private const string height = "height";
        private const string screenSize = "screenSize";
        private const string inPosition = "inPosition";
        private const string inSTR = "inSTR";
        private const string glyphTexture = "glyphTexture";
        private const string textColor = "textColor";

        private const string vertexCode =
            @"#version 330 core

uniform mat4 " + projectionMat + @";
uniform mat4 " + viewMat + @";
uniform mat4 " + modelMat + @";
uniform ivec2 " + screenSize + @";

uniform int " + width + @";
uniform int " + height + @";

in vec2 " + inPosition + @";// character's quad's position(in pixels) relative to left bottom(0, 0).
in vec3 " + inSTR + @";// character's quad's texture coordinate.

out vec3 passSTR;

const float value = 0.1;

void main(void) {
	vec4 position = projectionMat * viewMat * modelMat * vec4(0, 0, 0, 1);
    position = position / position.w;
    float deltaX = (inPosition.x * height - width) / screenSize.x;
    float deltaY = (inPosition.y * height - height) / screenSize.y;
    position.x += deltaX; position.y += deltaY;
	gl_Position = position;

    passSTR = inSTR;
}
";
        private const string fragmentCode =
            @"#version 330 core

uniform sampler2DArray " + glyphTexture + @";
uniform vec3 " + textColor + @";

in vec3 passSTR;

out vec4 outColor;

void main(void) {
    float a = texture(glyphTexture, vec3(passSTR.xy, floor(passSTR.z))).a;
    outColor = vec4(textColor, a);
}
";

        #endregion shaders
    }
}
