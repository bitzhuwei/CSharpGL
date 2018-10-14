using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EZMFileViewer
{
    class EZMTextureModel : IBufferSource
    {

        private EZMMesh ezmMesh;

        public EZMTextureModel(EZMMesh ezmMesh)
        {
            this.ezmMesh = ezmMesh;
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        public const string strNormal = "normal";
        private VertexBuffer normalBuffer;
        public const string strUV = "UV";
        private VertexBuffer uvBuffer;

        private IDrawCommand[] drawCommands;

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = this.ezmMesh.Vertexbuffer.Buffers[0].array.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                int count = this.ezmMesh.MeshSections.Length;
                for (int i = 0; i < count; i++)
                {
                    yield return this.positionBuffer;
                }
            }
            else if (bufferName == strNormal)
            {
                if (this.normalBuffer == null)
                {
                    this.normalBuffer = this.ezmMesh.Vertexbuffer.Buffers[1].array.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                int count = this.ezmMesh.MeshSections.Length;
                for (int i = 0; i < count; i++)
                {
                    yield return this.normalBuffer;
                }
            }
            else if (bufferName == strUV)
            {
                if (this.uvBuffer == null)
                {
                    this.uvBuffer = this.ezmMesh.Vertexbuffer.Buffers[2].array.GenVertexBuffer(VBOConfig.Vec2, BufferUsage.StaticDraw);
                }

                int count = this.ezmMesh.MeshSections.Length;
                for (int i = 0; i < count; i++)
                {
                    yield return this.uvBuffer;
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand()
        {
            if (this.drawCommands == null)
            {
                var sections = this.ezmMesh.MeshSections;
                var cmds = new IDrawCommand[sections.Length];
                for (int i = 0; i < sections.Length; i++)
                {
                    var indexBuffer = sections[i].Indexbuffer.GenIndexBuffer(BufferUsage.StaticDraw);
                    cmds[i] = new DrawElementsCmd(indexBuffer, DrawMode.Triangles);
                }

                this.drawCommands = cmds;
            }

            foreach (var item in this.drawCommands)
            {
                yield return item;
            }
        }

        #endregion
    }
}
