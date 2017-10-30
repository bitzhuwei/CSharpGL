using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpGL
{
    //
    // 0---------3
    // |         |
    // |         |
    // |         |
    // 1---------2
    //
    /// <summary>
    /// A quad renders in GL_QUADS mode.
    /// </summary>
    public struct QuadStruct
    {
        /// <summary>
        /// 
        /// </summary>
        public vec2 leftTop;
        /// <summary>
        /// 
        /// </summary>
        public vec2 leftBottom;
        /// <summary>
        /// 
        /// </summary>
        public vec2 rightBottom;
        /// <summary>
        /// 
        /// </summary>
        public vec2 rightTop;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leftTop"></param>
        /// <param name="leftBottom"></param>
        /// <param name="rightBottom"></param>
        /// <param name="rightTop"></param>
        public QuadStruct(vec2 leftTop, vec2 leftBottom, vec2 rightBottom, vec2 rightTop)
        {
            this.leftTop = leftTop; this.rightTop = rightTop;
            this.leftBottom = leftBottom; this.rightBottom = rightBottom;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("leftTop:{0}, leftBotttom:{1}, rightBottom:{2}, rightTop:{3}",
                this.leftTop, this.leftBottom, this.rightBottom, this.rightTop);
        }
    }
}
