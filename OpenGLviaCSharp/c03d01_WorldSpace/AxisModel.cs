using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c03d01_WorldSpace
{
    /// <summary>
    ///     Y
    ///     |
    ///     |
    ///     |
    ///     |_________ X
    ///    /
    ///   /
    ///  /
    /// Z
    /// </summary>
    class AxisModel : IBufferSource
    {
        private const float halfLength = 0.5f;
        private static readonly vec3[] positions = new vec3[]
        {
            new vec3(0, 0, 0), // 0
            new vec3(+halfLength, 0, 0), // 1
            new vec3(0, 0, 0), // 2
            new vec3(0, +halfLength, 0), // 3
            new vec3(0, 0, 0), // 4
            new vec3(0, 0, +halfLength), // 5
        };

        private static readonly vec3[] colors = new vec3[]
        {
            new vec3(1, 0, 0), // 0
            new vec3(1, 0, 0), // 1
            new vec3(0, 1, 0), // 2
            new vec3(0, 1, 0), // 3
            new vec3(0, 0, 1), // 4
            new vec3(0, 0, 1), // 5
        };

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;

        public const string strColor = "color";
        private VertexBuffer colorBuffer;

        private IDrawCommand drawCommand;


        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName)
        {
            if (strPosition == bufferName) // requiring position buffer.
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else if (strColor == bufferName)
            {
                if (this.colorBuffer == null)
                {
                    this.colorBuffer = colors.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.colorBuffer;
            }
            else
            {
                throw new ArgumentException("bufferName");
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand()
        {
            if (this.drawCommand == null)
            {
                this.drawCommand = new DrawArraysCmd(DrawMode.Lines, 0, positions.Length);
            }

            yield return this.drawCommand;
        }

        #endregion
    }
}
