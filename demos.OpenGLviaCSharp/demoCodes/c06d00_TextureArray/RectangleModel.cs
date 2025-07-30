﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c06d00_TextureArray {
    class RectangleModel : IBufferSource {
        public const string strPositoin = "position";
        private VertexBuffer positionBuffer;
        public const string strUV = "UV";
        private VertexBuffer uvBuffer;

        private IDrawCommand drawCommand;

        private static readonly vec3[] positions = new vec3[] {
            new vec3(-1,  1, 0), new vec3( 1,  1, 0),
            new vec3(-1, -1, 0), new vec3( 1, -1, 0),
        };
        private static readonly vec2[] uvs = new vec2[] {
            new vec2(0, 1), new vec2(1, 1),
            new vec2(0, 0), new vec2(1, 0),
        };

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName) {
            if (strPositoin == bufferName) {
                if (this.positionBuffer == null) {
                    this.positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec3, GLBuffer.Usage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else if (strUV == bufferName) {
                if (this.uvBuffer == null) {
                    this.uvBuffer = uvs.GenVertexBuffer(VBOConfig.Vec2, GLBuffer.Usage.StaticDraw);
                }

                yield return this.uvBuffer;
            }
            else {
                throw new ArgumentException();
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand() {
            if (this.drawCommand == null) {
                this.drawCommand = new DrawArraysCmd(CSharpGL.DrawMode.QuadStrip, 4);
            }

            yield return this.drawCommand;
        }

        #endregion
    }
}
