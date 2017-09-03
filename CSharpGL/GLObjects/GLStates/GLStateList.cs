using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    [Editor(typeof(IListEditor<GLState>), typeof(UITypeEditor))]
    public class GLStateList : List<GLState>, IGLState
    {
        /// <summary>
        /// 
        /// </summary>
        public void On()
        {
            for (int i = 0; i < this.Count; i++)
            {
                this[i].On();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Off()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                this[i].Off();
            }
        }
    }
}