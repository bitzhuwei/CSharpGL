
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class HighlightRenderer
    {

        /// <summary>
        /// <see cref="this.oneIndexBufferPtr"/>实际存在多少个元素。
        /// </summary>
        protected int maxElementCount = 0;

        protected override void DoInitialize()
        {
            base.DoInitialize();

            // init index buffer 
            {
                //IndexBufferPtr indexBufferPtr = this.bufferable.GetIndex();

                using (var buffer = new OneIndexBuffer<uint>(
                    this.indexBufferPtr.Mode, BufferUsage.DynamicDraw))
                {
                    buffer.Alloc(this.positionBufferPtr.ByteLength / (this.positionBufferPtr.DataSize * this.positionBufferPtr.DataTypeByteLength));
                    this.indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                }
            }
            {
                var oneIndexBufferPtr = this.indexBufferPtr as OneIndexBufferPtr;
                this.maxElementCount = oneIndexBufferPtr.ElementCount;
                oneIndexBufferPtr.ElementCount = 0;// 高亮0个图元
            }

            this.bufferable = null;
            this.shaderCodes = null;
            this.propertyNameMap = null;
        }


    }


}
