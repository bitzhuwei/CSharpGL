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
    class DiffuseReflectionVert : VertexCSShaderCode
    {
        [In]
        vec3 in_Position;
        [In]
        vec3 in_Normal;

        [Out]
        vec4 pass_Position;

        [Out]
        vec4 pass_Color;

        [Uniform]
        mat4 modelMatrix;
        [Uniform]
        mat4 viewMatrix;
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

        public override void main()
        {
            gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, 1.0f);
            vec3 worldPos = (viewMatrix * modelMatrix * vec4(in_Position, 1.0f)).xyz;
            vec3 N = (viewMatrix * modelMatrix * vec4(in_Normal, 1.0f)).xyz;
            N = normalize(N);

            //计算入射光方向
            vec3 L = lightPosition - worldPos;
            L = normalize(L);

            //计算方向光漫反射光强
            vec3 diffuseColor = Kd * lightColor * max(dot(N, L), 0);

            //计算环境光漫反射光强
            vec3 ambientColor = Kd * globalAmbient;

            pass_Color.xyz = diffuseColor + ambientColor;
            pass_Color.w = 1;
        }
    }

    /// <summary>
    /// 一个<see cref="DiffuseReflectionFrag"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// 这就是C#Shader形式的fragment shader。
    /// </summary>
    [Dump2File(true)]
    class DiffuseReflectionFrag : FragmentCSShaderCode
    {
        [In]
        vec4 pass_Color;

        [Out]
        vec4 out_Color;

        public override void main()
        {
            out_Color = pass_Color;
        }
    }

#endif
}
