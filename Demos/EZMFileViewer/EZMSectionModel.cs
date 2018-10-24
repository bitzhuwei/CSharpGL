using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EZMFileViewer
{
    class EZMSectionModel : IBufferSource
    {
        private byte[] positions;
        private CSharpGL.EZMMeshSection[] indexSections;
        public EZMSectionModel(EZMFile ezmFile)
        {
            var mesh = ezmFile.MeshSystem.Meshes[0];
            this.positions = mesh.Vertexbuffer.Buffers[0].array;
            this.indexSections = mesh.MeshSections;
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;

        private IDrawCommand[] drawCommands;

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = this.positions.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                int count = this.indexSections.Length;
                for (int i = 0; i < count; i++)
                {
                    yield return this.positionBuffer;
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
                var sections = this.indexSections;
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
