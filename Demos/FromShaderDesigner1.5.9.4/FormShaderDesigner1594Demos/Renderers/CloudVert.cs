using CSharpShaderLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormShaderDesigner1594Demos.Renderers
{
    //class CloudVert : VertexShaderCode
    //{
    //    [In]
    //    vec3 in_Position;
    //    [In]
    //    vec3 in_Normal;

    //    [Uniform]
    //    mat4 modelMatrix;
    //    [Uniform]
    //    mat4 viewMatrix;
    //    [Uniform]
    //    mat4 projectionMatrix;

    //    [Out]
    //    float LightIntensity;
    //    [Out]
    //    vec3 MCposition;

    //    [Uniform]
    //    vec3 LightPos;
    //    [Uniform]
    //    float Scale;

    //    public override void main()
    //    {
    //        // gl_TexCoord[0] = gl_MultiTexCoord0;
    //        gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(in_Position, 1.0);
    //        vec4 ECposition = viewMatrix * modelMatrix * vec4(in_Position, 1.0);
    //        MCposition = in_Position * Scale;
    //        vec3 tnorm = normalize(vec3(viewMatrix * modelMatrix * vec4(in_Normal, 1.0)));
    //        LightIntensity = dot(normalize(LightPos - vec3(ECposition)), tnorm) * 1.5;
    //    }
    //}
}
