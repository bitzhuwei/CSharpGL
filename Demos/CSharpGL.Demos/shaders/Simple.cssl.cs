// 此文件由CSharpGL.CSSLGenerator.exe生成。
// 用法：使用CSSL2GLSL.exe编译此文件，即可获得对应的vertex shader, geometry shader, fragment shader。
// 此文件中的类型不应被直接调用，发布release时可以去掉。
// 不可将此文件中的代码复制到其他文件内（如果包含了其他的using ...;，那么CSSL2GLSL.exe就无法正常编译这些代码了。）
namespace CSharpShadingLanguage.Simple
{
    using CSharpGL.CSSL;
    
    
    /// <summary>
    /// 一个<see cref="SimpleVert"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// (GLSLVersion)0 is GLSLVersion.v150
    /// </summary>
    [CSharpGL.CSSL.Dump2FileAttribute(true)]
    [CSharpGL.CSSL.GLSLVersionAttribute(((CSharpGL.CSSL.GLSLVersion)(0u)))]
    public partial class SimpleVert : CSharpGL.CSSL.VertexCSShaderCode
    {
        
        [CSharpGL.CSSL.InAttribute()]
        private vec3 in_Position = vec3(1F, 1F, 1F);
        
        [CSharpGL.CSSL.InAttribute()]
        private vec3 in_Color = vec3(1F, 1F, 1F);
        
        [CSharpGL.CSSL.OutAttribute()]
        private vec4 pass_Color = vec4(1F, 1F, 1F, 1F);
        
        [CSharpGL.CSSL.UniformAttribute()]
        private mat4 projectionMatrix = mat4(1F);
        
        [CSharpGL.CSSL.UniformAttribute()]
        private mat4 viewMatrix = mat4(1F);
        
        [CSharpGL.CSSL.UniformAttribute()]
        private mat4 modelMatrix = mat4(1F);
    }
    
    /// <summary>
    /// 一个<see cref="SimpleFrag"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// (GLSLVersion)0 is GLSLVersion.v150
    /// </summary>
    [CSharpGL.CSSL.Dump2FileAttribute(true)]
    [CSharpGL.CSSL.GLSLVersionAttribute(((CSharpGL.CSSL.GLSLVersion)(0u)))]
    public partial class SimpleFrag : CSharpGL.CSSL.FragmentCSShaderCode
    {
        
        [CSharpGL.CSSL.InAttribute()]
        private vec4 pass_Color = vec4(1F, 1F, 1F, 1F);
        
        [CSharpGL.CSSL.OutAttribute()]
        private vec4 out_Color = vec4(1F, 1F, 1F, 1F);
    }
}
