using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class RenderAction : GLAction
    {
        private static readonly Type type = typeof(RenderAction);
        internal override Type ThisTypeCache
        {
            get { return type; }
        }

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
