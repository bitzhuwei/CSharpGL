using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace ImageProcessing.GrayFilter
{
    partial class GrayFilterNode
    {
        private const string renderVert = @"#version 150

uniform mat4 mvpMat;

in vec3 inPosition;
in vec2 inTexCoord;

out vec2 passTexCoord;

void main(void)
{
	passTexCoord = inTexCoord;

	gl_Position = mvpMat * vec4(inPosition, 1.0f);
}
";
        private const string renderFrag = @"#version 150

uniform sampler2D tex; 

in vec2 passTexCoord;

out vec4 outColor;

void main(void)
{
	vec4 color = texture(tex, passTexCoord);

	if (passTexCoord.s >= 0.5)
	{
		float grey = color.r * 0.299 + color.g * 0.587 + color.b * 0.114;
		
		outColor = vec4(grey, grey, grey, 1.0f);
	}
	else
	{
		outColor = color;
	}
}
";
    }
}
