using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class HighlightModernRenderer
    {
        /// <summary>
        /// 清空高亮显示。
        /// </summary>
        public void ClearHighlightIndexes()
        {
            this.oneIndexBufferPtr.ElementCount = 0;
        }

        /// <summary>
        /// 增加要高亮显示的图元。
        /// </summary>
        /// <param name="mode">要高亮显示的图元类型</param>
        /// <param name="indexes">要高亮显示的图元的索引。</param>
        public void AddHighlightIndexes(DrawMode mode, params uint[] indexes)
        {
            int indexesLength = indexes.Length;
            if (indexesLength + this.oneIndexBufferPtr.ElementCount > this.maxElementCount)
            {
                using (var buffer = new OneIndexBuffer<uint>(
                 this.oneIndexBufferPtr.Mode, BufferUsage.DynamicDraw))
                {
                    buffer.Alloc(indexesLength + this.oneIndexBufferPtr.ElementCount);
                    this.oneIndexBufferPtr = buffer.GetBufferPtr() as OneIndexBufferPtr;
                }
                this.maxElementCount = indexesLength + this.oneIndexBufferPtr.ElementCount;
            }

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, this.oneIndexBufferPtr.BufferId);
            IntPtr pointer = GL.MapBuffer(BufferTarget.ElementArrayBuffer, MapBufferAccess.WriteOnly);
            unsafe
            {
                var array = (uint*)pointer.ToPointer();
                for (int i = 0; i < indexesLength; i++)
                {
                    array[i + this.oneIndexBufferPtr.ElementCount] = indexes[i];
                }
            }
            GL.UnmapBuffer(BufferTarget.ElementArrayBuffer);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);

            this.oneIndexBufferPtr.Mode = mode;
            this.oneIndexBufferPtr.ElementCount += indexesLength;
        }

        /// <summary>
        /// 设置要高亮显示的图元。
        /// </summary>
        /// <param name="mode">要高亮显示的图元类型</param>
        /// <param name="indexes">要高亮显示的图元的索引。</param>
        public void SetHighlightIndexes(DrawMode mode, params uint[] indexes)
        {
            int indexesLength = indexes.Length;
            if (indexesLength > this.maxElementCount)
            {
                using (var buffer = new OneIndexBuffer<uint>(
                 this.oneIndexBufferPtr.Mode, BufferUsage.DynamicDraw))
                {
                    buffer.Alloc(indexesLength);
                    this.oneIndexBufferPtr = buffer.GetBufferPtr() as OneIndexBufferPtr;
                }
                this.maxElementCount = indexesLength;
            }

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, this.oneIndexBufferPtr.BufferId);
            IntPtr pointer = GL.MapBuffer(BufferTarget.ElementArrayBuffer, MapBufferAccess.WriteOnly);
            unsafe
            {
                var array = (uint*)pointer.ToPointer();
                for (int i = 0; i < indexesLength; i++)
                {
                    array[i] = indexes[i];
                }
            }
            GL.UnmapBuffer(BufferTarget.ElementArrayBuffer);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);

            this.oneIndexBufferPtr.Mode = mode;
            this.oneIndexBufferPtr.ElementCount = indexesLength;
        }

    }


}
