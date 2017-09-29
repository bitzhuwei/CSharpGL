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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
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
