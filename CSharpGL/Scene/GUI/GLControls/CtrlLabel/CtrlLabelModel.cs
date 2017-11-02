using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Renders a Label(string).
    /// </summary>
    public class CtrlLabelModel : IBufferSource
    {
        /// <summary>
        /// 
        /// </summary>
        public const string position = "position";
        private VertexBuffer positionBuffer;
        /// <summary>
        /// 
        /// </summary>
        public const string uv = "color";
        private VertexBuffer colorBuffer;
        /// <summary>
        /// 
        /// </summary>
        public const string textureIndex = "textureIndex";
        private VertexBuffer textureIndexBuffer;

        private IndexBuffer indexBuffer;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="capacity"></param>
        public CtrlLabelModel(int capacity)
        {
            this.Capacity = capacity;
        }

        #region IBufferSource 成员

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bufferName"></param>
        /// <returns></returns>
        public VertexBuffer GetVertexAttributeBuffer(string bufferName)
        {
            if (bufferName == position)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = VertexBuffer.Create(typeof(QuadStruct), this.Capacity, VBOConfig.Vec2, BufferUsage.DynamicDraw);
                }

                return this.positionBuffer;
            }
            else if (bufferName == uv)
            {
                if (this.colorBuffer == null)
                {
                    this.colorBuffer = VertexBuffer.Create(typeof(QuadStruct), this.Capacity, VBOConfig.Vec2, BufferUsage.DynamicDraw);
                }

                return this.colorBuffer;
            }
            else if (bufferName == textureIndex)
            {
                if (this.textureIndexBuffer == null)
                {
                    this.textureIndexBuffer = VertexBuffer.Create(typeof(QuadIndexStruct), this.Capacity, VBOConfig.Float, BufferUsage.DynamicDraw);
                }

                return this.textureIndexBuffer;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IndexBuffer GetIndexBuffer()
        {
            if (this.indexBuffer == null)
            {
                int primCount = 1;
                int frameCount = 1;
                var indexBuffer = ZeroIndexBuffer.Create(DrawMode.Quads, 0, this.Capacity * 4, primCount, frameCount);
                // note: use ZeroIndexBuffer.Draw(ControlMode.Random) to enable this property.
                indexBuffer.RenderingVertexCount = 0;
                this.indexBuffer = indexBuffer;
            }

            return this.indexBuffer;
        }

        #endregion

        /// <summary>
        /// Maximum number of characters.
        /// </summary>
        public int Capacity { get; private set; }
    }
}
