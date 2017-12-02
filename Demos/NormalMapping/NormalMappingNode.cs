using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace NormalMapping
{
    partial class NormalMappingNode : ModernNode
    {
        public static NormalMappingNode Create()
        {
            var model = new NormalMappingModel();
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var array = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("Position", NormalMappingModel.strPosition);
            map.Add("TexCoord", NormalMappingModel.strTexCoord);
            map.Add("Normal", NormalMappingModel.strNormal);
            map.Add("Tangent", NormalMappingModel.strTangent);
            var builder = new RenderMethodBuilder(array, map);
            var node = new NormalMappingNode(model, builder);

            node.Initialize();

            return node;
        }

        private NormalMappingNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
        }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            mat4 normal = glm.transpose(glm.inverse(view * model));

            RenderMethod method = this.RenderUnit.Methods[0];
            ShaderProgram program = method.Program;
            //program.SetUniform(projectionMatrix, projection);
            //program.SetUniform(viewMatrix, view);
            //program.SetUniform(modelMatrix, model);
            //program.SetUniform(normalMatrix, normal);

            method.Render();
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
            // nothing to do.
        }
    }
}
