using CSharpGL.Objects.VertexBuffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.ModernRendering
{
    /// <summary>
    /// Data for CPU(model) -&gt; pointer to Data for GPU(buffer renderer)
    /// <para>从模型的数据格式转换为<see cref="VertexBuffer&lt;T&gt;"/>，<see cref="VertexBuffer&lt;T&gt;"/>转换为<see cref="BufferPointer"/>，
    /// <see cref="BufferPointer"/>则可用于控制GPU的渲染操作。</para>
    /// </summary>
    public interface IConvert2BufferPointer
    {

        /// <summary>
        /// 获取顶点某种属性的<see cref="BufferPointer"/>。
        /// </summary>
        /// <param name="bufferName">CPU代码指定的buffer名字，用以区分各个用途的buffer。</param>
        /// <param name="varNameInShader">此buffer在shader中对应的in变量名。</param>
        /// <returns></returns>
        BufferPointer GetBufferRenderer(string bufferName, string varNameInShader);

        /// <summary>
        /// 获取描述索引的<see cref="BufferPointer"/>。
        /// 应为<see cref="ZeroIndexBufferPointer"/>或<see cref="IndexBufferPointer"/>。
        /// </summary>
        /// <returns></returns>
        IndexBufferPointerBase GetIndexBufferRenderer();
    }
}
