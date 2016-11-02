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
        /// <param name="primCount"></param>
        /// <returns></returns>
        public static ZeroIndexBufferPtr Create(DrawMode mode, int firstVertex, int vertexCount, int primCount = 1)
        {
            ZeroIndexBufferPtr bufferPtr = new ZeroIndexBufferPtr(
             mode, firstVertex, vertexCount, primCount);

            return bufferPtr;
        }
    }
}