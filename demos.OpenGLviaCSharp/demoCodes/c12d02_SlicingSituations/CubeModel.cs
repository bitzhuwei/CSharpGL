﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c12d02_SlicingSituations {

    class CubeModel : IBufferSource {
        private static readonly vec3[] positions = new vec3[]
        { 
            // X
            new vec3(-1, +1, +1), new vec3(+1, +1, +1),
            new vec3(-1, -1, +1), new vec3(+1, -1, +1),
            new vec3(-1, +1, -1), new vec3(+1, +1, -1),
            new vec3(-1, -1, -1), new vec3(+1, -1, -1),
            // Y
            new vec3(+1, -1, +1), new vec3(+1, +1, +1),
            new vec3(-1, -1, +1), new vec3(-1, +1, +1),
            new vec3(+1, -1, -1), new vec3(+1, +1, -1),
            new vec3(-1, -1, -1), new vec3(-1, +1, -1),
            // Z
            new vec3(+1, +1, -1), new vec3(+1, +1, +1),
            new vec3(+1, -1, -1), new vec3(+1, -1, +1),
            new vec3(-1, +1, -1), new vec3(-1, +1, +1),
            new vec3(-1, -1, -1), new vec3(-1, -1, +1),
        };
        private static readonly vec3[] colors = new vec3[]
      { 
            // X
            new vec3(1, 0, 0), new vec3(1, 0, 0),
            new vec3(1, 0, 0), new vec3(1, 0, 0),
            new vec3(1, 0, 0), new vec3(1, 0, 0),
            new vec3(1, 0, 0), new vec3(1, 0, 0),
            // Y
            new vec3(0, 1, 0), new vec3(0, 1, 0),
            new vec3(0, 1, 0), new vec3(0, 1, 0),
            new vec3(0, 1, 0), new vec3(0, 1, 0),
            new vec3(0, 1, 0), new vec3(0, 1, 0),
            // Z
            new vec3(0, 0, 1), new vec3(0, 0, 1),
            new vec3(0, 0, 1), new vec3(0, 0, 1),
            new vec3(0, 0, 1), new vec3(0, 0, 1),
            new vec3(0, 0, 1), new vec3(0, 0, 1),
        };

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        public const string strColor = "color";
        private VertexBuffer colorBuffer;

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
            else if (strColor == bufferName) // requiring position buffer.
            {
                if (this.colorBuffer == null) {
                    this.colorBuffer = colors.GenVertexBuffer(VBOConfig.Vec3, GLBuffer.Usage.StaticDraw);
                }

                yield return this.colorBuffer;
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
