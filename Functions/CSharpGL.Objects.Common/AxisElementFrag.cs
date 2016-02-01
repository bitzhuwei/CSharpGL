namespace CSharpGL.Objects.Common
{
    namespace CSharpShaders
    {
        using CSharpShadingLanguage;

        /// <summary>
        /// 一个<see cref="AxisElementRenderer"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
        /// 这就是C#Shader形式的fragment shader。
        /// </summary>
        class AxisElementFrag : FragmentCSShaderCode
        {
            [In]
            vec4 pass_Color;

            [Out]
            vec4 out_Color;

            public override void main()
            {
                out_Color = pass_Color;
            }
        }
    }
}
