using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c03d06_FragCoord
{
    partial class RectNode : ModernNode, IRenderable
    {
        public static RectNode Create(int x, int y, int width, int height)
        {
            var model = new RectModel();
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var array = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("inPosition", RectModel.strPosition);
            var builder = new RenderMethodBuilder(array, map);

            var node = new RectNode(x, y, width, height, model, builder);
            node.Initialize();

            return node;
        }

        private RectNode(int x, int y, int width, int height, IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
            this.EnableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
        }


        #region IRenderable 成员

        public ThreeFlags EnableRendering { get; set; }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            var viewport = new float[4];
            GL.Instance.GetFloatv((uint)GetTarget.Viewport, viewport);
            //var vp = new vec4(viewport[0], viewport[1], viewport[2], viewport[3]);

            var method = this.RenderUnit.Methods[0];
            ShaderProgram program = method.Program;
            program.SetUniform("width", viewport[2]);
            program.SetUniform("height", viewport[3]);
            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion
    }
}
