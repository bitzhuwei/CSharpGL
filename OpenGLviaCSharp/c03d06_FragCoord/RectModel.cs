using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c03d06_FragCoord
{
    class RectModel : IBufferSource
    {
        private static readonly vec2[] positions = new vec2[] { new vec2(1, 1), new vec2(-1, 1), new vec2(-1, -1), new vec2(1, -1), };
        private static readonly vec3[] colors = new vec3[] { new vec3(1, 0, 0), new vec3(0, 1, 0), new vec3(0, 0, 1), new vec3(1, 1, 1), };

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        public const string strColor = "color";
        private VertexBuffer colorBuffer;

        private IDrawCommand drawCommand;

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName)
        {
            if (strPosition == bufferName)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec2, BufferUsage.StaticDraw);
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
                throw new ArgumentException();
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand()
        {
            if (this.drawCommand == null)
            {
                this.drawCommand = new DrawArraysCmd(DrawMode.Quads, positions.Length);
            }

            yield return this.drawCommand;
        }

        #endregion
    }
}
