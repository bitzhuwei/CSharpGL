using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// this helps clear stencil buffer because `glClear(GL_STENCIL_BUFFER_BIT);` doesn't work on my laptop.
    /// </summary>
    public partial class ClearStencilNode : ModernNode, IRenderable
    {
        /// <summary>
        /// this helps clear stencil buffer because `glClear(GL_STENCIL_BUFFER_BIT);` doesn't work on my laptop.
        /// </summary>
        /// <returns></returns>
        public static ClearStencilNode Create()
        {
            var model = new ClearStencilModel();
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var array = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            var builder = new RenderMethodBuilder(array, map, new DepthMaskSwitch(false), new ColorMaskSwitch(false, false, false, false));
            var node = new ClearStencilNode(model, builder);

            node.Initialize();

            return node;
        }

        private ClearStencilNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
        }

        #region IRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children | ThreeFlags.AfterChildren;
        /// <summary>
        /// Render before/after children? Render children? 
        /// RenderAction cares about this property. Other actions, maybe, maybe not, your choice.
        /// </summary>
        [Browsable(false)]
        [Category("IRenderable")]
        [Description("Render before/after children? Render children?")]
        public ThreeFlags EnableRendering
        {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            GL.Instance.ClearStencil(0x0);
            GL.Instance.Clear(GL.GL_STENCIL_BUFFER_BIT); // this seems not working. I don't know why.(2017-12-13)
            GL.Instance.Enable(GL.GL_STENCIL_TEST);
            GL.Instance.StencilFunc(GL.GL_ALWAYS, 0, 0xFF);
            GL.Instance.StencilOp(GL.GL_REPLACE, GL.GL_REPLACE, GL.GL_REPLACE);
            GL.Instance.StencilMask(0xFF);
            //GL.Instance.DepthMask(false);
            //GL.Instance.ColorMask(false, false, false, false);

            RenderMethod method = this.RenderUnit.Methods[0];
            method.Render();

            //GL.Instance.ColorMask(true, true, true, true);
            //GL.Instance.DepthMask(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion
    }
}
