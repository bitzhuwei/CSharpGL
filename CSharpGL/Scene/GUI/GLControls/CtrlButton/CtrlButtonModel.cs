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
        private const float topFactor = 0.65f;
        private static readonly vec3[] eightPositions = new vec3[] { new vec3(1, 1, 1) * topFactor, new vec3(-1, 1, 1) * topFactor, new vec3(-1, -1, 1) * topFactor, new vec3(1, -1, 1) * topFactor, new vec3(1, 1, -1), new vec3(-1, 1, -1), new vec3(-1, -1, -1), new vec3(1, -1, -1) };

        private const float scaleFactor = 0.8f;
        private static readonly vec3[] positions = new vec3[] 
        {
            eightPositions[0], eightPositions[1], eightPositions[2], eightPositions[3],
            eightPositions[4], eightPositions[7], eightPositions[6], eightPositions[5],
            eightPositions[3], eightPositions[7], eightPositions[4], eightPositions[0],
            eightPositions[0], eightPositions[4], eightPositions[5], eightPositions[1],
            eightPositions[1], eightPositions[5], eightPositions[6], eightPositions[2],
            eightPositions[2], eightPositions[6], eightPositions[7], eightPositions[3],

            eightPositions[0] * scaleFactor, eightPositions[1] * scaleFactor, eightPositions[2] * scaleFactor, eightPositions[3] * scaleFactor,
            eightPositions[4] * scaleFactor, eightPositions[7] * scaleFactor, eightPositions[6] * scaleFactor, eightPositions[5] * scaleFactor,
            eightPositions[3] * scaleFactor, eightPositions[7] * scaleFactor, eightPositions[4] * scaleFactor, eightPositions[0] * scaleFactor,
            eightPositions[0] * scaleFactor, eightPositions[4] * scaleFactor, eightPositions[5] * scaleFactor, eightPositions[1] * scaleFactor,
            eightPositions[1] * scaleFactor, eightPositions[5] * scaleFactor, eightPositions[6] * scaleFactor, eightPositions[2] * scaleFactor,
            eightPositions[2] * scaleFactor, eightPositions[6] * scaleFactor, eightPositions[7] * scaleFactor, eightPositions[3] * scaleFactor,
        };

        private const float colorFactor = 0.5f;
        private static readonly vec3[] eightColors = new vec3[] { new vec3(1, 1, 1), new vec3(1, 0, 0), new vec3(0, 1, 0), new vec3(0, 0, 1), new vec3(1, 1, 1) * colorFactor, new vec3(1, 0, 0) * colorFactor, new vec3(0, 1, 0) * colorFactor, new vec3(0, 0, 1) * colorFactor };

        private static readonly vec3[] colors = new vec3[]
        {
            eightColors[0], eightColors[1], eightColors[2], eightColors[3],
            eightColors[4], eightColors[7], eightColors[6], eightColors[5],
            eightColors[3], eightColors[7], eightColors[4], eightColors[0],
            eightColors[0], eightColors[4], eightColors[5], eightColors[1],
            eightColors[1], eightColors[5], eightColors[6], eightColors[2],
            eightColors[2], eightColors[6], eightColors[7], eightColors[3],

            eightColors[0], eightColors[1], eightColors[2], eightColors[3],
            eightColors[4], eightColors[7], eightColors[6], eightColors[5],
            eightColors[3], eightColors[7], eightColors[4], eightColors[0],
            eightColors[0], eightColors[4], eightColors[5], eightColors[1],
            eightColors[1], eightColors[5], eightColors[6], eightColors[2],
            eightColors[2], eightColors[6], eightColors[7], eightColors[3],

      
        };

        /// <summary>
        /// 
        /// </summary>
        public const string position = "position";
        private VertexBuffer posiitonBuffer;
        public const string color = "color";
        private VertexBuffer colorBuffer;

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
            else if (bufferName == color)
            {
                if (this.colorBuffer == null)
                {
                    this.colorBuffer = colors.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
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
                this.indexBuffer = ZeroIndexBuffer.Create(DrawMode.Quads, 0, positions.Length, primCount, frameCount);
            }

            return this.indexBuffer;
        }

        #endregion
    }
}
