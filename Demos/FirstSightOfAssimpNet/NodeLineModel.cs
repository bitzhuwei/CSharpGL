using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstSightOfAssimpNet
{
    class NodeLineModel : IBufferSource
    {
        private Assimp.Scene scene;
        private vec3[] positions;
        private vec3[] colors;

        public NodeLineModel(Assimp.Scene scene)
        {
            this.scene = scene;
            GeneratePositions(scene);
        }

        private void GeneratePositions(Assimp.Scene scene)
        {
            var lstPosition = new List<vec3>();
            var lstColor = new List<vec3>();
            if (scene.RootNode != null && scene.RootNode.HasChildren)
            {
                mat4 mat = scene.RootNode.Transform.ToMat4();
                foreach (Assimp.Node child in scene.RootNode.Children)
                {
                    ParseNode(child, lstPosition, lstColor, mat);
                }
            }

            this.positions = lstPosition.ToArray();
            this.colors = lstColor.ToArray();
        }

        private void ParseNode(Assimp.Node node, List<vec3> lstPosition, List<vec3> lstColor, mat4 parentTransform)
        {
            var parentPosition = new vec3(parentTransform * new vec4(0, 0, 0, 1));
            lstPosition.Add(parentPosition); lstColor.Add(new vec3(1, 0, 0));
            mat4 thisTransform = parentTransform * node.Transform.ToMat4();
            var position = new vec3(thisTransform * new vec4(0, 0, 0, 1));
            lstPosition.Add(position); lstColor.Add(new vec3(1, 1, 1));
            if (node.HasChildren)
            {
                foreach (Assimp.Node child in node.Children)
                {
                    ParseNode(child, lstPosition, lstColor, thisTransform);
                }
            }
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        public const string strColor = "color";
        private VertexBuffer colorBuffer;

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
            else if (strColor == bufferName)
            {
                if (this.colorBuffer == null)
                {
                    this.colorBuffer = this.colors.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.colorBuffer;
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
                this.drawCommand = new DrawArraysCmd(DrawMode.Lines, this.positions.Length);
            }

            yield return this.drawCommand;
        }

        #endregion
    }
}
