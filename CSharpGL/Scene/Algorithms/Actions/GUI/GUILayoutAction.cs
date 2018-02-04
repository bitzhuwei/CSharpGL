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
    public class GUILayoutAction : ActionBase
    {
        private GLControl rootControl;
        /// <summary>
        /// Render <see cref="GLControl"/> objects.
        /// </summary>
        /// <param name="rootControl"></param>
        public GUILayoutAction(GLControl rootControl)
        {
            this.rootControl = rootControl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public override void Act(ActionParams param)
        {
            GLControl root = this.rootControl;
            if (root != null)
            {
                root.UpdateAbsLocation();
            }
        }

    }
}