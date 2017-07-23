namespace CSharpGL
{
    /// <summary>
    /// Data for CPU(model) -&gt; Data for GPU(buffer renderer)
    /// <para>从模型的数据格式转换为<see cref="GLBuffer"/>，<see cref="GLBuffer"/>转换为<see cref="GLBuffer"/>，
    /// <see cref="GLBuffer"/>则可用于控制GPU的渲染操作。</para>
    /// </summary>
    public interface IBufferable
    {
        /// <summary>
        /// 获取顶点某种属性的<see cref="VertexBuffer"/>。
        /// </summary>
        /// <param name="bufferName">CPU代码指定的buffer名字，用以区分各个用途的buffer。</param>
        /// <returns></returns>
        VertexBuffer GetVertexAttributeBuffer(string bufferName);

        /// <summary>
        /// 获取描述索引的<see cref="GLBuffer"/>。
        /// 应为<see cref="ZeroIndexBuffer"/>或<see cref="OneIndexBuffer"/>。
        /// </summary>
        /// <returns></returns>
        IndexBuffer GetIndexBuffer();

    }
}