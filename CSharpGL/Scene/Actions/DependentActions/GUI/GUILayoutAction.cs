using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Render <see cref="IRenderable"/> objects.
    /// </summary>
    public class GUILayoutAction : DependentActionBase
    {
        /// <summary>
        /// Render <see cref="IRenderable"/> objects.
        /// </summary>
        /// <param name="scene"></param>
        public GUILayoutAction(Scene scene) : base(scene) { }

        /// <summary>
        /// 
        /// </summary>
        public override void Act()
        {
            GLControl.Layout(this.Scene.RootControl);
        }

    }
}