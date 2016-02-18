
namespace CSharpGL.Objects.Demos
{
    // 不可将此文件中的代码复制到其他文件内（如果包含了其他的using ...;，那么CSSL2GLSL.exe就无法正常编译这些代码了。）
    using CSharpShadingLanguage;

#if DEBUG

    /// <summary>
    /// 一个<see cref="LifeBarVert"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// 这就是C#Shader形式的vertex shader。
    /// </summary>
    [Dump2File(true)]
    [GLSLVersion(GLSLVersion.v150)]
    sealed class LifeBarVert : VertexCSShaderCode
    {
        /// <summary>
        /// vertex's position.
        /// </summar>
        [In]
        vec3 in_Position;

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
            gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, 1.0f);
            // this is where your vertex shader ends.
        }
    }

    /// <summary>
    /// 一个<see cref="LifeBarFrag"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// 这就是C#Shader形式的fragment shader。
    /// </summary>
    [Dump2File(true)]
    [GLSLVersion(GLSLVersion.v150)]
    sealed class LifeBarFrag : FragmentCSShaderCode
    {

        /// <summary>
        /// color that fragment shader dumped.
        /// </summar>
        [Out]
        vec4 outColor;

        public override void main()
        {
            // TODO: this is where you should start with fragment shader. Only ASCII code are welcome.
            outColor = vec4(1, 0, 0, 1.0f);
            // this is where your fragment shader ends.
        }
    }

    [Dump2File(true)]
    [GLSLVersion(GLSLVersion.v150)]
    sealed class LifeBarGeom : GeometryCSShaderCode
    {
        public override InType LayoutIn
        {
            get { return InType.triangles; }
        }

        public override OutType LayoutOut
        {
            get { return OutType.triangle_strip; }
        }

        public override int max_vertices
        {
            get { return 27; }
        }

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
            int i;

            for (i = 0; i < gl_in.length(); i++)
            {
                vec4 position = gl_in[i].gl_Position;
                gl_Position = projectionMatrix * viewMatrix * (modelMatrix * position);
                EmitVertex();
            }
            EndPrimitive();

        }
    }

#endif
}
