using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 高亮显示某些图元
    /// </summary>
    public partial class HighlightModernRenderer
    {
        protected OneIndexBufferPtr oneIndexBufferPtr;

        protected override IndexBufferPtr indexBufferPtr
        {
            get { return this.oneIndexBufferPtr; }
        }

        /// <summary>
        /// 要渲染多少个索引。
        /// </summary>
        public int ElementCount
        {
            get
            {
                if (this.oneIndexBufferPtr == null)
                { return 0; }
                else
                { return this.oneIndexBufferPtr.ElementCount; }
            }
            set
            {
                if (this.oneIndexBufferPtr != null)
                {
                    this.oneIndexBufferPtr.ElementCount = value;
                }
            }
        }

        /// <summary>
        /// type in GL.DrawElements(uint mode, int count, uint type, IntPtr indices);
        /// 只能是OpenGL.UNSIGNED_BYTE, OpenGL.UNSIGNED_SHORT, or OpenGL.UNSIGNED_INT
        /// </summary>
        public IndexElementType Type
        {
            get
            {
                if (this.oneIndexBufferPtr == null)
                { return IndexElementType.UnsignedInt; }
                else
                { return this.oneIndexBufferPtr.Type; }
            }
        }

        protected UniformMat4 uniformMVP = new UniformMat4("MVP");

        public mat4 MVP
        {
            get { return this.uniformMVP.Value; }
            set
            {
                if (value != this.uniformMVP.Value)
                {
                    this.uniformMVP.Value = value;
                }
            }
        }

    }


}
