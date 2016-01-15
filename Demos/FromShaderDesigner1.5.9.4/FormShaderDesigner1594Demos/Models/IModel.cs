using CSharpGL.Objects.VertexBuffers;
using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormShaderDesigner1594Demos.Models
{
    public interface IModel
    {
        BufferRenderer GetPositionBufferRenderer(string varNameInShader);
        BufferRenderer GetColorBufferRenderer(string varNameInShader);
        BufferRenderer GetNormalBufferRenderer(string varNameInShader);
        BufferRenderer GetIndexes();
    }
}
