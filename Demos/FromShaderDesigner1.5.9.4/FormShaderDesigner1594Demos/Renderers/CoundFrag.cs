using CSharpShaderLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormShaderDesigner1594Demos.Renderers
{
    //class CoundFrag : FragmentShaderCode
    //{
    //    [In]
    //    float LightIntensity;
    //    [In]
    //    vec3 MCposition;
    //    [Uniform]
    //    float TIME_FROM_INIT;
    //    [Uniform]
    //    sampler3D Noise;
    //    vec3 Offset = vec3(0, 0, 0);
    //    [Uniform]
    //    vec3 SkyColor;     // (0.0, 0.0, 0.8)
    //    [Uniform]
    //    vec3 CloudColor;   // (0.8, 0.8, 0.8)
    //    public override void main()
    //    {
    //        float offset = TIME_FROM_INIT * 0.0001;
    //        Offset = vec3(-offset, offset, offset); // uncomment this line for animation
    //        vec4 noisevec = texture3D(Noise, MCposition + Offset);
    //        float intensity = (noisevec[0] + noisevec[1] +
    //                           noisevec[2] + noisevec[3] + 0.03125) * 1.5;
    //        vec3 color = mix(SkyColor, CloudColor, intensity) * LightIntensity;
    //        color = clamp(color, 0.0, 1.0);
    //        gl_FragColor = vec4(color, 1.0);
    //    }
    //}
}
