using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class RenderAction : GLAction
    {
        //private static readonly Type type = typeof(RenderAction);
        //internal override Type ThisTypeCache
        //{
        //    get { return type; }
        //}

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

        /// <summary>
        /// 
        /// </summary>
        public void Render()
        {
            if (this.AppliedNode == null) { throw new Exception("No node applied!"); }

            this.Context.Render();
        }

    }
}
