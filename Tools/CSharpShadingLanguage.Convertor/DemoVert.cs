using System;

namespace CSharpShadingLanguage.ConsoleTest
{
    class DemoVert : VertexShaderCode
    {
        public void DemoOuput()
        {
            Console.WriteLine("Hello! This is from DemoVert!");
        }

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
            gl_Position = vec4(in_Position, 1.0);//projectionMatrix*viewMatrix*modelMatrix*new vec4()
            pass_UV = in_UV;
        }
    }
}
