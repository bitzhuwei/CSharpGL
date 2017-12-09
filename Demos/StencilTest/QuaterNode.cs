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

        protected override void DoInitialize()
        {
            base.DoInitialize();

            //var stencilFunc = new StencilFuncState(EStencilFunc.Always, 1, 0xFF);
            //var stencilOp = new StencilOpState(EStencilOp.Keep, EStencilOp.Keep, EStencilOp.Replace);
            //var stencilMask = new StencilMaskState(0xFF);
            //var colorMask = new ColorMaskState(false, false, false, false);
            //var depthMask = new DepthMaskState(false);
            //var clearBuffer = new UserDefineState();
            //clearBuffer.On += clearBuffer_On;
            //var list = this.RenderUnit.Methods[0].StateList;
            //list.Add(stencilFunc);
            //list.Add(stencilOp);
            //list.Add(stencilMask);
            ////list.Add(colorMask);
            //list.Add(depthMask);
            //list.Add(clearBuffer);
        }

        void clearBuffer_On(object sender, EventArgs e)
        {
            GL.Instance.Clear(GL.GL_STENCIL_BUFFER_BIT);
        }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            StencilStates();

            RenderMethod method = this.RenderUnit.Methods[0];
            method.Render();
        }

        private static void StencilStates()
        {
            GL.Instance.ClearStencil(0x0);
            GL.Instance.Clear(GL.GL_STENCIL_BUFFER_BIT);

            int[] values = new int[1];
            int value = values[0];
            //GL.Instance.GetIntegerv(GL.GL_STENCIL_FUNC, values);value = values[0];
            //GL.Instance.GetIntegerv(GL.GL_STENCIL_REF, values);value = values[0];
            //GL.Instance.GetIntegerv(GL.GL_STENCIL_VALUE_MASK, values);value = values[0];
            GL.Instance.StencilFunc(GL.GL_ALWAYS, 1, 0xFF);
            //GL.Instance.GetIntegerv(GL.GL_STENCIL_FUNC, values);value = values[0];
            //GL.Instance.GetIntegerv(GL.GL_STENCIL_REF, values);value = values[0];
            //GL.Instance.GetIntegerv(GL.GL_STENCIL_VALUE_MASK, values);value = values[0];

            //GL.Instance.GetIntegerv(GL.GL_STENCIL_FAIL, values);
            //GL.Instance.GetIntegerv(GL.GL_STENCIL_PASS_DEPTH_FAIL, values);value = values[0];
            //GL.Instance.GetIntegerv(GL.GL_STENCIL_PASS_DEPTH_PASS, values);value = values[0];
            GL.Instance.StencilOp(GL.GL_KEEP, GL.GL_KEEP, GL.GL_REPLACE);
            //GL.Instance.GetIntegerv(GL.GL_STENCIL_FAIL, values);value = values[0];
            //GL.Instance.GetIntegerv(GL.GL_STENCIL_PASS_DEPTH_FAIL, values);value = values[0];
            //GL.Instance.GetIntegerv(GL.GL_STENCIL_PASS_DEPTH_PASS, values);value = values[0];

            //GL.Instance.GetIntegerv(GL.GL_STENCIL_TEST, values);value = values[0];
            byte b = GL.Instance.IsEnabled(GL.GL_STENCIL_TEST);
            GL.Instance.Enable(GL.GL_STENCIL_TEST);
            b = GL.Instance.IsEnabled(GL.GL_STENCIL_TEST);
            //GL.Instance.GetIntegerv(GL.GL_STENCIL_TEST, values);value = values[0];

            //GL.Instance.GetIntegerv(GL.GL_STENCIL_WRITEMASK, values); value = values[0];
            //GL.Instance.GetIntegerv(GL.GL_STENCIL_BACK_WRITEMASK, values); value = values[0];
            //GL.Instance.GetIntegerv(GL.GL_STENCIL_BITS, values); value = values[0];
            GL.Instance.StencilMask(0xFF);
            //GL.Instance.GetIntegerv(GL.GL_STENCIL_WRITEMASK, values); value = values[0];
            //GL.Instance.GetIntegerv(GL.GL_STENCIL_BACK_WRITEMASK, values); value = values[0];
            //GL.Instance.GetIntegerv(GL.GL_STENCIL_BITS, values); value = values[0];

            GL.Instance.DepthMask(false);
            //GL.Instance.ColorMask(false, false, false, false);
            //GL.Instance.Clear(GL.GL_STENCIL_BUFFER_BIT);
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
            GL.Instance.StencilFunc(GL.GL_EQUAL, 1, 0xFF);
            GL.Instance.StencilOp(GL.GL_KEEP, GL.GL_KEEP, GL.GL_KEEP);
            //GL.Instance.StencilMask(0x00);
            GL.Instance.DepthMask(true);
            //GL.Instance.ColorMask(true, true, true, true);
        }
    }
}
