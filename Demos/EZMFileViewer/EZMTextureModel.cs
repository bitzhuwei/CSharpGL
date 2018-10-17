using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EZMFileViewer
{
    class EZMTextureModel : IBufferSource
    {

        private EZMVertexBufferContainer container;
        private EZMMeshSection section;

        public EZMTextureModel(EZMVertexBufferContainer container, EZMMeshSection section)
        {
            this.container = container;
            this.section = section;
        }

        public Texture Texture
        {
            get
            {
                var tex = this.section.Material.Tag as Texture;
                return tex;
            }
        }

        public mat4[] BoneMatrixes
        {
            get
            {
                return this.container.BoneMatrixes;
            }
        }

        public int BoneCount { get { return this.container.BoneCount; } }

        public const string strPosition = "position";
        public const string strNormal = "normal";
        public const string strUV = "UV";

        private IDrawCommand drawCommand;

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName)
        {
            foreach (var item in this.container.GetVertexAttribute(bufferName))
            {
                yield return item;
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand()
        {
            if (this.drawCommand == null)
            {
                var indexBuffer = this.section.Indexbuffer.GenIndexBuffer(BufferUsage.StaticDraw);
                this.drawCommand = new DrawElementsCmd(indexBuffer, DrawMode.Triangles);
            }

            yield return this.drawCommand;
        }

        #endregion
    }
}
