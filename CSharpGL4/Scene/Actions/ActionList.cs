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
            if (this.Count > 0)
            {
                const bool firstPass = true;
                ActionBase firstAction = this[0];
                firstAction.Render(firstPass);

                for (int i = 1; i < this.Count; i++)
                {
                    this[i].Render(!firstPass);
                }
            }
        }
    }
}