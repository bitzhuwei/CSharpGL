namespace CSharpGL
{
    public sealed partial class ZeroIndexBufferPtr
    {
        /// <summary>
        /// Creates a <see cref="ZeroIndexBufferPtr"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="firstVertex"></param>
        /// <param name="vertexCount"></param>
        /// <returns></returns>
        public static ZeroIndexBufferPtr Create(DrawMode mode, int firstVertex, int vertexCount)
        {
            ZeroIndexBufferPtr bufferPtr = new ZeroIndexBufferPtr(
             mode, firstVertex, vertexCount);

            return bufferPtr;
        }
    }
}