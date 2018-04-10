using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace Lighting.ShadowMapping.InsidePyramid
{
    partial class PyramideNode : ModernNode, IRenderable
    {
        private PolygonModeSwitch polygonMode = new PolygonModeSwitch(PolygonMode.Line);

        public static PyramideNode Create()
        {
            var pyramideModel = new PyramidModel();
            var vs = new VertexShader(regularVert);
            var fs = new FragmentShader(regularFrag);
            var array = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("inPosition", PyramidModel.strPosition);
            var builder = new RenderMethodBuilder(array, map);
            var node = new PyramideNode(pyramideModel, builder);
            node.Initialize();
            node.ModelSize = pyramideModel.size;

            return node;
        }

        private PyramideNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
            this.Color = new vec3(1, 1, 1);
        }

        #region IRenderable 成员

        public ThreeFlags EnableRendering { get { return ThreeFlags.BeforeChildren | ThreeFlags.Children; } set { } }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            RenderMethod method = this.RenderUnit.Methods[0];
            ShaderProgram program = method.Program;
            program.SetUniform("mvpMat", projection * view * model);
            program.SetUniform("color", this.Color);

            this.polygonMode.On();
            method.Render();
            this.polygonMode.Off();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion

        public vec3 Color { get; set; }
    }
}
