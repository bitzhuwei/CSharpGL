using CSharpGL.Objects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Texts
{
    /// <summary>
    /// 用于渲染一段文字
    /// </summary>
    public class StringModel : IModel
    {
        public Objects.VertexBuffers.BufferRenderer GetPositionBufferRenderer(string varNameInShader)
        {
            throw new NotImplementedException();
        }

        public Objects.VertexBuffers.BufferRenderer GetColorBufferRenderer(string varNameInShader)
        {
            throw new NotImplementedException();
        }

        public Objects.VertexBuffers.BufferRenderer GetNormalBufferRenderer(string varNameInShader)
        {
            throw new NotImplementedException();
        }

        public Objects.VertexBuffers.BufferRenderer GetIndexes()
        {
            throw new NotImplementedException();
        }
    }
}
