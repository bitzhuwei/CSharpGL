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
        /// <summary>
        /// 
        /// </summary>
        public IGLCanvas Canvas { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="canvas"></param>
        public ActionParams(IGLCanvas canvas)
        {
            this.Canvas = canvas;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}", this.Canvas);
        }
    }
}
