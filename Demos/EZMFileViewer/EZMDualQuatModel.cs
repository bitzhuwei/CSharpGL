using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EZMFileViewer
{
    class EZMDualQuatModel : IBufferSource
    {

        private EZMVertexBufferContainer container;
        private EZMMeshSection section;

        public EZMDualQuatModel(EZMVertexBufferContainer container, EZMMeshSection section)
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

        public mat4[] DefaultBoneMatrixes()
        {
            return this.container.DefaultBoneMatrixes();
        }

        public mat4[] GetBoneMatrixes()
        {
            return this.container.GetBoneMatrixes();
        }

        public int BoneCount { get { return this.container.BoneCount; } }

        //vertexbuffer count="13114" ctype="fff fff ff ff ff ffff hhhh" semantic="position normal texcoord1 texcoord2 texcoord3 blendweights blendindices">
        public const string strPosition = "position";
        public const string strNormal = "normal";
        public const string strUV = "texcoord1";
        public const string strBlendWeights = "blendweights";
        public const string strBlendIndices = "blendindices";

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
