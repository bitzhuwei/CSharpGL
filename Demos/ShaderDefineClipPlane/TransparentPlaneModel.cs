using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShaderDefineClipPlane
{
    class TransparentPlaneModel : IBufferSource
    {
        public vec3 ModelSize { get; private set; }

        public TransparentPlaneModel()
        {
            this.ModelSize = new vec3(xLength * 2, yLength * 2, zLength * 2);
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        public const string strColor = "Color";
        private VertexBuffer colorBuffer;

        private IDrawCommand drawCmd;

        #region IBufferable 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else if (bufferName == strColor)
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
            if (this.drawCmd == null)
            {
                this.drawCmd = new DrawArraysCmd(DrawMode.Triangles, positions.Length);
            }

            yield return this.drawCmd;
        }

        #endregion

        private const float xLength = 1.5f;
        private const float yLength = 1.5f;
        private const float zLength = 1.5f;
        /// <summary>
        /// four vertexes.
        /// </summary>
        private static readonly vec3[] positions = new vec3[]
        {
            new vec3(+xLength, 0, -zLength),
            new vec3(0, -yLength, +zLength),
            new vec3(-xLength, +yLength, 0),
        };

        private static readonly vec3[] colors = new vec3[]
        {
            new vec3(1, 1, 1),
            new vec3(1, 1, 1),
            new vec3(1, 1, 1),
        };
    }
}
