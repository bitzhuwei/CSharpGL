namespace CSharpShaders
{
#if DEBUG

	// 注意：请把CSharp Shader代码放到单独的文件，并且不要加任何其他的using ...;
    using CSharpShadingLanguage;

    /// <summary>
    /// 一个<see cref="DemoShaderVert"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// 这就是C#Shader形式的vertex shader。
    /// </summary>
    class DemoShaderVert : VertexCSShaderCode
    {
        [In]
        vec3 in_Position;
        [In]
        vec3 in_Color;

        [Out]
        vec4 pass_Color;

        [Uniform]
        mat4 modelMatrix;
        [Uniform]
        mat4 viewMatrix;
        [Uniform]
        mat4 projectionMatrix;

        public override void main()
        {
            gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, 1.0f);

            pass_Color = vec4(in_Color, 1.0f);
        }
    }

    /// <summary>
    /// 一个<see cref="DemoShaderFrag"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// 这就是C#Shader形式的fragment shader。
    /// </summary>
    class DemoShaderFrag : FragmentCSShaderCode
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

#endif
}
