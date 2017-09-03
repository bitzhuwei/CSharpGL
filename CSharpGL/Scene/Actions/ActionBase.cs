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
        public Scene Scene { get; set; }

        /// <summary>
        /// Base type for rendering actions.
        /// </summary>
        /// <param name="scene"></param>
        public ActionBase(Scene scene)
        {
            this.Scene = scene;
        }
    }
}
