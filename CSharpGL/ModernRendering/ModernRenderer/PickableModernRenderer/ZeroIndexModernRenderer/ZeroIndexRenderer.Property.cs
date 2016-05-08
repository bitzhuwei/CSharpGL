using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class ZeroIndexRenderer : PickableRenderer
    {

        /// <summary>
        /// 要渲染的第一个顶点的索引。
        /// </summary>
        public int FirstVertex
        {
            get
            {
                var indexBufferPtr = this.indexBufferPtr as ZeroIndexBufferPtr;
                if (indexBufferPtr == null)
                { return 0; }
                else
                { return indexBufferPtr.FirstVertex; }
            }
            set
            {
                var indexBufferPtr = this.indexBufferPtr as ZeroIndexBufferPtr;
                if (indexBufferPtr != null)
                {
                    indexBufferPtr.FirstVertex = value;
                }
            }
        }

        /// <summary>
        /// 要渲染多少个顶点。
        /// </summary>
        public int VertexCount
        {
            get
            {
                var indexBufferPtr = this.indexBufferPtr as ZeroIndexBufferPtr;
                if (indexBufferPtr == null)
                { return 0; }
                else
                { return indexBufferPtr.VertexCount; }
            }
            set
            {
                var indexBufferPtr = this.indexBufferPtr as ZeroIndexBufferPtr;
                if (indexBufferPtr != null)
                {
                    indexBufferPtr.VertexCount = value;
                }
            }
        }
    }
}
