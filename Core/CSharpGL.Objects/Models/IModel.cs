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
    /// 从模型的数据格式转换为<see cref="VertexBuffer&lt;T&gt;"/>，<see cref="VertexBuffer&lt;T&gt;"/>，转换为<see cref="BufferPointer"/>
    /// <see cref="BufferPointer"/>则可用于控制GPU的渲染操作。
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// 获取描述顶点位置的<see cref="BufferPointer"/>。
        /// </summary>
        /// <param name="varNameInShader">此buffer在shader中对应的in变量名。</param>
        /// <returns></returns>
        BufferPointer GetPositionBufferRenderer(string varNameInShader);

        /// <summary>
        /// 获取描述顶点位置的<see cref="BufferPointer"/>。
        /// </summary>
        /// <param name="varNameInShader">此buffer在shader中对应的in变量名。</param>
        /// <returns></returns>
        BufferPointer GetColorBufferRenderer(string varNameInShader);

        /// <summary>
        /// 获取描述顶点位置的<see cref="BufferPointer"/>。
        /// </summary>
        /// <param name="varNameInShader">此buffer在shader中对应的in变量名。</param>
        /// <returns></returns>
        BufferPointer GetNormalBufferRenderer(string varNameInShader);

        /// <summary>
        /// 获取描述索引的<see cref="BufferPointer"/>。
        /// 应为<see cref="ZeroIndexBufferPointer"/>或<see cref="IndexBufferPointer"/>。
        /// </summary>
        /// <returns></returns>
        IndexBufferPointerBase GetIndexes();
    }
}
