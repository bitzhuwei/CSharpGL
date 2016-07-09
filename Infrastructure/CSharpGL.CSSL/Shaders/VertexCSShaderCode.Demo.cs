using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL.CSSL
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

    /// <summary>
    /// 这是一个用CSSL写的vertex shader的例子。
    /// </summary>
    class DemoVert : VertexCSShaderCode
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

        public override void main()
        {
            gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, 1.0f);

            pass_UV = in_UV;
        }

    }

}
