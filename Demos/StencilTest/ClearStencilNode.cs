using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace StencilTest
{
    /// <summary>
    /// Displays on quater of canvas.
    /// </summary>
    partial class ClearStencilNode : ModernNode
    {
        public static ClearStencilNode Create()
        {
            var model = new ClearStencilModel();
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var array = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            var builder = new RenderMethodBuilder(array, map);
            var node = new ClearStencilNode(model, builder);

            node.Initialize();

            return node;
        }

        private ClearStencilNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
        }

        private vec4 stencilColor = new vec4(0, 0, 0, 0);
        public vec4 StencilColor
        {
            get { return this.stencilColor; }
            set
            {
                this.stencilColor = value;
                ModernRenderUnit renderUnit = this.RenderUnit;
                if (renderUnit == null) { return; }
                RenderMethod[] methods = renderUnit.Methods;
                if (methods == null || methods.Length < 1) { return; }
                RenderMethod method = methods[0];
                if (method == null) { return; }
                method.Render();
                ShaderProgram program = method.Program;
                if (program == null) { return; }

                program.SetUniform("color", this.stencilColor);
            }
        }
        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            GL.Instance.ClearStencil(0x0);
            GL.Instance.Clear(GL.GL_STENCIL_BUFFER_BIT); // this seems not working. I don't know why.(2017-12-13)
            GL.Instance.Enable(GL.GL_STENCIL_TEST);
            GL.Instance.StencilFunc(GL.GL_ALWAYS, 0, 0xFF);
            GL.Instance.StencilOp(GL.GL_REPLACE, GL.GL_REPLACE, GL.GL_REPLACE);
            GL.Instance.StencilMask(0xFF);
            GL.Instance.DepthMask(false);
            GL.Instance.ColorMask(false, false, false, false);

            RenderMethod method = this.RenderUnit.Methods[0];
            method.Render();

            GL.Instance.ColorMask(true, true, true, true);
            GL.Instance.DepthMask(true);
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}
