using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpShaderLanguage
{
    /*
     
#version 150 core

in vec2 pass_UV;
out vec4 out_Color;
uniform sampler2D texture1;
uniform sampler2D texture2;
uniform float percent;

void main(void) 
{
	vec4 color = texture(texture1, pass_UV) * percent + texture(texture2, pass_UV) * (1.0 - percent);
	out_Color = color;
	//out_Color = texture(texture2, pass_UV);
	//out_Color = texture(texture1, pass_UV);
}

     */

    class IlluminationFrag : FragmenthaderCode
    {
        [In]
        vec2 pass_UV;
        [Out]
        vec4 out_Color;

        [Uniform]
        sampler2D texture1;
        [Uniform]
        sampler2D texture2;
        [Uniform]
        float percent;
        void main()
        {
            vec4 color = texture(texture1, pass_UV) * percent + texture(texture2, pass_UV) * (1.0f - percent);
            out_Color = color;
        }

        private vec4 texture(sampler2D texture1, vec2 pass_UV)
        {
            throw new NotImplementedException();
        }

    }

    /// <summary>
    /// fragment shader共有的内容。
    /// </summary>
    class FragmenthaderCode : ShaderCode
    {


    }
}
