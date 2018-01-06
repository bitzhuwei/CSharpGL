using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ObjVNF : IBufferSource
    {
        private ObjVNFMesh mesh;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public vec3 GetSize()
        {
            return mesh.Size;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public vec3 GetPosition()
        {
            return mesh.Position;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mesh"></param>
        public ObjVNF(ObjVNFMesh mesh)
        {
            this.mesh = mesh;
        }

        #region IBufferSource 成员

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        public const string strTexCoord = "texCoord";
        private VertexBuffer texCoordBuffer;
        public const string strNormal = "normal";
        private VertexBuffer normalBuffer;

        private IDrawCommand drawCmd;

        public VertexBuffer GetVertexAttributeBuffer(string bufferName)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = mesh.vertexes.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                return this.positionBuffer;
            }
            else if (bufferName == strTexCoord)
            {
                if (this.texCoordBuffer == null)
                {
                    this.texCoordBuffer = mesh.texCoords.GenVertexBuffer(VBOConfig.Vec2, BufferUsage.StaticDraw);
                }

                return this.texCoordBuffer;
            }
            else if (bufferName == strNormal)
            {
                if (this.normalBuffer == null)
                {
                    this.normalBuffer = mesh.normals.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                return this.normalBuffer;
            }

            throw new ArgumentException("bufferName");
        }

        public IDrawCommand GetDrawCommand()
        {
            if (this.drawCmd == null)
            {
                int polygon = (this.mesh.faces[0] is ObjVNFTriangle) ? 3 : 4;
                DrawMode mode = (this.mesh.faces[0] is ObjVNFTriangle) ? DrawMode.Triangles : DrawMode.Quads;
                IndexBuffer buffer = GLBuffer.Create(IndexBufferElementType.UInt, polygon * this.mesh.faces.Length, BufferUsage.StaticDraw);
                unsafe
                {
                    var array = (uint*)buffer.MapBuffer(MapBufferAccess.WriteOnly);
                    int index = 0;
                    foreach (var face in this.mesh.faces)
                    {
                        foreach (var vertexIndex in face.VertexIndexes())
                        {
                            array[index++] = vertexIndex;
                        }
                    }
                    buffer.UnmapBuffer();
                }

                this.drawCmd = new DrawElementsCmd(buffer, mode);
            }

            return this.drawCmd;
        }

        #endregion
    }
}
