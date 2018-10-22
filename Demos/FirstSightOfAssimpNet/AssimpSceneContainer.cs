using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace FirstSightOfAssimpNet
{
    public class AssimpSceneContainer
    {
        public readonly Assimp.Scene aiScene;
        public AssimpSceneContainer(Assimp.Scene aiScene)
        {
            this.aiScene = aiScene;
        }

        private AllBones bonesInfo = null;
        public AllBones GetAllBones()
        {
            if (this.bonesInfo == null)
            {
                this.bonesInfo = InitBonesInfo(aiScene);
            }

            return this.bonesInfo;
        }

        private AllBones InitBonesInfo(Assimp.Scene aiScene)
        {
            List<BoneInfo> bones = new List<BoneInfo>();
            var nameIndexDict = new Dictionary<string, uint>();
            for (int i = 0; i < aiScene.MeshCount; i++)
            {
                Assimp.Mesh mesh = aiScene.Meshes[i];
                for (int j = 0; j < mesh.BoneCount; j++)
                {
                    Assimp.Bone bone = mesh.Bones[j];
                    string boneName = bone.Name;
                    if (!nameIndexDict.ContainsKey(boneName))
                    {
                        var boneInfo = new BoneInfo();
                        boneInfo.Bone = bone;
                        bones.Add(boneInfo);
                        nameIndexDict.Add(boneName, (uint)(bones.Count - 1));
                    }
                }
            }

            return new AllBones(bones.ToArray(), nameIndexDict);
        }

    }

    public struct BoneInfo
    {
        public Assimp.Bone Bone;
        public Assimp.Matrix4x4 FinalTransformation;
    }

    public class AllBones
    {
        public readonly BoneInfo[] boneInfos;
        public readonly Dictionary<string, uint> nameIndexDict;

        public AllBones(BoneInfo[] boneInfos, Dictionary<string, uint> nameIndexDict)
        {
            this.boneInfos = boneInfos;
            this.nameIndexDict = nameIndexDict;
        }

        public override string ToString()
        {
            return string.Format("{0} bones, {1} dict items", boneInfos.Length, nameIndexDict.Count);
        }
    }
}
