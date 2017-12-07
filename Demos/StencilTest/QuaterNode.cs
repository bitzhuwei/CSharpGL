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
    partial class QuaterNode : ModernNode
    {
        public static QuaterNode Create()
        {
            var model = new QuaterModel();
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var array = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            //var stencilFunc = new StencilFuncState(EStencilFunc.Always, 1, 0xFF);
            //var stencilOp = new StencilOpState(EStencilOp.Keep, EStencilOp.Keep, EStencilOp.Replace);
            //var stencilMask = new StencilMaskState(0xFF);
            //var colorMask = new ColorMaskState(false, false, false, false);
            //var depthMask = new DepthMaskState(false);
            //var clearBuffer = new UserDefineState();
            //clearBuffer.On += clearBuffer_On;

            var builder = new RenderMethodBuilder(array, map);
            //, stencilFunc, stencilOp, stencilMask, colorMask, depthMask);
            var node = new QuaterNode(model, builder);

            node.Initialize();

            return node;
        }

        //static void clearBuffer_On(object sender, EventArgs e)
        //{
        //    GL.Instance.Clear(GL.GL_STENCIL_BUFFER_BIT);
        //}

        private QuaterNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
            this.EnableRendering = ThreeFlags.BeforeChildren | ThreeFlags.AfterChildren | ThreeFlags.Children;
        }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            GL.Instance.ClearStencil(0x0);
            GL.Instance.StencilFunc(GL.GL_NEVER, 0, 0x00);
            GL.Instance.StencilOp(GL.GL_INCR, GL.GL_INCR, GL.GL_INCR);
            //GL.Instance.StencilOp(GL.GL_KEEP, GL.GL_KEEP, GL.GL_REPLACE);
            GL.Instance.Enable(GL.GL_STENCIL_TEST);
            //GL.Instance.StencilMask(0xFF);
            GL.Instance.DepthMask(false);
            //GL.Instance.Clear(GL.GL_STENCIL_BUFFER_BIT);

            RenderMethod method = this.RenderUnit.Methods[0];
            method.Render();
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
            GL.Instance.StencilFunc(GL.GL_NOTEQUAL, 1, 0xFF);
            GL.Instance.StencilOp(GL.GL_KEEP, GL.GL_KEEP, GL.GL_REPLACE);
            //GL.Instance.StencilMask(0x00);
            GL.Instance.DepthMask(true);
        }
    }
}
