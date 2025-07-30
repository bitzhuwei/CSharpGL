using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c14d02_DoubleTransformFeedbakObjects {
    partial class DemoModel : IBufferSource {
        public const string strPosition = "position";
        public const string strPosition2 = "position2";
        private VertexBuffer positionBuffer;
        private VertexBuffer positionBuffer2;

        private IDrawCommand drawCmd;

        private static readonly vec3[] positions = new vec3[3];

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName) {
            if (bufferName == strPosition) {
                if (this.positionBuffer == null) {
                    this.positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec3, GLBuffer.Usage.DynamicCopy);
                }

                yield return this.positionBuffer;
            }
            else if (bufferName == strPosition2) {
                if (this.positionBuffer2 == null) {
                    this.positionBuffer2 = positions.GenVertexBuffer(VBOConfig.Vec3, GLBuffer.Usage.DynamicCopy);
                }

                yield return this.positionBuffer2;
            }
            else {
                throw new ArgumentException("bufferName");
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand() {
            if (this.drawCmd == null) {
                this.drawCmd = new DrawArraysCmd(CSharpGL.DrawMode.Triangles, positions.Length);
            }

            yield return this.drawCmd;
        }

        #endregion
    }
}
