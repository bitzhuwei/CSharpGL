using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstSightOfAssimpNet
{
    class NodePointModel : IBufferSource
    {
        public readonly Assimp.Scene scene;
        public readonly AssimpSceneContainer container;
        private vec3[] positions;
        private int[] boneIndexes;

        public NodePointModel(Assimp.Scene scene, AssimpSceneContainer container)
        {
            this.scene = scene;
            this.container = container;
            this.positions = GetPositions(scene);
            this.boneIndexes = GetIndexes(scene, container);
        }

        private int[] GetIndexes(Assimp.Scene scene, AssimpSceneContainer container)
        {
            AllBones allBones = container.GetAllBones();
            Dictionary<string, uint> nameIndexDict = allBones.nameIndexDict;
            var list = new List<int>();
            ParseNodeIndexes(scene.RootNode, list, nameIndexDict);

            return list.ToArray();
        }

        private void ParseNodeIndexes(Assimp.Node node, List<int> list, Dictionary<string, uint> nameIndexDict)
        {
            uint index;
            if (nameIndexDict.TryGetValue(node.Name, out index))
            {
                list.Add((int)index);
            }
            else
            {
                list.Add(-1);
            }

            if (node.HasChildren)
            {
                foreach (Assimp.Node child in node.Children)
                {
                    ParseNodeIndexes(child, list, nameIndexDict);
                }
            }
        }

        private vec3[] GetPositions(Assimp.Scene scene)
        {
            var list = new List<vec3>();
            var current = new vec3(0, 0, 0);
            //list.Add(current);
            ParseNode(scene.RootNode, list, mat4.identity());

            return list.ToArray();
        }

        private void ParseNode(Assimp.Node node, List<vec3> list, mat4 parentTransform)
        {
            mat4 thisTransform = parentTransform * node.Transform.ToMat4();
            var position = new vec3(thisTransform * new vec4(0, 0, 0, 1));
            list.Add(position);
            if (node.HasChildren)
            {
                foreach (Assimp.Node child in node.Children)
                {
                    ParseNode(child, list, thisTransform);
                }
            }
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        public const string strBoneIndex = "boneIndex";
        private VertexBuffer boneIndexBuffer;

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
            else if (strBoneIndex == bufferName)
            {
                if (this.boneIndexBuffer == null)
                {
                    this.boneIndexBuffer = this.boneIndexes.GenVertexBuffer(VBOConfig.Int, BufferUsage.StaticDraw);
                }

                yield return this.boneIndexBuffer;
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
