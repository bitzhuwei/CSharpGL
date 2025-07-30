using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace c12d00_StaticSlices {
    partial class StaticSlicesNode {
        private const string vertexCode = @"#version 150

in vec3 inPosition;
in vec3 inTexCoord;

out vec3 passTexCoord;
out float hidden;

uniform mat4 mvpMat;
uniform int hiddenLength = 1;

void main() {
    gl_Position = mvpMat * vec4(inPosition, 1.0);
    passTexCoord = inTexCoord;

    int length = hiddenLength > 0 ? hiddenLength : 1;
    if ((gl_VertexID / 4) % length == (length / 2)) { hidden = 0; }
    else { hidden = 1; }
}
";

        private const string fragmentCode = @"#version 150

in vec3 passTexCoord;
in float hidden;

uniform sampler1D tex1D;
uniform sampler3D tex3D;
uniform int hiddenLength = 1;

uniform bool showSlice = false;

out vec4 outColor;

void main() {
    if (hidden > 0) discard;

	float p = texture(tex3D, passTexCoord).r;
    vec4 color = texture(tex1D, p);
	if (showSlice) {
        if (color.a > 0) { outColor = vec4(color.rgb, hiddenLength / 256.0) + color / 10000; }
        else { outColor = vec4(1, 1, 1, hiddenLength / 256.0) + color / 10000; }
	}
	else {
        outColor = vec4(color.rgb, color.a / 50 * hiddenLength);
	}
}
";
    }
}
