using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Render <see cref="GLControl"/> objects.
    /// </summary>
    public class GUIRenderAction : DependentActionBase
    {
        /// <summary>
        /// Render <see cref="IRenderable"/> objects.
        /// </summary>
        /// <param name="scene"></param>
        public GUIRenderAction(Scene scene) : base(scene) { }

        /// <summary>
        /// 
        /// </summary>
        public override void Act()
        {
            var scissor = new int[4];
            var viewport = new int[4];
            GL.Instance.GetIntegerv((uint)GetTarget.ScissorBox, scissor);
            GL.Instance.GetIntegerv((uint)GetTarget.Viewport, viewport);

            GUIRenderAction.Render(this.Scene.RootControl);

            GL.Instance.Scissor(scissor[0], scissor[1], scissor[2], scissor[3]);
            GL.Instance.Viewport(viewport[0], viewport[1], viewport[2], viewport[3]);
        }

        private static void Render(GLControl control)
        {
            if (control != null)
            {
                GLControlRendererBase renderer = control.Renderer;
                if (renderer != null)
                {
                    renderer.Render(control);
                }

                foreach (var item in control.Children)
                {
                    GUIRenderAction.Render(item);
                }
            }
        }
    }
}