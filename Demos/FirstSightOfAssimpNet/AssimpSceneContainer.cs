using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;
using System.IO;
using System.ComponentModel;
using System.Drawing.Design;

namespace FirstSightOfAssimpNet
{
    /// <summary>
    /// manage textures and bones.
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public class AssimpSceneContainer
    {
        public readonly Assimp.Scene aiScene;

        private TextureProvider[] textureProviders;

        [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
        public TextureProvider[] TextureProviders
        {
            get { return textureProviders; }
        }

        /// <summary>
        /// manage textures and bones.
        /// </summary>
        /// <param name="aiScene"></param>
        /// <param name="filename"></param>
        public AssimpSceneContainer(Assimp.Scene aiScene, string filename)
        {
            this.aiScene = aiScene;
            this.textureProviders = InitTextures(aiScene, filename);
        }

        private TextureProvider[] InitTextures(Assimp.Scene aiScene, string filename)
        {
            var textureProviders = new TextureProvider[aiScene.MaterialCount];
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
                    var provider = new TextureProvider(fullname);
                    textureProviders[i] = provider;
                }
            }

            return textureProviders;
        }

        private AllBoneInfos allBoneInfos = null;
        public AllBoneInfos GetAllBoneInfos()
        {
            if (this.allBoneInfos == null)
            {
                this.allBoneInfos = InitBonesInfo(aiScene);
            }

            return this.allBoneInfos;
        }

        private AllBoneInfos InitBonesInfo(Assimp.Scene aiScene)
        {
            List<BoneInfo> boneInfos = new List<BoneInfo>();
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
                        var boneInfo = new BoneInfo(bone);
                        boneInfos.Add(boneInfo);
                        nameIndexDict.Add(boneName, (uint)(boneInfos.Count - 1));
                    }
                }
            }

            return new AllBoneInfos(boneInfos.ToArray(), nameIndexDict);
        }

    }

    public struct BoneInfo
    {
        public readonly Assimp.Bone bone;
        public mat4 finalTransformation;

        public BoneInfo(Assimp.Bone bone)
        {
            this.bone = bone;
            this.finalTransformation = mat4.identity();
        }

        public override string ToString()
        {
            return string.Format("{0} I {1}", this.bone, this.finalTransformation);
        }
    }

    public class AllBoneInfos
    {
        public readonly BoneInfo[] boneInfos;
        public readonly Dictionary<string, uint> nameIndexDict;

        public AllBoneInfos(BoneInfo[] boneInfos, Dictionary<string, uint> nameIndexDict)
        {
            this.boneInfos = boneInfos;
            this.nameIndexDict = nameIndexDict;
        }

        public override string ToString()
        {
            return string.Format("{0} bones, {1} dict items", boneInfos.Length, nameIndexDict.Count);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public class TextureProvider : ITextureSource
    {
        private Texture texture;
        private string filename;

        public string Filename
        {
            get { return filename; }
            set
            {
                if (filename != value && File.Exists(value))
                {
                    Bitmap bitmap;
                    try
                    {
                        bitmap = new Bitmap(value);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            var name = value.Substring(0, value.LastIndexOf('.')) + ".png";
                            bitmap = new Bitmap(name);
                        }
                        catch (Exception ex2)
                        {
                            bitmap = new Bitmap(1, 1);
                            using (var g = Graphics.FromImage(bitmap))
                            { g.FillRectangle(Brushes.White, 0, 0, 1, 1); }
                        }
                    }
                    //bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
                    var storage = new TexImageBitmap(bitmap);
                    var texture = new Texture(storage,
                          new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_REPEAT),
                          new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_REPEAT),
                          new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                          new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
                    texture.Initialize();
                    this.texture = texture;
                    filename = value;
                }
            }
        }

        public TextureProvider(string filename)
        {
            this.Filename = filename;
        }

        #region ITextureSource 成员

        public Texture BindingTexture
        {
            get { return this.texture; }
        }

        #endregion

        public override string ToString()
        {
            return string.Format("{0}", this.filename);
        }
    }
}
