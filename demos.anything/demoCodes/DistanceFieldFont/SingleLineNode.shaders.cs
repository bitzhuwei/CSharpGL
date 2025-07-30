using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceFieldFont {
    partial class SingleLineNode {
        private const string vertexCode =
            @"#version 330 core

uniform mat4 mvpMat;
uniform ivec2 screenSize;
uniform vec2 lineSize;
uniform int fontSize; // font size in pixel.

in vec2 inPosition;// character's quad's position(in pixels) relative to left bottom(0, 0).
in vec2 inTexCoord;// character's quad's texture coordinate.

out vec2 passTexCoord;

const float value = 0.1;

void main(void) {
	vec4 position = mvpMat * vec4(0, 0, 0, 1);
    position = position / position.w;
	float x = (inPosition.x - lineSize.x / 2.0);
	float y = (-inPosition.y + lineSize.y / 2.0);
    float scale = fontSize / lineSize.y;
    x *= scale; y *= scale;
	float deltaX = x / (screenSize.x / 2.0);
	float deltaY = y / (screenSize.y / 2.0);
    position.x += deltaX; 
	position.y += deltaY;
	gl_Position = position;

    passTexCoord = inTexCoord;
}
";
        private const string fragmentCode =
            @"#version 330 core

uniform sampler2D glyphTexture;
uniform vec4 textColor;
uniform vec4 backgroundColor;

in vec2 passTexCoord;

out vec4 outColor;

void main(void) {
	float val = texture(glyphTexture, passTexCoord).x;
	outColor = mix(textColor, backgroundColor, 1 - val);

    //float a = texture(glyphTexture, passTexCoord).a;
    //outColor = vec4(textColor, a);
}
";

    }
}
