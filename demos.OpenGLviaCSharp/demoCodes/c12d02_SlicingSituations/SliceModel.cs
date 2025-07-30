using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c12d02_SlicingSituations {

    class SliceModel : IBufferSource {
        private static readonly vec3[] positions = new vec3[]
        {
            new vec3(1, 0, 0),
            new vec3(0, 1, 0),
            new vec3(0, 0, 1),
        };


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
                this.drawCommand = new DrawArraysCmd(CSharpGL.DrawMode.Triangles, positions.Length);
            }

            yield return this.drawCommand;
        }

        #endregion
    }
}
