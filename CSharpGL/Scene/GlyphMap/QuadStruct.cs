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
    /// A quad(u, v) renders in GL_QUADS mode.
    /// (u, v) is texture coordinate of this quad in the glyph map.
    /// (u, v) is between [0, 0] and [1, 1].
    /// </summary>
    public struct QuadPositionStruct
    {
        /// <summary>
        /// between [0, 0] and [1, 1].
        /// </summary>
        public vec2 leftTop;
        /// <summary>
        /// between [0, 0] and [1, 1].
        /// </summary>
        public vec2 leftBottom;
        /// <summary>
        /// between [0, 0] and [1, 1].
        /// </summary>
        public vec2 rightBottom;
        /// <summary>
        /// between [0, 0] and [1, 1].
        /// </summary>
        public vec2 rightTop;

        /// <summary>
        /// A quad(u, v) renders in GL_QUADS mode.
        /// (u, v) is texture coordinate of this quad in the glyph map.
        /// </summary>
        /// <param name="leftTop">between [0, 0] and [1, 1].</param>
        /// <param name="leftBottom">between [0, 0] and [1, 1].</param>
        /// <param name="rightBottom">between [0, 0] and [1, 1].</param>
        /// <param name="rightTop">between [0, 0] and [1, 1].</param>
        public QuadPositionStruct(vec2 leftTop, vec2 leftBottom, vec2 rightBottom, vec2 rightTop)
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

    //
    // 0---------3
    // |         |
    // |         |
    // |         |
    // 1---------2
    //
    /// <summary>
    /// A quad renders in GL_QUADS mode.
    /// This stores the uv coordinate and layer index(s, t, r) of that quad.
    /// </summary>
    public struct QuadSTRStruct
    {
        /// <summary>
        /// 
        /// </summary>
        public vec3 leftTop;
        /// <summary>
        /// 
        /// </summary>
        public vec3 leftBottom;
        /// <summary>
        /// 
        /// </summary>
        public vec3 rightBottom;
        /// <summary>
        /// 
        /// </summary>
        public vec3 rightTop;

        /// <summary>
        /// A quad renders in GL_QUADS mode.
        /// This stores the uv coordinate and layer index of that quad.
        /// </summary>
        /// <param name="leftTop">between [0, 0] and [1, 1].</param>
        /// <param name="rightBottom">between [0, 0] and [1, 1].</param>
        /// <param name="index">0, 1, 2, ...</param>
        public QuadSTRStruct(vec2 leftTop, vec2 rightBottom, int index)
        {
            this.leftTop = new vec3(leftTop, index);
            this.rightTop = new vec3(rightBottom.x, leftTop.y, index);
            this.leftBottom = new vec3(leftTop.x, rightBottom.y, index);
            this.rightBottom = new vec3(rightBottom, index);
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
