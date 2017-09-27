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
            throw new NotImplementedException();
        }
    }
}