using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c11d00_Arcball {
    class LinesModel : IBufferSource {
        private readonly vec3[] positions;
        private readonly vec3[] colors;

        public LinesModel(float radius) {
            float length = radius / (float)Math.Sqrt(2);
            const int count = 8;
            {
                var positions = new vec3[count];

                positions[0] = new vec3(-length, length, 0);
                positions[1] = new vec3(-length, 0, 0);
                positions[2] = new vec3(-length, length, 0);
                positions[3] = new vec3(-length, 0, 0);

                positions[4] = new vec3(length, 0, 0);
                positions[5] = new vec3(length, length, 0);
                positions[6] = new vec3(length, 0, 0);
                positions[7] = new vec3(length, length, 0);

                this.positions = positions;
            }
            {
                var colors = new vec3[count];
                // out 
                colors[0] = new vec3(0, 1, 0) * 0.5f;
                colors[1] = new vec3(0, 1, 0) * 0.5f;
                // in
                colors[2] = new vec3(0, 1, 0);
                colors[3] = new vec3(0, 1, 0);

                // out 
                colors[4] = new vec3(1, 0, 0) * 0.5f;
                colors[5] = new vec3(1, 0, 0) * 0.5f;
                // in
                colors[6] = new vec3(1, 0, 0);
                colors[7] = new vec3(1, 0, 0);

                this.colors = colors;
            }
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        public const string strColor = "color";
        private VertexBuffer colorBuffer;

        private IDrawCommand drawCmd;

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName) {
            if (strPosition == bufferName) {
                if (this.positionBuffer == null) {
                    this.positionBuffer = this.positions.GenVertexBuffer(VBOConfig.Vec3, GLBuffer.Usage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else if (strColor == bufferName) {
                if (this.colorBuffer == null) {
                    this.colorBuffer = this.colors.GenVertexBuffer(VBOConfig.Vec3, GLBuffer.Usage.StaticDraw);
                }

                yield return this.colorBuffer;
            }
            else {
                throw new ArgumentException();
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand() {
            if (this.drawCmd == null) {
                this.drawCmd = new DrawArraysCmd(CSharpGL.DrawMode.Lines, positions.Length);
            }

            yield return this.drawCmd;
        }

        #endregion

    }
}
