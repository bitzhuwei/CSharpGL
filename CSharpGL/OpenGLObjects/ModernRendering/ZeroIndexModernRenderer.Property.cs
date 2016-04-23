using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class ZeroIndexModernRenderer : ModernRenderer
    {

        /// <summary>
        /// 要渲染的第一个顶点的索引。
        /// </summary>
        public int FirstVertex
        {
            get
            {
                if (this.zeroIndexBufferPtr == null)
                { return 0; }
                else 
                { return this.zeroIndexBufferPtr.FirstVertex; }
            }
            set
            {
                if (this.zeroIndexBufferPtr != null)
                {
                    this.zeroIndexBufferPtr.FirstVertex = value;
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
                if (this.zeroIndexBufferPtr == null)
                { return 0; }
                else
                { return this.zeroIndexBufferPtr.VertexCount; }
            }
            set
            {
                if (this.zeroIndexBufferPtr != null)
                {
                    this.zeroIndexBufferPtr.VertexCount = value;
                }
            }
        }
    }
}
