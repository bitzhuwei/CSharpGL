using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public abstract partial class GLControl
    {

        /// <summary>
        /// 
        /// </summary>
        public void UpdateAbsLocation()
        {
            GLControl parent = this;
            foreach (var control in parent.Children)
            {
                control.absLeft = parent.absLeft + control.left;
                control.absBottom = parent.absBottom + control.bottom;

                control.UpdateAbsLocation();
            }
        }
    }
}
