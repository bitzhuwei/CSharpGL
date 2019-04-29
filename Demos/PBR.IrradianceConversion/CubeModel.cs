using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBR.IrradianceConversion {
    class CubeModel : IBufferSource {
        static readonly float[] vertices = {
            // back face
            -1.0f, -1.0f, -1.0f,  // bottom-left
             1.0f,  1.0f, -1.0f,  // top-right
             1.0f, -1.0f, -1.0f,  // bottom-right         
             1.0f,  1.0f, -1.0f,  // top-right
            -1.0f, -1.0f, -1.0f,  // bottom-left
            -1.0f,  1.0f, -1.0f,  // top-left
            // front face
            -1.0f, -1.0f,  1.0f,  // bottom-left
             1.0f, -1.0f,  1.0f,  // bottom-right
             1.0f,  1.0f,  1.0f,  // top-right
             1.0f,  1.0f,  1.0f,  // top-right
            -1.0f,  1.0f,  1.0f,  // top-left
            -1.0f, -1.0f,  1.0f,  // bottom-left
            // left face
            -1.0f,  1.0f,  1.0f,  // top-right
            -1.0f,  1.0f, -1.0f,  // top-left
            -1.0f, -1.0f, -1.0f,  // bottom-left
            -1.0f, -1.0f, -1.0f,  // bottom-left
            -1.0f, -1.0f,  1.0f,  // bottom-right
            -1.0f,  1.0f,  1.0f,  // top-right
            // right face
             1.0f,  1.0f,  1.0f,  // top-left
             1.0f, -1.0f, -1.0f,  // bottom-right
             1.0f,  1.0f, -1.0f,  // top-right         
             1.0f, -1.0f, -1.0f,  // bottom-right
             1.0f,  1.0f,  1.0f,  // top-left
             1.0f, -1.0f,  1.0f,  // bottom-left     
            // bottom face
            -1.0f, -1.0f, -1.0f,  // top-right
             1.0f, -1.0f, -1.0f,  // top-left
             1.0f, -1.0f,  1.0f,  // bottom-left
             1.0f, -1.0f,  1.0f,  // bottom-left
            -1.0f, -1.0f,  1.0f,  // bottom-right
            -1.0f, -1.0f, -1.0f,  // top-right
            // top face
            -1.0f,  1.0f, -1.0f,  // top-left
             1.0f,  1.0f , 1.0f,  // bottom-right
             1.0f,  1.0f, -1.0f,  // top-right     
             1.0f,  1.0f,  1.0f,  // bottom-right
            -1.0f,  1.0f, -1.0f,  // top-left
            -1.0f,  1.0f,  1.0f,  // bottom-left        
        };

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        private IDrawCommand drawCmd;

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName) {
            if (strPosition == bufferName) {
                if (this.positionBuffer == null) {
                    this.positionBuffer = vertices.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else {
                throw new ArgumentException();
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand() {
            if (this.drawCmd == null) {
                this.drawCmd = new DrawArraysCmd(DrawMode.Triangles, 36);
            }

            yield return this.drawCmd;
        }

        #endregion
    }
}
