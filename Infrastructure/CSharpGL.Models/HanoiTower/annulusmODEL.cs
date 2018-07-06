using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{

    public class AnnulusModel : IBufferSource, IObjFormat
    {
        private vec3 modelSize;
        public vec3 ModelSize()
        {
            return this.modelSize;
        }

        public AnnulusModel(float radius, float thickness, uint sliceCount, uint secondSliceCount)
        {
            {
                var positions = new vec3[sliceCount * secondSliceCount];
                int t = 0;
                var y = new vec3(0, 1, 0);
                for (int i = 0; i < sliceCount; i++)
                {
                    double di = Math.PI * i / sliceCount / 180.0;
                    var center = new vec3((float)Math.Sin(di), 0, (float)Math.Cos(di));
                    float length = center.length();
                    for (int j = 0; j < secondSliceCount; j++)
                    {
                        double dj = Math.PI * j / secondSliceCount / 180.0;
                        positions[t++] = center * (length - thickness * (float)Math.Cos(dj))
                            + y * (thickness * (float)Math.Sin(dj));
                    }
                }
                BoundingBox box = positions.Move2Center();
                this.positions = positions;
                this.modelSize = box.MaxPosition - box.MinPosition;
            }
            {
                var indexes = new uint[sliceCount * (secondSliceCount * 3 + secondSliceCount * 3)];
                uint t = 0;
                for (uint i = 0; i < sliceCount - 1; i++)
                {
                    for (uint j = 0; j < secondSliceCount; j++)
                    {
                        indexes[t++] = i * secondSliceCount + j;
                        indexes[t++] = i * secondSliceCount + (j + 1) % secondSliceCount;
                        indexes[t++] = i * secondSliceCount + secondSliceCount + (j + 1) % secondSliceCount;

                        indexes[t++] = i * secondSliceCount + j;
                        indexes[t++] = i * secondSliceCount + secondSliceCount + (j + 1) % secondSliceCount;
                        indexes[t++] = i * secondSliceCount + secondSliceCount + (j + 2) % secondSliceCount;
                    }
                }
                {
                    uint i = sliceCount - 1;
                    for (uint j = 0; j < secondSliceCount; j++)
                    {
                        indexes[t++] = i * secondSliceCount + j;
                        indexes[t++] = i * secondSliceCount + (j + 1) % secondSliceCount;
                        indexes[t++] = (j + 1) % secondSliceCount;

                        indexes[t++] = i * secondSliceCount + j;
                        indexes[t++] = (j + 1) % secondSliceCount;
                        indexes[t++] = (j + 2) % secondSliceCount;
                    }
                }
                this.indexes = indexes;
            }
        }

        private readonly vec3[] positions;
        private readonly uint[] indexes;

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;

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
            else
            {
                throw new ArgumentException("bufferName");
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand()
        {
            if (this.drawCommand == null)
            {
                IndexBuffer indexBuffer = indexes.GenIndexBuffer(BufferUsage.StaticDraw);
                this.drawCommand = new DrawElementsCmd(indexBuffer, DrawMode.Triangles);
            }

            yield return this.drawCommand;
        }

        #endregion

        #region IObjFormat 成员

        public vec3[] GetPositions()
        {
            return this.positions;
        }

        public uint[] GetIndexes()
        {
            return this.indexes;
        }

        #endregion
    }
}
