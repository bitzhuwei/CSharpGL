using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class ActionParams
    {
        ///// <summary>
        ///// 
        ///// </summary>
        //public IGLCanvas Canvas { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Viewport Viewport { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ActionParams(Viewport viewport)
        {
            this.Viewport = viewport;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}", this.Viewport);
        }
    }
}
