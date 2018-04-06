using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace c06d00_TextureArray
{
    partial class RectangleNode : ModernNode, IRenderable
    {
        private Texture texture;
        public static RectangleNode Create(Texture texture)
        {
            var model = new RectangleModel();
            var vertexShader = new VertexShader(vert);
            var fragmentShader = new FragmentShader(frag);
            var programProvider = new ShaderArray(vertexShader, fragmentShader);
            var map = new AttributeMap();
            map.Add("inPosition", RectangleModel.strPositoin);
            map.Add("inUV", RectangleModel.strUV);
            var builder = new RenderMethodBuilder(programProvider, map, new BlendSwitch(BlendEquationMode.Add, BlendSrcFactor.SrcAlpha, BlendDestFactor.OneMinusSrcAlpha));
            var node = new RectangleNode(model, builder);
            node.SetTexture(texture);
            node.Initialize();

            return node;
        }

        private void SetTexture(Texture texture)
        {
            this.texture = texture;
        }

        private RectangleNode(IBufferSource model, params RenderMethodBuilder[] builders) : base(model, builders) { }

        #region IRenderable 成员

        public ThreeFlags EnableRendering
        {
            get { return ThreeFlags.BeforeChildren | ThreeFlags.AfterChildren | ThreeFlags.Children; }
            set { /* nothing need to do. */ }
        }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            RenderMethod method = this.RenderUnit.Methods[0];
            ShaderProgram program = method.Program;
            program.SetUniform("mvpMat", projection * view * model);
            program.SetUniform("tex", texture);

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
            // nothing to do.
        }

        #endregion
    }
}
