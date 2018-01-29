using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Base type for rendering actions.
    /// </summary>
    public abstract class ActionBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public abstract void Act(ActionParams param);

    }
}
