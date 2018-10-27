using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;
using System.IO;

namespace FirstSightOfAssimpNet
{
    public class AssimpSceneContainer
    {
        public readonly Assimp.Scene aiScene;
        public readonly Texture[] textures;

        public AssimpSceneContainer(Assimp.Scene aiScene, string filename)
        {
            this.aiScene = aiScene;
            this.textures = InitTextures(aiScene, filename);
        }

        private Texture[] InitTextures(Assimp.Scene aiScene, string filename)
        {
            var textures = new Texture[aiScene.MaterialCount];
            // Extract the directory part from the file name
            string directory = new FileInfo(filename).DirectoryName;

            // Initialize the materials
            for (uint i = 0; i < aiScene.MaterialCount; i++)
            {
                Assimp.Material material = aiScene.Materials[i];

                if (material.GetTextureCount(Assimp.TextureType.Diffuse) > 0)
                {
                    Assimp.TextureSlot slot = material.GetTexture(Assimp.TextureType.Diffuse, 0);
                    string fullname = Path.Combine(directory, slot.FilePath);
                    Bitmap bitmap;
                    try
                    {
                        bitmap = new Bitmap(fullname);
                    }
                    catch (Exception ex)
                    {
                        var name = fullname.Substring(0, fullname.LastIndexOf('.')) + ".png";
                        bitmap = new Bitmap(name);
                    }
                    //bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
                    var storage = new TexImageBitmap(bitmap);
                    var texture = new Texture(storage,
                          new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_REPEAT),
                          new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_REPEAT),
                          new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                          new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
                    texture.Initialize();
                    textures[i] = texture;
                }
            }

            return textures;
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
        public mat4 FinalTransformation;
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
