using System.Collections.Generic;
namespace CSharpGL
{
    /// <summary>
    /// Provides <see cref="VertexBuffer"/>s and <see cref="IDrawCommand"/>s for GPU memory from data in CPU memory.
    /// </summary>
    public interface IBufferSource
    {
        /// <summary>
        /// Gets buffers that contains the vertex attribute specified with <paramref name="bufferName"/>.
        /// <para>The vertex buffer is sliced into blocks of same size(except the last one when the remainder is not 0.) I recommend 1024*1024*4(bytes) as block size, which is the block size in OVITO.</para>
        /// </summary>
        /// <param name="bufferName">user defined buffer name used to specify vertex attribute.</param>
        /// <returns></returns>
        IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName);

        /// <summary>
        /// Gets the <see cref="IDrawCommand"/> used to draw with vertex attribute buffers.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IDrawCommand> GetDrawCommand();

    }
}