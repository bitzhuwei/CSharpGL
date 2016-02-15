
namespace CSharpGL.Objects.Demos
{
    // 不可将此文件中的代码复制到其他文件内（如果包含了其他的using ...;，那么CSSL2GLSL.exe就无法正常编译这些代码了。）
    using CSharpShadingLanguage;

#if DEBUG

    /// <summary>
    /// 一个<see cref="NormalLineVert"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// 这就是C#Shader形式的vertex shader。
    /// </summary>
    [Dump2File(false)]
    class NormalLineVert : VertexCSShaderCode
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
        vec3 in_Normal;

        /// <summary>
        /// pass color to fragment color.
        /// </summar>
        [Out]
        vec4 pass_Normal;

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

            pass_Normal = vec4(in_Normal, 1.0f);
            // this is where your vertex shader ends.
        }
    }

    /// <summary>
    /// 一个<see cref="NormalLineFrag"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// 这就是C#Shader形式的fragment shader。
    /// </summary>
    [Dump2File(true)]
    class NormalLineFrag : FragmentCSShaderCode
    {
        /// <summary>
        /// color passed from vertex shader.
        /// </summar>
        [In]
        vec4 pass_Normal;

        class GS_FS_VERTEX
        {
            public vec3 color;
        }
        [In]
        GS_FS_VERTEX fragment_in;

        /// <summary>
        /// color that fragment shader dumped.
        /// </summar>
        [Out]
        vec4 outColor;

        public override void main()
        {
            // TODO: this is where you should start with fragment shader. Only ASCII code are welcome.
            vec3 color = fragment_in.color;
            if (color.r < 0) { color.r = -color.r; }
            if (color.g < 0) { color.g = -color.g; }
            if (color.b < 0) { color.b = -color.b; }
            outColor = vec4(color, 1.0f);
            // this is where your fragment shader ends.
        }


    }

    [Dump2File(false)]
    class ObjFileGeom : GeometryCSShaderCode
    {
        protected override InType LayoutIn
        {
            get { return InType.points; }
        }

        protected override OutType LayoutOut
        {
            get { return OutType.triangle_strip; }
        }

        protected override int max_vertices
        {
            get { return 240; }
        }

        [Uniform]
        mat4 model_matrix;
        [Uniform]
        mat4 projection_matrix;

        [Uniform]
        int fur_layers = 30;
        [Uniform]
        float fur_depth = 5.0f;

        class VS_GS_VERTEX
        {
            public vec3 normal;
            public vec2 tex_coord;
        }
        [In]
        VS_GS_VERTEX[] vertex_in;

        class GS_FS_VERTEX
        {
            public vec3 normal;
            public vec2 tex_coord;
            [Flat]
            public float fur_strength;
        }
        [Out]
        GS_FS_VERTEX vertex_out;

        public override void main()
        {
            int i, layer;
            float disp_delta = 1.0f / Float(fur_layers);
            float d = 0.0f;
            vec4 position;

            for (layer = 0; layer < fur_layers; layer++)
            {
                for (i = 0; i < gl_in.length(); i++)
                {
                    vec3 n = vertex_in[i].normal;
                    vertex_out.normal = n;
                    vertex_out.tex_coord = vertex_in[i].tex_coord;
                    vertex_out.fur_strength = 1.0f - d;
                    position = gl_in[i].gl_Position + vec4(n * d * fur_depth, 0.0f);
                    gl_Position = projection_matrix * (model_matrix * position);
                    EmitVertex();
                }
                d += disp_delta;
                EndPrimitive();
            }
        }
    }

#endif
}
