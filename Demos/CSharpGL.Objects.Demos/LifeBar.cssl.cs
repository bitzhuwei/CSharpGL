
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
            gl_Position = vec4(in_Position, 1.0f);
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
        //TODO: vec3(1, 0, 0);自动转换到GLSL
        [Uniform]
        vec3 color = vec3(1, 0, 0);

        /// <summary>
        /// color that fragment shader dumped.
        /// </summar>
        [Out]
        vec4 outColor;

        public override void main()
        {
            // TODO: this is where you should start with fragment shader. Only ASCII code are welcome.
            outColor = vec4(color, 1.0f);
            // this is where your fragment shader ends.
        }
    }

    class VS_GS_VERTEX
    {
        public vec3 normal;
    }

    [Dump2File(true)]
    [GLSLVersion(GLSLVersion.v150)]
    sealed class LifeBarGeom : GeometryCSShaderCode
    {
        public override InType LayoutIn
        {
            get { return InType.points; }
        }

        public override OutType LayoutOut
        {
            get { return OutType.triangle_strip; }
        }

        public override int max_vertices
        {
            get { return 27; }
        }

        class GS_FS_VERTEX
        {
            public vec3 color;
        }
        [Out]
        GS_FS_VERTEX vertex_out;

        [Uniform]
        float length = 1f;

        [Uniform]
        float width = 1f;

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
            vec4 position;
            for (i = 0; i < gl_in.length(); i++)
            {
                position = gl_in[i].gl_Position;
                position.x = length / 2 + position.x;
                position.y = width / 2 + position.y;
                gl_Position = projectionMatrix * viewMatrix * (modelMatrix * position);
                EmitVertex();

                position = gl_in[i].gl_Position;
                position.x = length / 2 + position.x;
                position.y = -width / 2 + position.y;
                gl_Position = projectionMatrix * viewMatrix * (modelMatrix * position);
                EmitVertex();

                position = gl_in[i].gl_Position;
                position.x = -length / 2 + position.x;
                position.y = width / 2 + position.y;
                gl_Position = projectionMatrix * viewMatrix * (modelMatrix * position);
                EmitVertex();

                position = gl_in[i].gl_Position;
                position.x = -length / 2 + position.x;
                position.y = -width / 2 + position.y;
                gl_Position = projectionMatrix * viewMatrix * (modelMatrix * position);
                EmitVertex();

            }
            EndPrimitive();

        }
    }

#endif
}
