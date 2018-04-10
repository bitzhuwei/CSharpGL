using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace Lighting.ShadowMapping.InsidePyramid
{
    partial class TriangleNode : PickableNode, IRenderable
    {
        private PolygonModeSwitch polygonMode = new PolygonModeSwitch(PolygonMode.Line);

        public static TriangleNode Create()
        {
            var model = new TriangleModel();
            var vs = new VertexShader(regularVert);
            var fs = new FragmentShader(regularFrag);
            var array = new ShaderArray(vs, fs);
            var map = new PropertyMap();
            map.Add("inPosition", TriangleModel.strPosition);
            map.Add("inColor", TriangleModel.strColor);
            var builder = new RenderMethodBuilder(array, map);
            var node = new TriangleNode(model, TriangleModel.strPosition, builder);
            node.Initialize();

            return node;
        }

        private TriangleNode(IBufferSource model, string positionNameInIBufferSource, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders)
        {
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

            this.polygonMode.On();
            method.Render();
            this.polygonMode.Off();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion

    }
}
