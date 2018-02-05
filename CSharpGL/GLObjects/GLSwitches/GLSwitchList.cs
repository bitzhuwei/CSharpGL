using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    [Editor(typeof(IListEditor<IGLSwitch>), typeof(UITypeEditor))]
    public class GLSwitchList : List<IGLSwitch>, IGLSwitch
    {
        /// <summary>
        /// 
        /// </summary>
        public GLSwitchList() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        public GLSwitchList(params IGLSwitch[] state)
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