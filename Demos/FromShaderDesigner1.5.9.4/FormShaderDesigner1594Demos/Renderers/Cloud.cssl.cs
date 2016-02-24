// 此文件由CSharpGL.CSSLGenerator.exe生成。
// 用法：使用CSSL2GLSL.exe编译此文件，即可获得对应的vertex shader, geometry shader, fragment shader。
// 此文件中的类型不应被直接调用，发布release时可以去掉。
// 不可将此文件中的代码复制到其他文件内（如果包含了其他的using ...;，那么CSSL2GLSL.exe就无法正常编译这些代码了。）
namespace CSharpShadingLanguage.Cloud
{
    using CSharpShadingLanguage;
    
    
    /// <summary>
    /// 一个<see cref="CloudVert"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// (GLSLVersion)0 is GLSLVersion.v150
    /// </summary>
    [CSharpShadingLanguage.Dump2FileAttribute(true)]
    [CSharpShadingLanguage.GLSLVersionAttribute(((CSharpShadingLanguage.GLSLVersion)(0u)))]
    public class CloudVert : CSharpShadingLanguage.VertexCSShaderCode
    {
        
        [CSharpShadingLanguage.InAttribute()]
        private vec3 in_Position;
        
        [CSharpShadingLanguage.InAttribute()]
        private vec3 in_Normal;
        
        [CSharpShadingLanguage.UniformAttribute()]
        private mat4 projectionMatrix;
        
        [CSharpShadingLanguage.UniformAttribute()]
        private mat4 viewMatrix;
        
        [CSharpShadingLanguage.UniformAttribute()]
        private mat4 modelMatrix;
        
        [CSharpShadingLanguage.OutAttribute()]
        private float LightIntensity;
        
        [CSharpShadingLanguage.OutAttribute()]
        private vec3 MCposition;
        
        [CSharpShadingLanguage.UniformAttribute()]
        private vec3 LightPos;
        
        [CSharpShadingLanguage.UniformAttribute()]
        private float Scale;
        
        public override void main()
        {
            gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, 1.0f);
            vec4 ECposition = viewMatrix * modelMatrix * vec4(in_Position, 1.0f);
            MCposition = in_Position * Scale;
            vec3 tnorm = normalize(vec3(viewMatrix * modelMatrix * vec4(in_Normal, 1.0f)));
            LightIntensity = dot(normalize(LightPos - vec3(ECposition)), tnorm) * 1.5f;
        }
    }
    
    /// <summary>
    /// 一个<see cref="CloudFrag"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。
    /// (GLSLVersion)0 is GLSLVersion.v150
    /// </summary>
    [CSharpShadingLanguage.Dump2FileAttribute(true)]
    [CSharpShadingLanguage.GLSLVersionAttribute(((CSharpShadingLanguage.GLSLVersion)(0u)))]
    public class CloudFrag : CSharpShadingLanguage.FragmentCSShaderCode
    {
        
        [CSharpShadingLanguage.InAttribute()]
        private vec3 MCposition;
        
        [CSharpShadingLanguage.InAttribute()]
        private float LightIntensity;
        
        [CSharpShadingLanguage.OutAttribute()]
        private vec4 outputColor;
        
        [CSharpShadingLanguage.UniformAttribute()]
        private float TIME_FROM_INIT;
        
        [CSharpShadingLanguage.UniformAttribute()]
        private sampler3D Noise;
        
        [CSharpShadingLanguage.UniformAttribute()]
        private vec3 SkyColor;
        
        [CSharpShadingLanguage.UniformAttribute()]
        private vec3 CloudColor;
        
        public override void main()
        {
            float offset = TIME_FROM_INIT * 0.0001f;
            vec3 Offset = vec3(-offset, offset, offset); // uncomment this line for animation
            vec4 noisevec = texture(Noise, MCposition + Offset);
            float intensity = (noisevec[0] + noisevec[1] +
                               noisevec[2] + noisevec[3] + 0.03125f) * 1.5f;
            vec3 color = mix(SkyColor, CloudColor, intensity) * LightIntensity;
            color = clamp(color, 0.0f, 1.0f);
            outputColor = vec4(color, 1.0f);
        }
    }
}
