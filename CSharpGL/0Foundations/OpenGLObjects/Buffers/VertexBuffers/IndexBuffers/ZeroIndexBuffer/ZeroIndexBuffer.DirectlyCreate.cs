namespace CSharpGL
{
    public sealed partial class ZeroIndexBuffer
    {
        /// <summary>
        /// Creates a <see cref="ZeroIndexBuffer"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="firstVertex"></param>
        /// <param name="vertexCount"></param>
        /// <param name="primCount"></param>
        /// <returns></returns>
        public static ZeroIndexBuffer Create(DrawMode mode, int firstVertex, int vertexCount, int primCount = 1)
        {
            ZeroIndexBuffer bufferPtr = new ZeroIndexBuffer(
             mode, firstVertex, vertexCount, primCount);

            return bufferPtr;
        }
    }
}