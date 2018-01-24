using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    [Editor(typeof(IListEditor<IGLState>), typeof(UITypeEditor))]
    public class GLStateList : List<IGLState>, IGLState
    {
        /// <summary>
        /// 
        /// </summary>
        public GLStateList() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        public GLStateList(params IGLState[] state)
        {
            this.AddRange(state);
        }

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