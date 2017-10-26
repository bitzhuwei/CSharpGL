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
        private VertexBuffer posiitonBuffer;
        /// <summary>
        /// 
        /// </summary>
        public const string uv = "color";
        private VertexBuffer colorBuffer;

        private IndexBuffer indexBuffer;

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
                if (this.posiitonBuffer == null)
                {
                    this.posiitonBuffer = VertexBuffer.Create(typeof(vec2), this.Capacity, VBOConfig.Vec2, BufferUsage.DynamicDraw);
                }

                return this.posiitonBuffer;
            }
            else if (bufferName == uv)
            {
                if (this.colorBuffer == null)
                {
                    this.colorBuffer = VertexBuffer.Create(typeof(vec2), this.Capacity, VBOConfig.Vec2, BufferUsage.DynamicDraw);
                }

                return this.colorBuffer;
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
                int frameCount = 2;
                var indexBuffer = ZeroIndexBuffer.Create(DrawMode.Quads, 0, this.Capacity, primCount, frameCount);
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
