using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// this helps clear stencil buffer because `glClear(GL_STENCIL_BUFFER_BIT);` doesn't work on my laptop.
    /// </summary>
    public partial class ClearStencilNode : ModernNode, IRenderable {
        /// <summary>
        /// this helps clear stencil buffer because `glClear(GL_STENCIL_BUFFER_BIT);` doesn't work on my laptop.
        /// </summary>
        /// <returns></returns>
        public static ClearStencilNode Create() {
            var model = new ClearStencilModel();
            var program = GLProgram.Create(vertexCode, fragmentCode); Debug.Assert(program != null);
            var map = new AttributeMap();
            var builder = new RenderMethodBuilder(program, map, new DepthMaskSwitch(false), new ColorMaskSwitch(false, false, false, false));
            var node = new ClearStencilNode(model, builder);

            node.Initialize();

            return node;
        }

        private ClearStencilNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders) {
        }

        #region IRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children | ThreeFlags.AfterChildren;
        /// <summary>
        /// Render before/after children? Render children? 
        /// RenderAction cares about this property. Other actions, maybe, maybe not, your choice.
        /// </summary>
        public ThreeFlags EnableRendering {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public unsafe void RenderBeforeChildren(RenderEventArgs? arg) {
            var gl = GL.current; if (gl != null) {
                gl.glClearStencil(0x0);
                gl.glClear(GL.GL_STENCIL_BUFFER_BIT); // this seems not working. I don't know why.(2017-12-13)
                gl.glEnable(GL.GL_STENCIL_TEST);
                gl.glStencilFunc(GL.GL_ALWAYS, 0, 0xFF);
                gl.glStencilOp(GL.GL_REPLACE, GL.GL_REPLACE, GL.GL_REPLACE);
                gl.glStencilMask(0xFF);
                //gl.glDepthMask(false);
                //gl.glColorMask(false, false, false, false);
            }

            RenderMethod method = this.RenderUnit.Methods[0];
            method.Render();

            //GL.Instance.ColorMask(true, true, true, true);
            //GL.Instance.DepthMask(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        public void RenderAfterChildren(RenderEventArgs arg) {
        }

        #endregion
    }
}
