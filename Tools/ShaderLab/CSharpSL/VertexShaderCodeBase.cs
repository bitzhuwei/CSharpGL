using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderLab.CSharpSL
{
    /*
     
     #version 150 core

in vec3 in_Position;
in vec2 in_UV;  
out vec2 pass_UV;

uniform mat4 projectionMatrix;
uniform mat4 viewMatrix;
uniform mat4 modelMatrix;

void main(void) 
{
	gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, 1.0);

	pass_UV = in_UV;
}

     */
    abstract class VertexShader
    {
    }

    class IlluminationVert : VertexShader
    {
        [In]
        vec3 in_Position;
        [In]
        vec2 in_UV;
        [Out]
        vec2 pass_UV;

        [Uniform]
        mat4 projectionMatrix;
        [Uniform]
        mat4 viewMatrix;
        [Uniform]
        mat4 modelMatrix;

        void main()
        {
            //gl_Position=projectionMatrix*viewMatrix*modelMatrix*new vec4()
        }
    }

   
    class VertexShaderCodeBase
    {
        protected vec4 gl_Position;
    }
}
