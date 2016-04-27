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
        public void ClearHighlightIndexes()
        {
            this.oneIndexBufferPtr.ElementCount = 0;
        }

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
