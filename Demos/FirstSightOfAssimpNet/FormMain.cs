using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FirstSightOfAssimpNet
{
    public partial class FormMain : Form
    {
        private Scene scene;
        private ActionList actionList;
        private FirstPerspectiveManipulater manipulater;
        private Assimp.Matrix4x4 m_GlobalInverseTransform;

        public FormMain()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var position = new vec3(5, 4, 3) * 3;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.winGLCanvas1.Width, this.winGLCanvas1.Height);

            this.scene = new Scene(camera);

            this.scene.RootNode = new GroupNode();
            (new FormPropertyGrid(scene)).Show();

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.winGLCanvas1);
            this.manipulater = manipulater;

            var rootElement = this.scene.RootNode;
            rootElement.Children.Clear();
            string filename = @"jeep.obj_";
            CreateDummyNodes(filename);
            //CreateTextureNode(filename);
            //CreateBoneNode(filename);
            //CreateDualQuatNode(filename);

        }

        private void CreateDummyNodes(string filename)
        {
            var importer = new Assimp.AssimpImporter();
            Assimp.Scene aiScene = null;
            try
            {
                aiScene = importer.ImportFile(filename, Assimp.PostProcessSteps.GenerateSmoothNormals | Assimp.PostProcessSteps.Triangulate | Assimp.PostProcessSteps.FlipUVs);
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

            if (aiScene == null) { return; }
            if (aiScene.AnimationCount > 0) { Console.WriteLine("Animations!"); }
            {
                m_GlobalInverseTransform = aiScene.RootNode.Transform;
                m_GlobalInverseTransform.Inverse();
                bool Ret = InitFromScene(aiScene, filename);
            }
            var rootElement = this.scene.RootNode;
            //for (int i = 0; i < aiScene.Animations.Length; i++)
            //{
            //    Assimp.Animation animation = aiScene.Animations[i];
            //    for (int j = 0; j < animation.NodeAnimationChannels.Length; j++)
            //    {
            //        Assimp.NodeAnimationChannel channel = animation.NodeAnimationChannels[j];

            //    }
            //}
            var random = new Random();
            bool first = true; vec3 max = new vec3(); vec3 min = new vec3();
            foreach (Assimp.Mesh mesh in aiScene.Meshes)
            {
                GetBound(mesh, ref max, ref min, ref first);
                var model = new DiffuseModel(mesh);
                var node = DiffuseNode.Create(model);
                node.DiffuseColor = Color.FromArgb(
                    (byte)random.Next(0, 256),
                    (byte)random.Next(0, 256),
                    (byte)random.Next(0, 256),
                    (byte)random.Next(0, 256)
                    );
                rootElement.Children.Add(node);
            }
            vec3 center = max / 2.0f + min / 2.0f;
            vec3 size = max - min;
            float v = size.x;
            if (v < size.y) { v = size.y; } if (v < size.z) { v = size.z; }
            this.scene.Camera.Position = new vec3(0, 4, 5) * v / 6.0f;
            this.scene.Camera.Target = center;
            this.manipulater.StepLength = v / 10.0f;
        }

        private bool InitFromScene(Assimp.Scene aiScene, string filename)
        {
            m_Entries = new MeshEntry[aiScene.MeshCount];
            m_Textures = new Texture[aiScene.MaterialCount];

            uint NumVertices = 0;
            uint NumIndices = 0;

            // Count the number of vertices and indices
            for (uint i = 0; i < m_Entries.Length; i++)
            {
                var entry = new MeshEntry();
                entry.MaterialIndex = pScene->mMeshes[i]->mMaterialIndex;
                entry.NumIndices = pScene->mMeshes[i]->mNumFaces * 3;
                entry.BaseVertex = NumVertices;
                entry.BaseIndex = NumIndices;
                m_Entries[i] = entry;

                NumVertices += pScene->mMeshes[i]->mNumVertices;
                NumIndices += m_Entries[i].NumIndices;
                NumVertices += aiScene.Meshes[i].VertexCount;
                NumIndices += entry.NumIndices;
            }

            // Reserve space in the vectors for the vertex attributes and indices
            var Positions = new vec3[NumVertices];
            var Normals = new vec3[NumVertices];
            var TexCoords = new vec2[NumVertices];
            var Bones = new Assimp.Matrix4x4[NumVertices];
            var Indices = new uint[NumIndices];

            // Initialize the meshes in the scene one by one
            for (uint i = 0; i < m_Entries.size(); i++)
            {
                Assimp.Mesh aiMesh = aiScene.Meshes[i];
                InitMesh(i, aiMesh, Positions, Normals, TexCoords, Bones, Indices);
            }

            if (!InitMaterials(aiScene, filename))
            {
                return false;
            }

            throw new NotImplementedException();
        }

        private bool InitMaterials(Assimp.Scene aiScene, string filename)
        {
            // Extract the directory part from the file name
            int SlashIndex = filename.LastIndexOf("/");
            string Dir;

            if (SlashIndex < 0)
            {
                Dir = ".";
            }
            else if (SlashIndex == 0)
            {
                Dir = "/";
            }
            else
            {
                Dir = filename.Substring(0, SlashIndex);
            }

            bool Ret = true;

            // Initialize the materials
            for (uint i = 0; i < aiScene.MaterialCount; i++)
            {
                Assimp.Material pMaterial = aiScene.Materials[i];

                m_Textures[i] = null;

                if (pMaterial.GetTextureCount(Assimp.TextureType.Diffuse) > 0)
                {
                    Assimp.TextureSlot slot = pMaterial.GetTexture(Assimp.TextureType.Diffuse, 0);
                    if (slot != null)
                    {
                        string filePath = slot.FilePath;

                        if (filePath.Substring(0, 2) == ".\\")
                        {
                            filePath = filePath.Substring(2, filePath.Length - 2);
                        }

                        string FullPath = Dir + "/" + filePath;
                        var bitmap = new Bitmap(FullPath);
                        bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
                        var storage = new TexImageBitmap(bitmap);
                        var texture = new Texture(storage,
                              new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_REPEAT),
                              new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_REPEAT),
                              new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                              new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
                        texture.Initialize();
                        m_Textures[i] = texture;
                    }
                }
            }

            return Ret;
        }

        private void InitMesh(uint MeshIndex, Assimp.Mesh aiMesh, vec3[] Positions, vec3[] Normals, vec2[] TexCoords, VertexBoneData[] Bones, uint[] Indices)
        {
            var Zero3D = new Assimp.Vector3D(0.0f, 0.0f, 0.0f);

            // Populate the vertex attribute vectors
            for (uint i = 0; i < aiMesh->mNumVertices; i++)
            {
                var pPos = aiMesh->mVertices[i];
                var pNormal = aiMesh->mNormals[i];
                var pTexCoord = aiMesh->HasTextureCoords(0) ? (paiMesh->mTextureCoords[0][i]) : Zero3D;

                Positions[i] = new vec3(pPos->x, pPos->y, pPos->z);
                Normals[i] = new vec3(pNormal->x, pNormal->y, pNormal->z);
                TexCoords[i] = new vec2(pTexCoord->x, pTexCoord->y);
            }

            LoadBones(MeshIndex, aiMesh, Bones);

            // Populate the index buffer
            for (uint i = 0; i < paiMesh->mNumFaces; i++)
            {
                Assimp.Face Face = paiMesh->mFaces[i];
                Indices[i * 3 + 0] = Face.mIndices[0];
                Indices[i * 3 + 1] = Face.mIndices[1];
                Indices[i * 3 + 2] = Face.mIndices[2];
            }
        }

        List<BoneInfo> m_BoneInfo = new List<BoneInfo>();
        Dictionary<string, uint> m_BoneMapping = new Dictionary<string, uint>();

        private void LoadBones(uint MeshIndex, Assimp.Mesh aiMesh, VertexBoneData[] Bones)
        {

            for (uint i = 0; i < pMesh->mNumBones; i++)
            {
                uint BoneIndex = 0;
                string BoneName = aiMesh->mBones[i]->mName.data;

                if (m_BoneMapping.find(BoneName) == m_BoneMapping.end())
                {
                    // Allocate an index for a new bone
                    BoneIndex = m_NumBones;
                    m_NumBones++;
                    BoneInfo bi = new BoneInfo();
                    bi.BoneOffset = aiMesh.Bones[i].OffsetMatrix;
                    m_BoneInfo.Add(bi);
                    m_BoneMapping.Add(BoneName, BoneIndex);
                }
                else
                {
                    BoneIndex = m_BoneMapping[BoneName];
                }

                for (int j = 0; j < aiMesh.Bones[j].VertexWeightCount; j++)
                {
                    uint VertexID = m_Entries[MeshIndex].BaseVertex + aiMesh.Bones[i].VertexWeights[j].VertexID;
                    float Weight = aiMesh.Bones[i].VertexWeights[j].Weight;
                    Bones[VertexID].AddBoneData(BoneIndex, Weight);
                }
            }
        }

        public struct BoneInfo
        {
            public Assimp.Matrix4x4 BoneOffset;
            public Assimp.Matrix4x4 FinalTransformation;

            public BoneInfo()
            {
                BoneOffset.SetZero();
                FinalTransformation.SetZero();
            }
        }

        struct VertexBoneData
        {
            private const int NUM_BONES_PER_VEREX = 4;
            public uint[] IDs = new uint[NUM_BONES_PER_VEREX];
            public float[] Weights = new float[NUM_BONES_PER_VEREX];

            public VertexBoneData()
            {
                Reset();
            }

            public void Reset()
            {
                for (int i = 0; i < IDs.Length; i++)
                {
                    IDs[i] = 0;
                }
                for (int i = 0; i < Weights.Length; i++)
                {
                    Weights[i] = 0;
                }
            }


            internal void AddBoneData(uint BoneID, float Weight)
            {
                for (int i = 0; i < this.IDs.Length; i++)
                {
                    if (this.Weights[i] == 0.0f)
                    {
                        this.IDs[i] = BoneID;
                        this.Weights[i] = Weight;
                        return;
                    }
                }
            }
        }
        private MeshEntry[] m_Entries;
        private Texture[] m_Textures;
        private uint m_NumBones;

        public struct MeshEntry
        {
            public const uint INVALID_MATERIAL = 0xFFFFFFFF;
            MeshEntry()
            {
                NumIndices = 0;
                BaseVertex = 0;
                BaseIndex = 0;
                MaterialIndex = INVALID_MATERIAL;
            }

            public uint NumIndices;
            public uint BaseVertex;
            public uint BaseIndex;
            public uint MaterialIndex;
        };
        private void GetBound(Assimp.Mesh mesh, ref vec3 max, ref vec3 min, ref bool first)
        {
            foreach (var item in mesh.Vertices)
            {
                if (first)
                {
                    max = new vec3(item.X, item.Y, item.Z);
                    min = max;
                    first = false;
                }
                else
                {
                    if (max.x < item.X) { max.x = item.X; }
                    if (max.y < item.Y) { max.y = item.Y; }
                    if (max.z < item.Z) { max.z = item.Z; }

                    if (item.X < min.x) { min.x = item.X; }
                    if (item.Y < min.y) { min.y = item.Y; }
                    if (item.Z < min.z) { min.z = item.Z; }
                }
            }
        }

        private void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            ActionList list = this.actionList;
            if (list != null)
            {
                vec4 clearColor = this.scene.ClearColor;
                GL.Instance.ClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                list.Act(new ActionParams(Viewport.GetCurrent()));
            }
        }

        void winGLCanvas1_Resize(object sender, EventArgs e)
        {
            this.scene.Camera.AspectRatio = ((float)this.winGLCanvas1.Width) / ((float)this.winGLCanvas1.Height);
        }

        private void 打开OToolStripButton_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var rootElement = this.scene.RootNode;
                rootElement.Children.Clear();
                string filename = this.openFileDialog1.FileName;
                CreateDummyNodes(filename);
            }
        }

    }
}
