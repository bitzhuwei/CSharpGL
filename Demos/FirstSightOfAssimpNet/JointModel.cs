using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstSightOfAssimpNet
{
    class JointModel : IBufferSource
    {
        public readonly Assimp.Scene scene;
        public readonly AllBoneInfos allBoneInfos;
        private vec3[] positions;
        private mat4[] transforms;
        private mat4[] inversedTransforms;
        private int[] boneIndexes;
        private mat4[] offsetMats;
        private mat4[] multiplys; // all [0] or [1](identity matrix).
        private mat4[] inverseMutiplys;

        public JointModel(Assimp.Scene scene, AllBoneInfos allBoneInfos)
        {
            this.scene = scene;
            this.allBoneInfos = allBoneInfos;
            this.positions = GetPositions(scene);
            this.transforms = GetTransforms(scene);
            this.boneIndexes = GetIndexes(scene, allBoneInfos);
            //this.inversedTransforms = new mat4[this.transforms.Length];
            //for (int i = 0; i < this.transforms.Length; i++)
            //{
            //    this.inversedTransforms[i] = glm.inverse(this.transforms[i]);
            //}
            //AllBones allBones = container.GetAllBones();
            //BoneInfo[] boneInfos = allBones.boneInfos;
            //mat4[] offsetMats = new mat4[this.boneIndexes.Length];
            //for (int i = 0; i < this.boneIndexes.Length; i++)
            //{
            //    int index = this.boneIndexes[i];
            //    if (index >= 0)
            //    {
            //        offsetMats[i] = boneInfos[index].Bone.OffsetMatrix.ToMat4();
            //    }
            //}
            //this.offsetMats = offsetMats;
            //this.multiplys = new mat4[this.offsetMats.Length];
            //this.inverseMutiplys = new mat4[this.offsetMats.Length];
            //mat4 rootTransform = glm.inverse(scene.RootNode.Transform.ToMat4());
            //for (int i = 0; i < this.offsetMats.Length; i++)
            //{
            //    this.multiplys[i] = rootTransform * this.transforms[i] * this.offsetMats[i];
            //    this.inverseMutiplys[i] = this.inversedTransforms[i] * this.offsetMats[i];
            //}

            //Console.WriteLine("af");
        }

        private mat4[] GetTransforms(Assimp.Scene scene)
        {
            var list = new List<mat4>();
            ParseNodeTransform(scene.RootNode, list, mat4.identity());

            return list.ToArray();
        }

        private void ParseNodeTransform(Assimp.Node node, List<mat4> list, mat4 parentTransform)
        {
            mat4 thisTransform = parentTransform * node.Transform.ToMat4();
            list.Add(thisTransform);
            if (node.HasChildren)
            {
                foreach (Assimp.Node child in node.Children)
                {
                    ParseNodeTransform(child, list, thisTransform);
                }
            }
        }

        private int[] GetIndexes(Assimp.Scene scene, AllBoneInfos allBoneInfos)
        {
            Dictionary<string, uint> nameIndexDict = allBoneInfos.nameIndexDict;
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
