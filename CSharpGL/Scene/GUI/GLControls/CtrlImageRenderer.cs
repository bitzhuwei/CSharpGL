using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Renders a <see cref="GLControl"/>.
    /// </summary>
    public class CtrlImageRenderer : GLControlRendererBase
    {
        #region IGLControlRenderer 成员

        public override void Render(GLControl control)
        {
            var ctrl = control as CtrlImage;
            if (ctrl != null)
            {

            }
        }

        #endregion
    }
}
