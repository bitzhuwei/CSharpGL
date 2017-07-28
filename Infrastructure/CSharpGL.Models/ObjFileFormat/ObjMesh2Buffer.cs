using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Models
{
    /// <summary>
    /// contains a single mesh.
    /// </summary>
    public class ObjMesh2Buffer : IBufferSource
    {
        private ObjMesh mesh;

        public ObjMesh2Buffer(ObjMesh mesh)
        {
            this.mesh = mesh;
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        public const string strNormal = "normal";
        private VertexBuffer normalBuffer;

        private IndexBuffer indexBuffer;

        #region IBufferSource 成员

        public VertexBuffer GetVertexAttributeBuffer(string bufferName)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = this.mesh.position.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                return this.positionBuffer;
            }
            else if (bufferName == strNormal)
            {
                if (this.normalBuffer == null)
                {
                    this.normalBuffer = this.mesh.normals.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                return this.normalBuffer;
            }

            throw new ArgumentException("bufferName");
        }

        public IndexBuffer GetIndexBuffer()
        {
            if (this.indexBuffer == null)
            {
                OneIndexBuffer indexBuffer = OneIndexBuffer.Create(IndexBufferElementType.UInt, this.mesh.faceCount * 3, DrawMode.Triangles, BufferUsage.StaticDraw);
                unsafe
                {
                    var array = (uint*)indexBuffer.MapBuffer(MapBufferAccess.WriteOnly);
                    int index = 0;
                    foreach (var item in this.mesh.faces)
                    {
                        array[index++] = (uint)item.VertexIndexes[0];
                        array[index++] = (uint)item.VertexIndexes[1];
                        array[index++] = (uint)item.VertexIndexes[2];
                    }
                    indexBuffer.UnmapBuffer();
                }
            }

            return this.indexBuffer;
        }

        #endregion
    }
}
