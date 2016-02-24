using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpGL.Buffers;
using CSharpGL.Objects.Models;
using CSharpGL.Objects.VertexBuffers;


namespace CSharpGL.Objects.Demos
{
    public class NewNormalLineDemoModel : IConvert2BufferRenderer
    {
        TeapotModel model = TeapotLoader.GetModel();

        /// <summary>
        /// buffer name.
        /// </summary>
        public const string strPosition = "position";
        /// <summary>
        /// buffer name.
        /// </summary>
        public const string strColor = "color";
        /// <summary>
        /// buffer name.
        /// </summary>
        public const string strNormal = "normal";

        BufferRenderer IConvert2BufferRenderer.GetBufferRenderer(string bufferName, string varNameInShader)
        {
            IModel model = this.model;

            if (bufferName == strPosition)
            {
                return model.GetPositionBufferRenderer(varNameInShader);
            }
            else if (bufferName == strColor)
            {
                return model.GetColorBufferRenderer(varNameInShader);
            }
            else if (bufferName == strNormal)
            {
                return model.GetNormalBufferRenderer(varNameInShader);
            }
            else
            {
                return null;
            }
        }

        IndexBufferRendererBase IConvert2BufferRenderer.GetIndexBufferRenderer()
        {
            IModel model = this.model;
            return model.GetIndexes();
        }
    }
}
