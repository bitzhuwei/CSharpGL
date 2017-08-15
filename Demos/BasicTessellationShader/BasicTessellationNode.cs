using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace BasicTessellationShader
{
    public partial class BasicTessellationNode : ModernNode
    {

        public static BasicTessellationNode Create(ObjVNF model)
        {
            var vs = new VertexShader(renderVert, "Position_VS_in", "TexCoord_VS_in", "Normal_VS_in");
            var tc = new TessControlShader(renderTesc);
            var te = new TessEvaluationShader(renderTese);
            var fs = new FragmentShader(renderFrag);
            var provider = new ShaderArray(vs, tc, te, fs);
            var map = new AttributeMap();
            map.Add("Position_VS_in", ObjVNF.strPosition);
            map.Add("TexCoord_VS_in", ObjVNF.strTexCoord);
            map.Add("Normal_VS_in", ObjVNF.strNormal);
            var builder = new RenderUnitBuilder(provider, map);

            var node = new BasicTessellationNode(model, builder);
            node.Initialize();

            return node;
        }

        private BasicTessellationNode(IBufferSource model, params RenderUnitBuilder[] builders)
            : base(model, builders)
        {
        }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            RenderUnit unit = this.RenderUnits[0];
            ShaderProgram program = unit.Program;
            //program.SetUniform()
            //uniform mat4 gWorld;                                                                            
            //uniform vec3 gEyeWorldPos;                                                                      
            //uniform mat4 gVP;                                                                               
            //uniform sampler2D gDisplacementMap;                                                             
            //uniform float gDispFactor;                                                                      
            //uniform int gNumPointLights;                                                                
            //uniform int gNumSpotLights;                                                                 
            //uniform DirectionalLight gDirectionalLight;                                                 
            //uniform PointLight gPointLights[MAX_POINT_LIGHTS];                                          
            //uniform SpotLight gSpotLights[MAX_SPOT_LIGHTS];                                             
            //uniform sampler2D gColorMap;                                                                
            //uniform vec3 gEyeWorldPos;                                                                  
            //uniform float gMatSpecularIntensity;                                                        
            //uniform float gSpecularPower;                                                               

            unit.Render();
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}
