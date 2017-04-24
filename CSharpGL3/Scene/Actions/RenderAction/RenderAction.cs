using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class RenderAction : SceneAction
    {
        /// <summary>
        /// 
        /// </summary>
        public RenderAction()
        {
            this.Context = new RenderActionContext();
        }

        /// <summary>
        /// 
        /// </summary>
        public RenderActionContext Context { get; set; }
    }
}
