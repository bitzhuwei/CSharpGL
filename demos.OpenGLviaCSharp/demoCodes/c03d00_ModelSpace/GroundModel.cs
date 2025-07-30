using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c03d00_ModelSpace {
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
    class GroundModel : IBufferSource {
        private readonly vec3[] positions;
        //private readonly vec3[] colors;

        public GroundModel(int length) {
            if (length <= 0) { throw new ArgumentException(); }

            {
                var positions = new vec3[(length + 1) * 2 * 2];
                int index = 0;
                float halfLength = length / 2.0f;
                for (int i = 0; i < length + 1; i++) {
                    var a = new vec3(halfLength, 0, i - halfLength);
                    var b = new vec3(-halfLength, 0, i - halfLength);
                    positions[index++] = a; positions[index++] = b;
                }
                for (int i = 0; i < length + 1; i++) {
                    var a = new vec3(i - halfLength, 0, halfLength);
                    var b = new vec3(i - halfLength, 0, -halfLength);
                    positions[index++] = a; positions[index++] = b;
                }

                positions.Move2Center();
                this.positions = positions;
            }
        }

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
                this.drawCommand = new DrawArraysCmd(CSharpGL.DrawMode.Lines, positions.Length);
            }

            yield return this.drawCommand;
        }

        #endregion
    }
}
