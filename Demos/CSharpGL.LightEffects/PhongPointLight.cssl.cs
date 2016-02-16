
namespace CSharpGL.LightEffects
{
    // 不可将此文件中的代码复制到其他文件内（如果包含了其他的using ...;，那么CSSL2GLSL.exe就无法正常编译这些代码了。）
    using CSharpShadingLanguage;

#if DEBUG

    /// <summary>
    /// 一个<see cref="DiffuseReflectionVert"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// 这就是C#Shader形式的vertex shader。
    /// </summary>
    [Dump2File(true)]
    class PhongPointLightVert : VertexCSShaderCode
    {
        [In]
        vec3 in_Position;
        [In]
        vec3 in_Normal;

        [Out]
        vec3 pass_worldPos;
        [Out]
        vec3 pass_worldNormal;
        [Out]
        vec3 pass_lightPosition;

        [Uniform]
        mat4 modelMatrix;
        [Uniform]
        mat4 viewMatrix;
        [Uniform]
        mat4 projectionMatrix;
        [Uniform]
        vec3 lightPosition;

        public override void main()
        {
            gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, 1.0f);
            vec3 worldPos = (viewMatrix * modelMatrix * vec4(in_Position, 1.0f)).xyz;
            vec3 N = (transpose(inverse(viewMatrix * modelMatrix)) * vec4(in_Normal, 1.0f)).xyz;
            N = normalize(N);

            pass_worldPos = worldPos;
            pass_worldNormal = N;

            // light's direction
            vec3 L = (transpose(inverse(viewMatrix)) * vec4(lightPosition, 1.0f)).xyz;// directional light
            L = normalize(L);
            pass_lightPosition = L;
        }
    }

    /// <summary>
    /// 一个<see cref="DiffuseReflectionFrag"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// 这就是C#Shader形式的fragment shader。
    /// </summary>
    [Dump2File(true)]
    class PhongPointLightFrag : FragmentCSShaderCode
    {
        [In]
        vec3 pass_worldPos;

        [In]
        vec3 pass_worldNormal;

        [In]
        vec3 pass_lightPosition;

        [Out]
        vec4 out_Color;

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

            // diffuse color from directional light
            vec3 diffuseColor = Kd * lightColor * max(dot(pass_worldNormal, pass_lightPosition), 0);

            // ambient color
            vec3 ambientColor = Kd * globalAmbient;

            out_Color.xyz = diffuseColor + ambientColor;
            out_Color.w = 1;
            // eye's direction
            vec3 V = normalize(vec3(0.0f, 0.0f, 0.0f) - pass_worldPos);

            // reflection direction
            vec3 R = normalize(2 * max(dot(pass_worldNormal, pass_lightPosition), 0) * pass_worldNormal - pass_lightPosition);

            // pecular color
            vec3 specularColor = lightColor * pow(max(dot(V, R), 0), shininess);

            out_Color.xyz = Ks * specularColor + Kd * diffuseColor + Kd * ambientColor;
            out_Color.w = 1;
        }
    }

#endif
}

//// this shows the same functions but calculations are mainly done in vertex shader.
//namespace CSharpShaders
//{
//    // 不可将此文件中的代码复制到其他文件内（如果包含了其他的using ...;，那么CSSL2GLSL.exe就无法正常编译这些代码了。）
//    using CSharpShadingLanguage;

//#if DEBUG

//    /// <summary>
//    /// 一个<see cref="PhongPointLightVert"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
//    /// 这就是C#Shader形式的vertex shader。
//    /// </summary>
//    [Dump2File(true)]
//    class PhongPointLightVert : VertexCSShaderCode
//    {
//        /// <summary>
//        /// vertex's position.
//        /// </summar>
//        [In]
//        vec3 in_Position;

//        /// <summary>
//        /// vertex's normal.
//        /// </summar>
//        [In]
//        vec3 in_Normal;

//        /// <summary>
//        /// pass color to fragment color.
//        /// </summar>
//        [Out]
//        vec4 pass_Color;

//        /// <summary>
//        /// scale, rotate and translate model.
//        /// </summar>
//        [Uniform]
//        mat4 modelMatrix;

//        /// <summary>
//        /// setup camera's position, target and up.
//        /// </summar>
//        [Uniform]
//        mat4 viewMatrix;

//        /// <summary>
//        /// project 3D scene to 2D screen.
//        /// </summar>
//        [Uniform]
//        mat4 projectionMatrix;

//        [Uniform]
//        vec3 lightPosition;
//        [Uniform]
//        vec3 lightColor;
//        [Uniform]
//        vec3 globalAmbient;
//        [Uniform]
//        float Kd;
//        [Uniform]
//        float Ks;
//        [Uniform]
//        float shininess;

//        public override void main()
//        {
//            gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, 1.0f);
//            vec3 worldPos = (viewMatrix * modelMatrix * vec4(in_Position, 1.0f)).xyz;
//            vec3 N = (transpose(inverse(viewMatrix * modelMatrix)) * vec4(in_Normal, 1.0f)).xyz;
//            N = normalize(N);

//            // light's direction
//            vec3 L = (viewMatrix * vec4(lightPosition, 1.0f)).xyz - worldPos;// point light
//            L = normalize(L);

//            // eye's direction
//            vec3 V = normalize(vec3(0.0f, 0.0f, 0.0f) - worldPos);

//            // reflection direction
//            vec3 R = normalize(2 * max(dot(N, L), 0) * N - L);

//            // diffuse color from directional light
//            vec3 diffuseColor = lightColor * max(dot(N, L), 0);

//            // ambient color
//            vec3 ambientColor = globalAmbient;

//            // pecular color
//            vec3 specularColor = lightColor * pow(max(dot(V, R), 0), shininess);

//            pass_Color.xyz = Ks * specularColor + Kd * diffuseColor + Kd * ambientColor;
//            pass_Color.w = 1;
//        }
//    }

//    /// <summary>
//    /// 一个<see cref="PhongPointLightFrag"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
//    /// 这就是C#Shader形式的fragment shader。
//    /// </summary>
//    [Dump2File(true)]
//    class PhongPointLightFrag : FragmentCSShaderCode
//    {
//        /// <summary>
//        /// color passed from vertex shader.
//        /// </summar>
//        [In]
//        vec4 pass_Color;

//        /// <summary>
//        /// color that fragment shader dumped.
//        /// </summar>
//        [Out]
//        vec4 out_Color;

//        public override void main()
//        {
//            // TODO: this is where you should start with fragment shader. Only ASCII code are welcome.
//            out_Color = pass_Color;
//            // this is where your fragment shader ends.
//        }
//    }

//#endif
//}
