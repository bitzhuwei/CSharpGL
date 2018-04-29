using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c08d00_gl_VertexID
{
    class PointsModel : IBufferSource
    {
        private vec3[] positions;
        private vec3[] colors;

        private vec3 size;
        public vec3 GetSize()
        {
            return this.size;
        }

        public PointsModel(int width, int height, int depth)
        {
            if (width < 1 || height < 1 || depth < 1) { throw new ArgumentOutOfRangeException(); }

            {
                var positions = new vec3[width * height * depth];
                int index = 0;
                for (int w = 0; w < width; w++)
                {
                    for (int h = 0; h < height; h++)
                    {
                        for (int d = 0; d < depth; d++)
                        {
                            positions[index++] = new vec3(w, h, d);
                        }
                    }
                }
                BoundingBox box = positions.Move2Center();
                this.size = box.MaxPosition - box.MinPosition;
                this.positions = positions;
            }
            {
                var random = new Random();
                var colors = new vec3[width * height * depth];
                for (int i = 0; i < colors.Length; i++)
                {
                    colors[i] = new vec3((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());
                }
                this.colors = colors;
            }
        }
        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        public const string strColor = "color";
        private VertexBuffer colorBuffer;

        private IDrawCommand drawCmd;

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName)
        {
            if (strPosition == bufferName)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = this.positions.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else if (strColor == bufferName)
            {
                if (this.colorBuffer == null)
                {
                    this.colorBuffer = this.colors.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
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
                this.drawCmd = new DrawArraysCmd(DrawMode.Points, 0, this.positions.Length);
            }

            yield return this.drawCmd;
        }

        #endregion

    }
}
