using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    //[Editor(typeof(IListEditor<GLState>), typeof(UITypeEditor))]
    public class GLStateList : List<GLState>, IGLState
    {
        public void On()
        {
            for (int i = 0; i < this.Count; i++)
            {
                this[i].On();
            }
        }

        public void Off()
        {
            for (int i = this.Count - 1; i >= 0; i++)
            {
                this[i].Off();
            }
        }
    }
}