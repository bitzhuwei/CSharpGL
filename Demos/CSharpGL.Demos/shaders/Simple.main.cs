// 此文件由CSharpGL.CSSLGenerator.exe生成。
// 用法：使用CSSL2GLSL.exe编译此文件，即可获得对应的vertex shader, geometry shader, fragment shader。
// 此文件中的类型不应被直接调用，发布release时可以去掉。
// 不可将此文件中的代码复制到其他文件内（如果包含了其他的using ...;，那么CSSL2GLSL.exe就无法正常编译这些代码了。）
namespace CSharpShadingLanguage.Simple
{
    using CSharpGL.CSSL;


    /// <summary>
    /// 一个<see cref="SimpleVert"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// </summary>
    public partial class SimpleVert : CSharpGL.CSSL.VertexCSShaderCode
    {

        public override void main()
        {
            gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, 1.0);

            pass_Color = vec4(in_Color, 1.0);
        }
    }

    /// <summary>
    /// 一个<see cref="SimpleFrag"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// </summary>
    public partial class SimpleFrag : CSharpGL.CSSL.FragmentCSShaderCode
    {

        public override void main()
        {
            out_Color = pass_Color;
        }
    }
}
