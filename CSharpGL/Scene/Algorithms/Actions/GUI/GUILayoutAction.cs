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
    public class GUILayoutAction : ActionBase
    {
        private Scene scene;
        /// <summary>
        /// Render <see cref="IRenderable"/> objects.
        /// </summary>
        /// <param name="scene"></param>
        public GUILayoutAction(Scene scene)
        {
            this.scene = scene;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public override void Act(ActionParams param)
        {
            GLControl.Layout(this.scene.RootControl);
        }

    }
}