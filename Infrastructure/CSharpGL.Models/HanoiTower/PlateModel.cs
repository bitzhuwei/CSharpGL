using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{

    public class PlateModel : IBufferSource, IObjFormat
    {
        private vec3 modelSize;
        public vec3 ModelSize()
        {
            return this.modelSize;
        }

        public PlateModel(float radius, float holeRadius, float thickness, uint sliceCount, uint secondSliceCount)
        {
            uint upPlane, downPlane;
            uint[] upSphere = new uint[sliceCount];
            uint[] downSphere = new uint[sliceCount];
            {
                var positions = new vec3[sliceCount * secondSliceCount + sliceCount + sliceCount];
                uint t = 0;
                var y = new vec3(0, 1, 0);
                for (int i = 0; i < sliceCount; i++)
                {
                    upSphere[i] = t;
                    double di = 2 * Math.PI * i / sliceCount;
                    var center = new vec3(radius * (float)Math.Sin(di), 0, radius * (float)Math.Cos(di));
                    float length = center.length();
                    center = center.normalize();
                    for (int j = 0; j < secondSliceCount; j++)
                    {
                        double dj = Math.PI / 2 + Math.PI * j / (secondSliceCount - 1);
                        positions[t++] = center * (length - thickness * (float)Math.Cos(dj))
                            + y * (thickness * (float)Math.Sin(dj));
                    }
                    downSphere[i] = t - 1;
                }
                upPlane = t;
                for (int i = 0; i < sliceCount; i++)
                {
                    double di = 2 * Math.PI * i / sliceCount;
                    positions[t++] = new vec3(holeRadius * (float)Math.Sin(di), thickness, holeRadius * (float)Math.Cos(di));
                }
                downPlane = t;
                for (int i = 0; i < sliceCount; i++)
                {
                    double di = 2 * Math.PI * i / sliceCount;
                    positions[t++] = new vec3(holeRadius * (float)Math.Sin(di), -thickness, holeRadius * (float)Math.Cos(di));
                }
                BoundingBox box = positions.Move2Center();
                this.positions = positions;
                this.modelSize = box.MaxPosition - box.MinPosition;
            }
            {
                var indexes = new uint[sliceCount * (secondSliceCount - 1) * 2 * 3
                    + sliceCount * 2 * 3 + sliceCount * 2 * 3];
                uint t = 0;
                for (uint i = 0; i < sliceCount; i++)
                {
                    for (uint j = 0; j < secondSliceCount - 1; j++)
                    {
                        indexes[t++] = i * secondSliceCount + j;
                        indexes[t++] = i * secondSliceCount + (j + 1) % secondSliceCount;
                        indexes[t++] = (i * secondSliceCount + secondSliceCount + (j + 1) % secondSliceCount) % (sliceCount * secondSliceCount);

                        indexes[t++] = i * secondSliceCount + j;
                        indexes[t++] = (i * secondSliceCount + secondSliceCount + (j + 1) % secondSliceCount) % (sliceCount * secondSliceCount);
                        indexes[t++] = (i * secondSliceCount + secondSliceCount + j) % (sliceCount * secondSliceCount);
                    }
                }
                for (uint i = 0; i < sliceCount; i++)
                {
                    indexes[t++] = upPlane + i;
                    indexes[t++] = upSphere[i];
                    indexes[t++] = upPlane + (i + 1) % sliceCount;

                    indexes[t++] = upPlane + (i + 1) % sliceCount;
                    indexes[t++] = upSphere[i];
                    indexes[t++] = upSphere[(i + 1) % sliceCount];
                }
                for (uint i = 0; i < sliceCount; i++)
                {
                    indexes[t++] = downPlane + i;
                    indexes[t++] = downPlane + (i + 1) % sliceCount;
                    indexes[t++] = downSphere[i];

                    indexes[t++] = downPlane + (i + 1) % sliceCount;
                    indexes[t++] = downSphere[(i + 1) % sliceCount];
                    indexes[t++] = downSphere[i];
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
