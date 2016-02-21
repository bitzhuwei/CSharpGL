// 用法：使用CSSL2GLSL.exe编译此文件，即可获得对应的vertex shader, geometry shader, fragment shader。
// 此文件中的类型不应被直接调用，发布release时可以去掉。
#if DEBUG

namespace CSharpShadingLanguage.StringShader
{
    // 不可将此文件中的代码复制到其他文件内（如果包含了其他的using ...;，那么CSSL2GLSL.exe就无法正常编译这些代码了。）
    using CSharpShadingLanguage;

    /// <summary>
    /// 一个<see cref="StringShaderVert"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// </summary>
    [Dump2File(true)]
    [GLSLVersion(GLSLVersion.v150)]
    sealed class StringShaderVert : VertexCSShaderCode
    {
        [In]
        vec3 position;

        [In]
        vec3 color;

        [Out]
        vec3 passColor;

        [In]
        vec2 texCoord;

        [Out]
        vec2 passTexCoord;

        [Uniform]
        mat4 mvp;

        public override void main()
        {
            gl_Position = mvp * vec4(position, 1.0f);
            passColor = color;
            passTexCoord = texCoord;
        }
    }

    /// <summary>
    /// 一个<see cref="StringShaderFrag"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// </summary>
    [Dump2File(true)]
    [GLSLVersion(GLSLVersion.v150)]
    sealed class StringShaderFrag : FragmentCSShaderCode
    {
        [In]
        vec3 passColor;

        [In]
        vec2 passTexCoord;

        [Uniform]
        sampler2D glyphTexture;

        [Out]
        vec4 outputColor;

        public override void main()
        {
            vec4 glyphColor = texture(glyphTexture, passTexCoord);
            outputColor = vec4(passColor, 1.0f) * glyphColor;
        }
    }

}

#endif

