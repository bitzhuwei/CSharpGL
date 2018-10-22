using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace FirstSightOfAssimpNet
{
    public class AssimpSceneContainer
    {
        private Assimp.Scene aiScene;
        public AssimpSceneContainer(Assimp.Scene aiScene)
        {
            this.aiScene = aiScene;
        }

        private BonesInfo bonesInfo = null;
        public BonesInfo GetBones()
        {
            if (this.bonesInfo == null)
            {
                this.bonesInfo = InitBonesInfo(aiScene);
            }

            return this.bonesInfo;
        }

        private BonesInfo InitBonesInfo(Assimp.Scene aiScene)
        {
            List<BoneInfo> bones = new List<BoneInfo>();
            Dictionary<string, int> nameIndexDict = new Dictionary<string, int>();
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
                        boneInfo.BoneOffset = bone.OffsetMatrix;
                        bones.Add(boneInfo);
                        nameIndexDict.Add(boneName, bones.Count - 1);
                    }
                }
            }

            return new BonesInfo(bones.ToArray(), nameIndexDict);
        }
    }

    public struct BoneInfo
    {
        public Assimp.Matrix4x4 BoneOffset;
        public Assimp.Matrix4x4 FinalTransformation;
    }

    public class BonesInfo
    {
        public readonly BoneInfo[] bones;
        public readonly Dictionary<string, int> nameIndexDict;

        public BonesInfo(BoneInfo[] bones, Dictionary<string, int> nameIndexDict)
        {
            this.bones = bones;
            this.nameIndexDict = nameIndexDict;
        }

        public override string ToString()
        {
            return string.Format("{0} bones, {1} dict items", bones.Length, nameIndexDict.Count);
        }
    }
}
