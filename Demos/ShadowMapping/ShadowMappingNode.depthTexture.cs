using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace ShadowMapping
{
    /// <summary>
    /// render a teapot with shadow.
    /// </summary>
    public partial class ShadowMappingNode : PickableNode, ISupportShadowMapping
    {
        private const string shadowVertexCode =
    @"#version 330

uniform mat4 " + mvpMatrix + @";

in vec4 " + inPosition + @";

void main(void)
{
	gl_Position = mvpMatrix * position;
}
";
        // this fragment shader is not needed.
        //        private const string shadowFragmentCode =
        //            @"#version 330 core
        //
        //out float fragmentdepth;
        //
        //void main(void) {
        //    fragmentdepth = gl_FragCoord.z;
        //
        //}
        //";

    }
}
