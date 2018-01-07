using System.Collections.Generic;
namespace CSharpGL
{
    /// <summary>
    /// Data for CPU(model) -&gt; Data for GPU(opengl buffer)
    /// <para>从模型的数据格式转换为<see cref="GLBuffer"/></para>，
    /// <see cref="GLBuffer"/>则可用于控制GPU的渲染操作。
    /// </summary>
    public interface IBufferSource
    {
        /// <summary>
        /// Gets vertex buffer of some vertex attribute specified with <paramref name="bufferName"/>.
        /// <para>The vertex buffer is sliced into blocks of same size(except the last one when the remainder is not 0.) I recommend 1024*1024*4 as block size, which is the block size in OVITO.</para>
        /// </summary>
        /// <param name="bufferName">CPU代码指定的buffer名字，用以区分各个用途的buffer。</param>
        /// <returns></returns>
        IEnumerable<VertexBuffer> GetVertexAttributeBuffer(string bufferName);

        /// <summary>
        /// </summary>
        /// <returns></returns>
        IEnumerable<IDrawCommand> GetDrawCommand();

    }
}