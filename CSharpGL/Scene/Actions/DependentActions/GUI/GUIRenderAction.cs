using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Render <see cref="IGLControl"/> objects.
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
            GUIRenderAction.Render(this.Scene.RootControl);
        }

        private static void Render(GLControl control)
        {
            if (control != null)
            {
                IGLControlRenderer renderer = control.Renderer;
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