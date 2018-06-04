using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c11d00_Arcball
{
    partial class LinesNode : ModernNode, IRenderable
    {
        public static LinesNode Create(float radius)
        {
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var array = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("inPosition", LinesModel.strPosition);
            map.Add("inColor", LinesModel.strColor);
            //var depthTestSwitch = new DepthTestSwitch(false);
            var lineWidthSwith = new LineWidthSwitch(5);
            var builder = new RenderMethodBuilder(array, map, lineWidthSwith);

            var model = new LinesModel(radius);
            var node = new LinesNode(model, builder);
            node.Initialize();

            return node;
        }

        private LinesNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
        }

        #region IRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
        public ThreeFlags EnableRendering { get { return this.enableRendering; } set { this.enableRendering = value; } }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            RenderMethod method = this.RenderUnit.Methods[0];
            ShaderProgram program = method.Program;
            // matrix.
            program.SetUniform("mvpMat", projection * view * model);
            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion

    }
}
