using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c02d03_MultipleRenderMethods {
    partial class CubeNode {
        private const string singleColorVert = @"
#version 150

in vec3 inPosition;

uniform mat4 mvpMatrix;

void main() {
    gl_Position = mvpMatrix * vec4(inPosition, 1.0); 
}
";

        private const string singleColorFrag = @"
#version 150

uniform vec4 color = vec4(1, 0, 0, 1); // default: red color.

out vec4 outColor;

void main() {
    outColor = color;
}
";

        private const string multiTextureVert = @"
#version 150

in vec3 inPosition;
in vec2 inTexCoord;

uniform mat4 mvpMatrix;

out vec2 passTexCoord;

void main() {
    gl_Position = mvpMatrix * vec4(inPosition, 1.0); 

    passTexCoord = inTexCoord;
}
";

        private const string multiTextureFrag = @"
#version 150

uniform sampler2D texture0;
uniform sampler2D texture1;

in vec2 passTexCoord;
in vec3 passPos;

out vec4 outColor;

void main() {
    //outColor = color;
    vec4 c0 = texture(texture0, passTexCoord);
    vec4 c1 = texture(texture1, passTexCoord);

    outColor = vec4((c0 + c1).xyz / 2.0, 1.0);
}
";
    }
}
