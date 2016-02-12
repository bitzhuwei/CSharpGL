
namespace CSharpShaders
{
    // 不可将此文件中的代码复制到其他文件内（如果包含了其他的using ...;，那么CSSL2GLSL.exe就无法正常编译这些代码了。）
    using CSharpShadingLanguage;

#if DEBUG

    /// <summary>
    /// 一个<see cref="PhongPointLightVert"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// 这就是C#Shader形式的vertex shader。
    /// </summary>
    [Dump2File(true)]
    class PhongPointLightVert : VertexCSShaderCode
    {
        /// <summary>
        /// vertex's position.
        /// </summar>
        [In]
        vec3 in_Position;

        /// <summary>
        /// vertex's normal.
        /// </summar>
        [In]
        vec3 in_Normal;

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

        [Uniform]
        vec3 lightPosition;
        [Uniform]
        vec3 lightColor;
        [Uniform]
        vec3 globalAmbient;
        [Uniform]
        float Kd;
        [Uniform]
        float Ks;
        [Uniform]
        float shininess;

        public override void main()
        {
            gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, 1.0f);
            vec3 worldPos = (viewMatrix * modelMatrix * vec4(in_Position, 1.0f)).xyz;
            vec3 N = (transpose(inverse(viewMatrix * modelMatrix)) * vec4(in_Normal, 1.0f)).xyz;
            N = normalize(N);

            // light's direction
            vec3 L = (viewMatrix * vec4(lightPosition, 1.0f)).xyz - worldPos;// point light
            L = normalize(L);

            // eye's direction
            vec3 V = normalize(vec3(0.0f, 0.0f, 0.0f) - worldPos);

            // reflection direction
            vec3 R = normalize(2 * max(dot(N, L), 0) * N - L);

            // diffuse color from directional light
            vec3 diffuseColor = lightColor * max(dot(N, L), 0);

            // ambient color
            vec3 ambientColor = globalAmbient;

            // pecular color
            vec3 specularColor = lightColor * pow(max(dot(V, R), 0), shininess);

            pass_Color.xyz = Ks * specularColor + Kd * diffuseColor + Kd * ambientColor;
            pass_Color.w = 1;
        }
    }

    /// <summary>
    /// 一个<see cref="PhongPointLightFrag"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// 这就是C#Shader形式的fragment shader。
    /// </summary>
    [Dump2File(true)]
    class PhongPointLightFrag : FragmentCSShaderCode
    {
        /// <summary>
        /// color passed from vertex shader.
        /// </summar>
        [In]
        vec4 pass_Color;

        /// <summary>
        /// color that fragment shader dumped.
        /// </summar>
        [Out]
        vec4 out_Color;

        public override void main()
        {
            // TODO: this is where you should start with fragment shader. Only ASCII code are welcome.
            out_Color = pass_Color;
            // this is where your fragment shader ends.
        }
    }

#endif
}
