using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class CubeModel : IBufferSource
    {
        public vec3 ModelSize { get; private set; }

        public CubeModel()
        {
            this.ModelSize = new vec3(xLength * 2, yLength * 2, zLength * 2);
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;

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
            else
            {
                throw new ArgumentException();
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand()
        {
            if (this.drawCmd == null)
            {
                this.drawCmd = new DrawArraysCmd(DrawMode.TriangleStrip, positions.Length);
            }

            yield return this.drawCmd;
        }

        #endregion

        private const float xLength = 0.5f;
        private const float yLength = 0.5f;
        private const float zLength = 0.5f;
        /// <summary>
        /// four vertexes.
        /// </summary>
        private static readonly vec3[] positions = new vec3[]
        {
            new vec3(+xLength, +yLength, +zLength),//  0
            new vec3(+xLength, -yLength, +zLength),//  1
            new vec3(+xLength, +yLength, -zLength),//  2
            new vec3(+xLength, -yLength, -zLength),//  3
            new vec3(-xLength, -yLength, -zLength),//  4
            new vec3(+xLength, -yLength, +zLength),//  5
            new vec3(-xLength, -yLength, +zLength),//  6
            new vec3(+xLength, +yLength, +zLength),//  7
            new vec3(-xLength, +yLength, +zLength),//  8
            new vec3(+xLength, +yLength, -zLength),//  9
            new vec3(-xLength, +yLength, -zLength),// 10
            new vec3(-xLength, -yLength, -zLength),// 11
            new vec3(-xLength, +yLength, +zLength),// 12
            new vec3(-xLength, -yLength, +zLength),// 13
        };
    }
}
