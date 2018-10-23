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
            //string filename = @"jeep.obj_";
            string filename = @"D:\(TODO) - openGLStepbyStep\ogldev-source\Content\boblampclean.md5mesh";
            //CreateDummyNodes(filename);
            CreateBoneNodes(filename);
            rootElement.RotationAxis = new vec3(1, 0, 0);
            rootElement.RotationAngle = 270;
        }

        private void CreateBoneNodes(string filename)
        {
            var importer = new Assimp.AssimpImporter();
            Assimp.Scene aiScene = null;
            try
            {
                aiScene = importer.ImportFile(filename, Assimp.PostProcessSteps.GenerateSmoothNormals | Assimp.PostProcessSteps.Triangulate | Assimp.PostProcessSteps.FlipUVs);
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

            if (aiScene == null) { return; }
            //if (aiScene.AnimationCount > 0) { Console.WriteLine("Animations!"); }
            //{
            //    m_GlobalInverseTransform = aiScene.RootNode.Transform;
            //    m_GlobalInverseTransform.Inverse();
            //    //bool Ret = InitFromScene(aiScene, filename);
            //}
            var rootElement = this.scene.RootNode;
            var random = new Random();
            bool first = true; vec3 max = new vec3(); vec3 min = new vec3();
            var container = new AssimpSceneContainer(aiScene, filename);
            foreach (Assimp.Mesh mesh in aiScene.Meshes)
            {
                GetBound(mesh, ref max, ref min, ref first);
                var model = new BoneModel(mesh, container);
                var node = BoneNode.Create(model);
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
            this.scene.Camera.Position = size;
            this.scene.Camera.Target = center;
            rootElement.WorldPosition = center;
            this.manipulater.StepLength = v / 10.0f;
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
                //bool Ret = InitFromScene(aiScene, filename);
            }
            var rootElement = this.scene.RootNode;
            var random = new Random();
            bool first = true; vec3 max = new vec3(); vec3 min = new vec3();
            var container = new AssimpSceneContainer(aiScene, filename);
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
                //CreateDummyNodes(filename);
                CreateBoneNodes(filename);
            }
        }

    }
}
