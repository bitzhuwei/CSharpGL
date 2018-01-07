using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public partial class Teapot : IBufferSource
    {
        public vec3 GetModelSize()
        {
            return new vec3(3.214815f * 2, 1.575f * 2, 2.0f * 2);
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        public const string strColor = "color";
        private VertexBuffer colorBuffer;
        public const string strNormal = "normal";
        private VertexBuffer normalBuffer;

        private IDrawCommand drawCmd;

        #region IBufferable 成员

        public IEnumerable<VertexBuffer> GetVertexAttributeBuffer(string bufferName)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = Teapot.positionData.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else if (bufferName == strColor)
            {
                if (this.colorBuffer == null)
                {
                    this.colorBuffer = Teapot.normalData.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.colorBuffer;
            }
            else if (bufferName == strNormal)
            {
                if (this.normalBuffer == null)
                {
                    this.normalBuffer = Teapot.normalData.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.normalBuffer;
            }

            throw new NotImplementedException();
        }

        public IEnumerable<IDrawCommand> GetDrawCommand()
        {
            if (this.drawCmd == null)
            {
                Face[] faces = Teapot.faceData;
                int length = faces.Length * 3;
                var array = new ushort[length];
                for (int i = 0; i < faces.Length; i++)
                {
                    array[i * 3 + 0] = (ushort)(faces[i].vertexId1 - 1);
                    array[i * 3 + 1] = (ushort)(faces[i].vertexId2 - 1);
                    array[i * 3 + 2] = (ushort)(faces[i].vertexId3 - 1);
                }
                IndexBuffer buffer = array.GenIndexBuffer(BufferUsage.StaticDraw);
                this.drawCmd = new DrawElementsCmd(buffer, DrawMode.Triangles);
            }

            yield return this.drawCmd;
        }

        #endregion
    }
}
