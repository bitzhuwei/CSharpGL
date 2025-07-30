using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {

    public unsafe class CylinderModel : IBufferSource, IObjFormat {
        private vec3 modelSize;
        public vec3 ModelSize() {
            return this.modelSize;
        }

        public CylinderModel(float radius, float height, uint sliceCount) {
            {
                var positions = new vec3[1 + sliceCount + sliceCount + 1];
                int t = 0;
                positions[t++] = new vec3(0, height / 2, 0);
                for (int i = 1; i < sliceCount + 1; i++) {
                    double d = 2 * Math.PI * i / (sliceCount);
                    positions[t++] = new vec3((float)Math.Sin(d) * radius, height / 2, (float)Math.Cos(d) * radius);
                }
                for (int i = 1; i < sliceCount + 1; i++) {
                    double d = 2 * Math.PI * i / (sliceCount);
                    positions[t++] = new vec3((float)Math.Sin(d) * radius, -height / 2, (float)Math.Cos(d) * radius);
                }
                positions[t++] = new vec3(0, -height / 2, 0);
                BoundingBox box = positions.Move2Center();
                this.positions = positions;
                this.modelSize = box.MaxPosition - box.MinPosition;
            }
            {
                var indexes = new uint[3 * (sliceCount + sliceCount * 2 + sliceCount)];
                uint t = 0;
                for (uint i = 0; i < sliceCount; i++) {
                    indexes[t++] = 0;
                    indexes[t++] = i + 1;
                    indexes[t++] = (i + 1) % sliceCount + 1;
                }
                for (uint i = 0; i < sliceCount; i++) {
                    indexes[t++] = (i + 1) % sliceCount + 1;
                    indexes[t++] = (i + 1);
                    indexes[t++] = sliceCount + (i + 1) % sliceCount + 1;

                    indexes[t++] = (i + 1);
                    indexes[t++] = sliceCount + (i + 1);
                    indexes[t++] = sliceCount + (i + 1) % sliceCount + 1;
                }
                for (uint i = 0; i < sliceCount; i++) {
                    indexes[t++] = sliceCount + sliceCount + 1;
                    indexes[t++] = sliceCount + (i + 1) % sliceCount + 1;
                    indexes[t++] = sliceCount + (i + 1);
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
                    this.positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec3, GLBuffer.Usage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else {
                throw new ArgumentException("bufferName");
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand() {
            if (this.drawCommand == null) {
                IndexBuffer indexBuffer = indexes.GenIndexBuffer(IndexBuffer.ElementType.UInt, GLBuffer.Usage.StaticDraw);
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
