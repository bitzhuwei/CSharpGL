
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    public partial class HighlightRenderer
    {

        /// <summary>
        /// <see cref="OneIndexBufferPtr"/>实际存在多少个元素。
        /// </summary>
        protected int maxElementCount = 0;
        /// <summary>
        /// 
        /// </summary>
        protected override void DoInitialize()
        {
            base.DoInitialize();

            foreach (var item in propertyNameMap)
            {
                PropertyBufferPtr bufferPtr = this.bufferable.GetProperty(
                    item.nameInIBufferable, item.VarNameInShader);
                if (bufferPtr == null) { throw new Exception(); }

                if (item.nameInIBufferable == positionNameInIBufferable)
                {
                    this.positionBufferPtr = new PropertyBufferPtr(
                        "in_Position",// in_Postion same with in the PickingShader.vert shader
                        bufferPtr.BufferId,
                        bufferPtr.DataSize,
                        bufferPtr.DataType,
                        bufferPtr.Length,
                        bufferPtr.ByteLength);
                    break;
                }
            }

            // init index buffer 
            {
                //IndexBufferPtr indexBufferPtr = this.bufferable.GetIndex();

                using (var buffer = new OneIndexBuffer<uint>(
                    this.indexBufferPtr.Mode, BufferUsage.DynamicDraw))
                {
                    buffer.Create(this.positionBufferPtr.ByteLength / (this.positionBufferPtr.DataSize * this.positionBufferPtr.DataTypeByteLength));
                    this.indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                }
            }
            {
                var oneIndexBufferPtr = this.indexBufferPtr as OneIndexBufferPtr;
                this.maxElementCount = oneIndexBufferPtr.ElementCount;
                oneIndexBufferPtr.ElementCount = 0;// 高亮0个图元
            }
            
            //this.bufferable = null;
            //this.shaderCodes = null;
            //this.propertyNameMap = null;
        }


    }


}
