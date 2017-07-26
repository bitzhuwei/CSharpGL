using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// A list of <see cref="ActionBase"/>.
    /// </summary>
    public class ActionList : List<ActionBase>
    {
        /// <summary>
        /// 
        /// </summary>
        public void Render()
        {
            for (int i = 0; i < this.Count; i++)
            {
                this[i].Act();
            }
        }
    }
}