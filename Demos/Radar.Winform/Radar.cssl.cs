// 此文件由CSharpGL.CSSLGenerator.exe生成。
// 用法：使用CSSL2GLSL.exe编译此文件，即可获得对应的vertex shader, geometry shader, fragment shader。
// 此文件中的类型不应被直接调用，发布release时可以去掉。
// 不可将此文件中的代码复制到其他文件内（如果包含了其他的using ...;，那么CSSL2GLSL.exe就无法正常编译这些代码了。）
namespace CSharpShadingLanguage.Radar
{
    using CSharpShadingLanguage;


    /// <summary>
    /// 一个<see cref="RadarVert"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// (GLSLVersion)0 is GLSLVersion.v150
    /// </summary>
    [CSharpShadingLanguage.Dump2FileAttribute(true)]
    [CSharpShadingLanguage.GLSLVersionAttribute(((CSharpShadingLanguage.GLSLVersion)(0u)))]
    public partial class RadarVert : CSharpShadingLanguage.VertexCSShaderCode
    {

        [CSharpShadingLanguage.InAttribute()]
        private vec3 position;

        [CSharpShadingLanguage.InAttribute()]
        private vec3 color;

        [CSharpShadingLanguage.UniformAttribute()]
        private mat4 mvp;

        [CSharpShadingLanguage.OutAttribute()]
        private vec3 pass_color;

        [CSharpShadingLanguage.OutAttribute()]
        private vec2 pass_position;


        [CSharpShadingLanguage.UniformAttribute()]
        private float pointSize;

    }

    /// <summary>
    /// 一个<see cref="RadarFrag"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// (GLSLVersion)0 is GLSLVersion.v150
    /// </summary>
    [CSharpShadingLanguage.Dump2FileAttribute(true)]
    [CSharpShadingLanguage.GLSLVersionAttribute(((CSharpShadingLanguage.GLSLVersion)(0u)))]
    public partial class RadarFrag : CSharpShadingLanguage.FragmentCSShaderCode
    {
        [CSharpShadingLanguage.InAttribute()]
        private vec3 pass_color;

        [CSharpShadingLanguage.InAttribute()]
        private vec2 pass_position;

        [CSharpShadingLanguage.UniformAttribute()]
        private float pointSize;

        [CSharpShadingLanguage.OutAttribute()]
        private vec4 output_color;

        [CSharpShadingLanguage.Uniform]
        private sampler2D cloudTexture;

        [CSharpShadingLanguage.Uniform]
        private float canvasWidth;

        [CSharpShadingLanguage.Uniform]
        private float canvasHeight;

        [CSharpShadingLanguage.Uniform]
        private float brightness = 1.0f;
    }
}
