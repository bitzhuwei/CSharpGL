using CSharpGL.Objects.VertexBuffers;
using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.Models
{
    /// <summary>
    /// 从模型的数据格式转换为<see cref="VertexBuffer&lt;T&gt;"/>，<see cref="VertexBuffer&lt;T&gt;"/>，转换为<see cref="BufferRenderer"/>
    /// <see cref="BufferRenderer"/>则可用于控制GPU的渲染操作。
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// 获取描述顶点位置的<see cref="BufferRenderer"/>。
        /// </summary>
        /// <param name="varNameInShader">此buffer在shader中对应的in变量名。</param>
        /// <returns></returns>
        BufferRenderer GetPositionBufferRenderer(string varNameInShader);

        /// <summary>
        /// 获取描述顶点位置的<see cref="BufferRenderer"/>。
        /// </summary>
        /// <param name="varNameInShader">此buffer在shader中对应的in变量名。</param>
        /// <returns></returns>
        BufferRenderer GetColorBufferRenderer(string varNameInShader);

        /// <summary>
        /// 获取描述顶点位置的<see cref="BufferRenderer"/>。
        /// </summary>
        /// <param name="varNameInShader">此buffer在shader中对应的in变量名。</param>
        /// <returns></returns>
        BufferRenderer GetNormalBufferRenderer(string varNameInShader);

        /// <summary>
        /// 获取描述索引的<see cref="BufferRenderer"/>。
        /// 应为<see cref="ZeroIndexBufferRenderer"/>或<see cref="IndexBufferRenderer"/>。
        /// </summary>
        /// <returns></returns>
        IndexBufferRendererBase GetIndexes();
    }
}
