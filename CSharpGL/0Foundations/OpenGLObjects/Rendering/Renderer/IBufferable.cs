namespace CSharpGL
{
    /// <summary>
    /// Data for CPU(model) -&gt; pointer to Data for GPU(buffer renderer)
    /// <para>从模型的数据格式转换为<see cref="Buffer"/>，<see cref="Buffer"/>转换为<see cref="BufferPtr"/>，
    /// <see cref="BufferPtr"/>则可用于控制GPU的渲染操作。</para>
    /// </summary>
    public interface IBufferable
    {
        /// <summary>
        /// 获取顶点某种属性的<see cref="BufferPtr"/>。
        /// </summary>
        /// <param name="bufferName">CPU代码指定的buffer名字，用以区分各个用途的buffer。</param>
        /// <param name="varNameInShader">此buffer在shader中对应的in变量名。</param>
        /// <returns></returns>
        VertexAttributeBufferPtr GetProperty(string bufferName, string varNameInShader);

        /// <summary>
        /// 获取描述索引的<see cref="BufferPtr"/>。
        /// 应为<see cref="ZeroIndexBufferPtr"/>或<see cref="OneIndexBufferPtr"/>。
        /// </summary>
        /// <returns></returns>
        IndexBufferPtr GetIndex();

        /// <summary>
        /// UsesUses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        bool UsesZeroIndexBuffer();
    }
}