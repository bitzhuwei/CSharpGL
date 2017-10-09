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

            var arg = new GUIRenderEventArgs(this.Scene, this.Scene.Camera);
            GUIRenderAction.Render(this.Scene.RootControl, arg);

            GL.Instance.Scissor(scissor[0], scissor[1], scissor[2], scissor[3]);
            GL.Instance.Viewport(viewport[0], viewport[1], viewport[2], viewport[3]);
        }

        private static void Render(GLControl control, GUIRenderEventArgs arg)
        {
            if (control != null)
            {
                var renderable = control as IGUIRenderable;
                ThreeFlags flags = (renderable != null) ? renderable.EnableRendering : ThreeFlags.None;
                bool before = (renderable != null) && ((flags & ThreeFlags.BeforeChildren) == ThreeFlags.BeforeChildren);
                bool children = (renderable == null) || ((flags & ThreeFlags.Children) == ThreeFlags.Children);
                bool after = (renderable != null) && ((flags & ThreeFlags.AfterChildren) == ThreeFlags.AfterChildren);

                if (before)
                {
                    renderable.RenderBeforeChildren(arg);
                }

                if (children)
                {
                    foreach (var item in control.Children)
                    {
                        GUIRenderAction.Render(item, arg);
                    }
                }

                if (after)
                {
                    renderable.RenderAfterChildren(arg);
                }
            }
        }
    }
}