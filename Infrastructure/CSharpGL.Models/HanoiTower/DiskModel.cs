using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {

    public class DiskModel : IBufferSource, IObjFormat {
        private vec3 modelSize;
        public vec3 ModelSize() {
            return this.modelSize;
        }

        public DiskModel(float radius, float holeRadius, float halfThickness, uint sliceCount, uint secondSliceCount) {
            float planeRadius = radius - holeRadius - halfThickness;
            uint[] outUpSphere = new uint[sliceCount];
            uint[] outDownSphere = new uint[sliceCount];
            uint[] inUpSphere = new uint[sliceCount];
            uint[] inDownSphere = new uint[sliceCount];
            {
                var positions = new vec3[sliceCount * ((secondSliceCount + 1) * 2)];
                uint t = 0;
                var y = new vec3(0, 1, 0);
                for (int i = 0; i < sliceCount; i++) {
                    outUpSphere[i] = t;
                    double di = 2 * Math.PI * i / sliceCount;
                    var center = new vec3(radius * (float)Math.Sin(di), 0, radius * (float)Math.Cos(di));
                    center = center.normalize();
                    for (int j = 0; j < (secondSliceCount + 1); j++) {
                        double dj = Math.PI / 2 + Math.PI * j / (secondSliceCount);
                        positions[t++] = center * ((radius + planeRadius) - halfThickness * (float)Math.Cos(dj))
                            + y * (halfThickness * (float)Math.Sin(dj));
                    }
                    outDownSphere[i] = t - 1;
                }
                for (int i = 0; i < sliceCount; i++) {
                    inDownSphere[i] = t;
                    double di = 2 * Math.PI * i / sliceCount;
                    var center = new vec3(radius * (float)Math.Sin(di), 0, radius * (float)Math.Cos(di));
                    center = center.normalize();
                    for (int j = 0; j < (secondSliceCount + 1); j++) {
                        double dj = Math.PI / 2 + Math.PI + Math.PI * j / (secondSliceCount);
                        positions[t++] = center * ((radius - planeRadius) - halfThickness * (float)Math.Cos(dj))
                            + y * (halfThickness * (float)Math.Sin(dj));
                    }
                    inUpSphere[i] = t - 1;
                }

                BoundingBox box = positions.Move2Center();
                this.positions = positions;
                this.modelSize = box.MaxPosition - box.MinPosition;
            }
            {
                var indexes = new uint[(sliceCount * (secondSliceCount) * 2 * 3 * 2)
                    + sliceCount * 2 * 3 + sliceCount * 2 * 3];
                uint t = 0;
                for (uint i = 0; i < sliceCount; i++) {
                    for (uint j = 0; j < secondSliceCount; j++) {
                        indexes[t++] = outUpSphere[i] + j;
                        indexes[t++] = outUpSphere[i] + (j + 1);
                        indexes[t++] = outUpSphere[(i + 1) % sliceCount] + j + 1;

                        indexes[t++] = outUpSphere[i] + j;
                        indexes[t++] = outUpSphere[(i + 1) % sliceCount] + j + 1;
                        indexes[t++] = outUpSphere[(i + 1) % sliceCount] + j;
                    }
                }
                for (uint i = 0; i < sliceCount; i++) {
                    for (uint j = 0; j < secondSliceCount; j++) {
                        indexes[t++] = inDownSphere[i] + j;
                        indexes[t++] = inDownSphere[i] + (j + 1);
                        indexes[t++] = inDownSphere[(i + 1) % sliceCount] + j + 1;

                        indexes[t++] = inDownSphere[i] + j;
                        indexes[t++] = inDownSphere[(i + 1) % sliceCount] + j + 1;
                        indexes[t++] = inDownSphere[(i + 1) % sliceCount] + j;
                    }
                }
                for (uint i = 0; i < sliceCount; i++) {
                    indexes[t++] = inUpSphere[i];
                    indexes[t++] = outUpSphere[i];
                    indexes[t++] = outUpSphere[(i + 1) % sliceCount];

                    indexes[t++] = inUpSphere[i];
                    indexes[t++] = outUpSphere[(i + 1) % sliceCount];
                    indexes[t++] = inUpSphere[(i + 1) % sliceCount];
                }
                for (uint i = 0; i < sliceCount; i++) {
                    indexes[t++] = inDownSphere[i];
                    indexes[t++] = outDownSphere[(i + 1) % sliceCount];
                    indexes[t++] = outDownSphere[i];

                    indexes[t++] = inDownSphere[i];
                    indexes[t++] = inDownSphere[(i + 1) % sliceCount];
                    indexes[t++] = outDownSphere[(i + 1) % sliceCount];
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

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName) {
            if (strPosition == bufferName) // requiring position buffer.
            {
                if (this.positionBuffer == null) {
                    this.positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else {
                throw new ArgumentException("bufferName");
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand() {
            if (this.drawCommand == null) {
                IndexBuffer indexBuffer = indexes.GenIndexBuffer(BufferUsage.StaticDraw);
                this.drawCommand = new DrawElementsCmd(indexBuffer, DrawMode.Triangles);
            }

            yield return this.drawCommand;
        }

        #endregion

        #region IObjFormat 成员

        public vec3[] GetPositions() {
            return this.positions;
        }

        public vec2[] GetTexCoords() {
            return new vec2[] { };
        }

        public uint[] GetIndexes() {
            return this.indexes;
        }

        #endregion
    }
}
