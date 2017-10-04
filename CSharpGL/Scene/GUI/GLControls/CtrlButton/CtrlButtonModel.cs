using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Renders a <see cref="GLControl"/>.
    /// </summary>
    public class CtrlButtonModel : IBufferSource
    {
        private static readonly vec3[] eightPositions = new vec3[] { new vec3(1, 1, 1), new vec3(-1, 1, 1), new vec3(-1, -1, 1), new vec3(1, -1, 1), new vec3(1, 1, -1), new vec3(-1, 1, -1), new vec3(-1, -1, -1), new vec3(1, -1, -1) };

        private static readonly vec3[] positions = new vec3[] 
        {
            eightPositions[0], eightPositions[1], eightPositions[2], eightPositions[3],
            eightPositions[4], eightPositions[7], eightPositions[6], eightPositions[5],
            eightPositions[3], eightPositions[7], eightPositions[4], eightPositions[0],
            eightPositions[0], eightPositions[4], eightPositions[5], eightPositions[1],
            eightPositions[1], eightPositions[5], eightPositions[6], eightPositions[2],
            eightPositions[2], eightPositions[6], eightPositions[7], eightPositions[3],
        };

        /// <summary>
        /// 
        /// </summary>
        public const string position = "position";
        private VertexBuffer posiitonBuffer;

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
                    this.posiitonBuffer = positions.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                return this.posiitonBuffer;
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
