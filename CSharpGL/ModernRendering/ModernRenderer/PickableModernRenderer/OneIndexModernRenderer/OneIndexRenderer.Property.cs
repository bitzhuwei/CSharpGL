using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class OneIndexRenderer : PickableRenderer
    {

        private int mapBufferRangeLength = 2 * 2 * 2 * 2 * 3 * 3 * 3 * 3 * 10;

        /// <summary>
        /// 如果VBO太长，就应该据此分段执行各种MapBufferRange操作。
        /// </summary>
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
                var indexBufferPtr = this.indexBufferPtr as OneIndexBufferPtr;
                if (indexBufferPtr == null)
                { return 0; }
                else
                { return indexBufferPtr.ElementCount; }
            }
            set
            {
                var indexBufferPtr = this.indexBufferPtr as OneIndexBufferPtr;
                if (indexBufferPtr != null)
                {
                    indexBufferPtr.ElementCount = value;
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
                var indexBufferPtr = this.indexBufferPtr as OneIndexBufferPtr;
                if (indexBufferPtr == null)
                { return IndexElementType.UnsignedInt; }
                else
                { return indexBufferPtr.Type; }
            }
        }
    }
}
