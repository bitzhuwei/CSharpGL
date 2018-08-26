using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c09d01_FixedSizeQuad
{
    partial class FixedSizeQuadNode : ModernNode, IRenderable
    {
        public static FixedSizeQuadNode Create(int width, int height, Texture texture)
        {
            var model = new FixedSizeQuadModel(width, height);
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var array = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("inPosition", FixedSizeQuadModel.strPosition);
            map.Add("inUV", FixedSizeQuadModel.strUV);
            var builder = new RenderMethodBuilder(array, map);

            var node = new FixedSizeQuadNode(model, builder);
            node.texture = texture;
            node.Initialize();

            return node;
        }

        private Texture texture;

        private FixedSizeQuadNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
            this.EnableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
        }

        #region IRenderable 成员

        public ThreeFlags EnableRendering { get; set; }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[0];
            ShaderProgram program = method.Program;
            program.SetUniform("mvpMat", projection * view * model);
            program.SetUniform("tex", this.texture);
            var viewport = new int[4];
            GL.Instance.GetIntegerv((uint)GetTarget.Viewport, viewport);
            program.SetUniform("screenWidth", (float)viewport[2]);
            program.SetUniform("screenHeight", (float)viewport[3]);
            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion
    }

}
