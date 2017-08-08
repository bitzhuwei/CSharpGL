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

uniform mat4 mvpMatrix;

in vec3 a_vertex;
in vec2 a_texCoord;

out vec2 v_texCoord;

void main(void)
{
	v_texCoord = a_texCoord;

	gl_Position = mvpMatrix * vec4(a_vertex, 1.0f);
}
";
        private const string renderFrag = @"#version 150

uniform sampler2D u_texture; 

in vec2 v_texCoord;

out vec4 fragColor;

void main(void)
{
	vec4 color = texture(u_texture, v_texCoord);

	if (v_texCoord.s >= 0.5)
	{
		float grey = color.r*0.299 + color.g*0.587 + color.b*0.114;
		
		fragColor = vec4(grey, grey, grey, 1.0f);
	}
	else
	{
		fragColor = color;
	}
}
";
    }
}
