using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public interface IGLSwitch
    {
        /// <summary>
        /// 
        /// </summary>
        void On();

        /// <summary>
        /// 
        /// </summary>
        void Off();
    }
}