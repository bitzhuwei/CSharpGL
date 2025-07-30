﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace DepthPeeling.FrontToBackPeeling {
    class CubeModel : IBufferSource {
        private static vec3[] vertices = new vec3[8] { new vec3(-0.5f, -0.5f, -0.5f), new vec3(0.5f, -0.5f, -0.5f), new vec3(0.5f, 0.5f, -0.5f), new vec3(-0.5f, 0.5f, -0.5f), new vec3(-0.5f, -0.5f, 0.5f), new vec3(0.5f, -0.5f, 0.5f), new vec3(0.5f, 0.5f, 0.5f), new vec3(-0.5f, 0.5f, 0.5f) };

        private static ushort[] cubeIndices = new ushort[] {
            0, 5, 4, 5, 0, 1, 
            //3, 7, 6, 3, 6, 2, 
            7, 4, 6, 6, 4, 5, 
            //2, 1, 3, 3, 1, 0, 
            3, 0, 7, 7, 0, 4,
            //6, 5, 2, 2, 5, 1 
        };

        public const string positions = "positions";
        private VertexBuffer positionBuffer;

        private IDrawCommand drawCmd;

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName) {
            if (positions == bufferName) {
                if (this.positionBuffer == null) {
                    this.positionBuffer = vertices.GenVertexBuffer(VBOConfig.Vec3, GLBuffer.Usage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else {
                throw new ArgumentException();
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand() {
            if (this.drawCmd == null) {
                IndexBuffer buffer = cubeIndices.GenIndexBuffer(IndexBuffer.ElementType.UShort, GLBuffer.Usage.StaticDraw);
                this.drawCmd = new DrawElementsCmd(buffer, CSharpGL.DrawMode.Triangles);
            }

            yield return this.drawCmd;
        }

        #endregion
    }
}
