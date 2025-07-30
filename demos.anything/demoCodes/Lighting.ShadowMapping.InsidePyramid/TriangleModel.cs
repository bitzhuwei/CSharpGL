﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace Lighting.ShadowMapping.InsidePyramid {
    class TriangleModel : IBufferSource {
        private static readonly vec3[] positions = new vec3[] { new vec3(0, 0, 0), new vec3(0, -1, 0), new vec3(0.5f, -1, -0.3f), };
        private static readonly vec3[] colors = new vec3[] { new vec3(1, 1, 1), new vec3(1, 1, 1), new vec3(1, 0, 0), };

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;

        public const string strColor = "color";
        private VertexBuffer colorBuffer;

        private IDrawCommand command;

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName) {
            if (bufferName == strPosition) {
                if (this.positionBuffer == null) {
                    this.positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec3, GLBuffer.Usage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else if (bufferName == strColor) {
                if (this.colorBuffer == null) {
                    this.colorBuffer = colors.GenVertexBuffer(VBOConfig.Vec3, GLBuffer.Usage.StaticDraw);
                }

                yield return this.colorBuffer;
            }
            else {
                throw new Exception(string.Format("Not expected buffer name: {0}", bufferName));
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand() {
            if (this.command == null) {
                int vertexCount = positions.Length;
                this.command = new DrawArraysCmd(CSharpGL.DrawMode.Triangles, vertexCount);
            }

            yield return this.command;
        }

        #endregion
    }
}
