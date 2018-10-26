using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstSightOfAssimpNet
{
    class NodeModel : IBufferSource
    {
        private Assimp.Scene scene;
        private vec3[] positions;

        public NodeModel(Assimp.Scene scene)
        {
            this.scene = scene;
            this.positions = GetPositions(scene);
        }

        private vec3[] GetPositions(Assimp.Scene scene)
        {
            var list = new List<vec3>();
            var current = new vec3(0, 0, 0);
            list.Add(current);
            ParseNode(scene.RootNode, list, mat4.identity());

            return list.ToArray();
        }

        private void ParseNode(Assimp.Node node, List<vec3> list, mat4 parentTransform)
        {
            mat4 mat = node.Transform.ToMat4();
            mat4 newTransform = parentTransform * mat;
            var position = new vec3(newTransform * new vec4(0, 0, 0, 1));
            list.Add(position);
            //list.Add(position);
            if (node.HasChildren)
            {
                foreach (Assimp.Node child in node.Children)
                {
                    ParseNode(child, list, newTransform);
                }
            }
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;

        private IDrawCommand drawCommand;

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName)
        {
            if (strPosition == bufferName)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = this.positions.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand()
        {
            if (this.drawCommand == null)
            {
                this.drawCommand = new DrawArraysCmd(DrawMode.Points, this.positions.Length);
            }

            yield return this.drawCommand;
        }

        #endregion
    }
}
