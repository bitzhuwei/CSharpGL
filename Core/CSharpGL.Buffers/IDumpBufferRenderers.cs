using CSharpGL.Objects.VertexBuffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Buffers
{
    /// <summary>
    /// Data for CPU(model) -&gt; pointer to Data for GPU(buffer renderer)
    /// <para>从模型的数据格式转换为<see cref="VertexBuffer&lt;T&gt;"/>，<see cref="VertexBuffer&lt;T&gt;"/>转换为<see cref="BufferRenderer"/>，
    /// <see cref="BufferRenderer"/>则可用于控制GPU的渲染操作。</para>
    /// </summary>
    public interface IDumpBufferRenderers
    {

        /// <summary>
        /// 获取顶点某种属性的<see cref="BufferRenderer"/>。
        /// </summary>
        /// <param name="bufferName">CPU代码指定的buffer名字，用以区分各个用途的buffer。</param>
        /// <param name="varNameInShader">此buffer在shader中对应的in变量名。</param>
        /// <returns></returns>
        BufferRenderer GetBufferRenderer(string bufferName, string varNameInShader);

        /// <summary>
        /// 获取描述索引的<see cref="BufferRenderer"/>。
        /// 应为<see cref="ZeroIndexBufferRenderer"/>或<see cref="IndexBufferRenderer"/>。
        /// </summary>
        /// <returns></returns>
        BufferRenderer GetIndexBufferRenderer();
    }
}
