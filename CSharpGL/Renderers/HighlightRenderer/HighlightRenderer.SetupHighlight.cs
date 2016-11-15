using System;

namespace CSharpGL
{
    public partial class HighlightRenderer
    {
        /// <summary>
        /// 清空高亮显示。
        /// </summary>
        public void ClearHighlightIndexes()
        {
            var indexBuffer = this.indexBuffer as OneIndexBuffer;
            indexBuffer.ElementCount = 0;
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
                IndexBuffer original = this.indexBuffer;
                this.indexBuffer = Buffer.Create(IndexBufferElementType.UInt, indexesLength, mode, BufferUsage.StaticDraw);
                this.maxElementCount = indexesLength;
                original.Dispose();
            }

            var indexBuffer = this.indexBuffer as OneIndexBuffer;
            IntPtr pointer = indexBuffer.MapBuffer(MapBufferAccess.WriteOnly);
            unsafe
            {
                var array = (uint*)pointer.ToPointer();
                for (int i = 0; i < indexesLength; i++)
                {
                    array[i] = indexes[i];
                }
            }
            indexBuffer.UnmapBuffer();

            indexBuffer.Mode = mode;
            indexBuffer.ElementCount = indexesLength;
        }
    }
}