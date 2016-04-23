using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class OneIndexModernRenderer : ModernRenderer
    {

        private int mapBufferRangeLength = 2 * 2 * 2 * 2 * 3 * 3 * 3 * 3 * 10;

        public int MapBufferRangeLength
        {
            get { return mapBufferRangeLength; }
            set
            {
                if (value < sizeof(uint) * 4)
                {
                    mapBufferRangeLength = sizeof(uint) * 4;
                }
                else
                {
                    mapBufferRangeLength = value;
                }
            }
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
    }
}
