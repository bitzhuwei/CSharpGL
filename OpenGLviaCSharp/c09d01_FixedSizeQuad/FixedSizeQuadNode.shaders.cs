using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace c09d01_FixedSizeQuad
{
    partial class FixedSizeQuadNode
    {

        private const string vertexCode = @"#version 150 core

in vec2 inPosition;
in vec2 inUV;

uniform float screenWidth;
uniform float screenHeight;
uniform mat4 mvpMatrix;

out vec2 passUV;

void main(void) {
    vec4 clipSpacePos = mvpMatrix * vec4(0, 0, 0, 1);
    clipSpacePos = clipSpacePos / clipSpacePos.w; // divide by w.
    clipSpacePos.x += inPosition.x / screenWidth; // move horizontally.
    clipSpacePos.y += inPosition.y / screenHeight; // move vertically.
    gl_Position = clipSpacePos;

    passUV = inUV;
}

";
        private const string fragmentCode = @"#version 150

in vec2 passUV;

uniform sampler2D tex;

out vec4 outColor;

void main(void) {
	outColor = texture(tex, passUV);
}
";

    }

}
