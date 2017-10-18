using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    // This shows the indexes of vertexes that construct the button:
    // 0---------1
    // |         |
    // 2---------3
    // |         |
    // 4---------5
    //
    /// <summary>
    /// Renders a button(<see cref="GLControl"/>).
    /// </summary>
    public class CtrlButtonModel : IBufferSource
    {
        private static readonly vec2[] sixPositions = new vec2[] 
        { 
            new vec2(-1,  1), new vec2(1,  1), 
            new vec2(-1,  0), new vec2(1,  0), 
            new vec2(-1, -1), new vec2(1, -1),
        };

        private const float scaleFactor = 0.95f;
        private static readonly vec2[] positions = new vec2[] 
        {
            // button pressed up.
            sixPositions[0], sixPositions[1],
            sixPositions[2], sixPositions[3],
            sixPositions[4], sixPositions[5],

            // button pressed down.
            sixPositions[0] * scaleFactor, sixPositions[1] * scaleFactor,
            sixPositions[2] * scaleFactor, sixPositions[3] * scaleFactor,
            sixPositions[4] * scaleFactor, sixPositions[5] * scaleFactor,
        };

        private static readonly vec3 white = new vec3(1, 1, 1);
        private static readonly float top = 0.95f;
        private static readonly float middle = 1.0f;
        private static readonly float bottom = 0.7f;
        private static readonly vec3[] sixColors = new vec3[] { top * white, top * white, middle * white, middle * white, bottom * white, bottom * white };

        private static readonly vec3[] colors = new vec3[]
        {
            // button up.
            sixColors[0], sixColors[1],
            sixColors[2], sixColors[3],
            sixColors[4], sixColors[5],

            // button down.
            sixColors[0], sixColors[1],
            sixColors[2], sixColors[3],
            sixColors[4], sixColors[5],
        };

        /// <summary>
        /// 
        /// </summary>
        public const string position = "position";
        private VertexBuffer posiitonBuffer;
        /// <summary>
        /// 
        /// </summary>
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
                    this.posiitonBuffer = positions.GenVertexBuffer(VBOConfig.Vec2, BufferUsage.StaticDraw);
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
                this.indexBuffer = ZeroIndexBuffer.Create(DrawMode.QuadStrip, 0, positions.Length, primCount, frameCount);
            }

            return this.indexBuffer;
        }

        #endregion
    }
}
