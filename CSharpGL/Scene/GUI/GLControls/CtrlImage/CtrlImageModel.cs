using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Renders a <see cref="GLControl"/>.
    /// </summary>
    public class CtrlImageModel : IBufferSource
    {
        private static readonly vec2[] positions = new vec2[] { new vec2(1, 1), new vec2(-1, 1), new vec2(-1, -1), new vec2(1, -1), };
        private static readonly vec2[] uvs = new vec2[] { new vec2(1, 1), new vec2(0, 1), new vec2(0, 0), new vec2(1, 0), };

        /// <summary>
        /// 
        /// </summary>
        public const string position = "position";
        private VertexBuffer posiitonBuffer;

        /// <summary>
        /// 
        /// </summary>
        public const string uv = "uv";
        private VertexBuffer uvBuffer;

        private IndexBuffer indexBuffer;

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
                    this.posiitonBuffer = positions.GenVertexBuffer(VBOConfig.Vec2, BufferUsage.StaticDraw);
                }

                return this.posiitonBuffer;
            }
            else if (bufferName == uv)
            {
                if (this.uvBuffer == null)
                {
                    this.uvBuffer = uvs.GenVertexBuffer(VBOConfig.Vec2, BufferUsage.StaticDraw);
                }

                return this.uvBuffer;
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
                this.indexBuffer = ZeroIndexBuffer.Create(DrawMode.Quads, 0, positions.Length);
            }

            return this.indexBuffer;
        }

        #endregion
    }
}
