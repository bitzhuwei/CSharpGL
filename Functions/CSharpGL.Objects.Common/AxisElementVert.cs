namespace CSharpGL.Objects.Common
{
    namespace Shader
    {
        using CSharpShaderLanguage;

        /// <summary>
        /// 一个<see cref="AxisElementRenderer"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
        /// 这就是C#Shader形式的vertex shader。
        /// </summary>
        class AxisElementVert : VertexShaderCode
        {
            [In]
            vec3 in_Position;
            [In]
            vec3 in_Color;

            [Out]
            vec4 pass_Color;

            [Uniform]
            mat4 MVP;

            public override void main()
            {
                gl_Position = MVP * vec4(in_Position, 1.0);

                pass_Color = vec4(in_Color, 1.0);
            }
        }

    }
}
