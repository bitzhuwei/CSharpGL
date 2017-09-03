using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    [Editor(typeof(IListEditor<GLState>), typeof(UITypeEditor))]
    public interface IGLState
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