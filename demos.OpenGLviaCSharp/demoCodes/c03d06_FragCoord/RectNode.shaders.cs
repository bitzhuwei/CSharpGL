﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace c03d06_FragCoord {
    partial class RectNode {
        private const string vertexCode = @"#version 150 core

in vec2 inPosition;

void main(void) {
    gl_Position = vec4(inPosition, 0.0, 1.0);
}

";
        private const string fragmentCode = @"#version 150

in vec3 passColor;

uniform float width;
uniform float height;

out vec4 outColor;

void main(void) {
    vec4 coord = gl_FragCoord;
	outColor = vec4(coord.x / width, coord.y / height, 0, 1);
}
";
    }
}
