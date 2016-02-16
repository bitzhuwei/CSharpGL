
namespace HelloCSharpGL
{
	// 不可将此文件中的代码复制到其他文件内（如果包含了其他的using ...;，那么CSSL2GLSL.exe就无法正常编译这些代码了。）
    using CSharpShadingLanguage;

#if DEBUG

    /// <summary>
    /// 一个<see cref="PyramidVert"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// 这就是C#Shader形式的vertex shader。
    /// </summary>
    [Dump2File(true)]
	[GLSLVersion(GLSLVersion.v150)]
    sealed class PyramidVert : VertexCSShaderCode
    {
        /// <summary>
        /// vertex's position.
        /// </summar>
        [In]
        vec3 in_Position;

        /// <summary>
        /// vertex's color.
        /// </summar>
        [In]
        vec3 in_Color;

        /// <summary>
        /// pass color to fragment color.
        /// </summar>
        [Out]
        vec4 pass_Color;

        /// <summary>
        /// scale, rotate and translate model.
        /// </summar>
        [Uniform]
        mat4 modelMatrix;

        /// <summary>
        /// setup camera's position, target and up.
        /// </summar>
        [Uniform]
        mat4 viewMatrix;

        /// <summary>
        /// project 3D scene to 2D screen.
        /// </summar>
        [Uniform]
        mat4 projectionMatrix;

        public override void main()
        {
            // TODO: this is where you should start with vertex shader. Only ASCII code are welcome.

            // setup vertex's position
            gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, 1.0f);
            // pass color to fragment shader
            pass_Color = vec4(in_Color, 1.0f);

            // this is where your vertex shader ends.
        }
    }

    /// <summary>
    /// 一个<see cref="PyramidFrag"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// 这就是C#Shader形式的fragment shader。
    /// </summary>
    [Dump2File(true)]
	[GLSLVersion(GLSLVersion.v150)]
    sealed class PyramidFrag : FragmentCSShaderCode
    {
        /// <summary>
        /// color passed from vertex shader.
        /// </summar>
        [In]
        vec4 pass_Color;

        /// <summary>
        /// color that fragment shader dumped.
        /// any name for 'out_Color' is OK, but make sure it's a 'out vec4'
        /// </summar>
        [Out]
        vec4 out_Color;

        public override void main()
        {
            // TODO: this is where you should start with fragment shader. Only ASCII code are welcome.

            // setup color for this fragment
	        out_Color = pass_Color;

            // this is where your fragment shader ends.
        }

    }

#endif
}
