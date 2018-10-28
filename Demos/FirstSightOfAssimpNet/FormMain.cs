using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            if (File.Exists(filename))
            {
                CreateAnimationNodes(filename);
                CreateNodePointNode(filename);
                CreateNodeLineNode(filename);
            }
        }

        private void CreateNodeLineNode(string filename)
        {
            var importer = new Assimp.AssimpImporter();
            Assimp.Scene aiScene = null;
            try
            {
                aiScene = importer.ImportFile(filename, Assimp.PostProcessSteps.GenerateSmoothNormals | Assimp.PostProcessSteps.Triangulate | Assimp.PostProcessSteps.FlipUVs);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return; }

            var rootElement = this.scene.RootNode;
            var model = new NodeLineModel(aiScene);
            var node = NodeLineNode.Create(model);
            rootElement.Children.Add(node);
        }

        private void CreateNodePointNode(string filename)
        {
            var importer = new Assimp.AssimpImporter();
            Assimp.Scene aiScene = null;
            try
            {
                aiScene = importer.ImportFile(filename, Assimp.PostProcessSteps.GenerateSmoothNormals | Assimp.PostProcessSteps.Triangulate | Assimp.PostProcessSteps.FlipUVs);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return; }

            var rootElement = this.scene.RootNode;
            var container = new AssimpSceneContainer(aiScene, filename);
            var model = new NodePointModel(aiScene, container);
            var node = NodePointNode.Create(model);
            rootElement.Children.Add(node);
            node.DiffuseColor = Color.Red;
        }

        private void CreateAnimationNodes(string filename)
        {
            var importer = new Assimp.AssimpImporter();
            Assimp.Scene aiScene = null;
            try
            {
                aiScene = importer.ImportFile(filename, Assimp.PostProcessSteps.GenerateSmoothNormals | Assimp.PostProcessSteps.Triangulate | Assimp.PostProcessSteps.FlipUVs);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return; }

            var rootElement = this.scene.RootNode;
            var random = new Random();
            bool first = true; vec3 max = new vec3(); vec3 min = new vec3();
            var container = new AssimpSceneContainer(aiScene, filename);
            var models = new AnimationModel[aiScene.MeshCount];
            if (aiScene.HasMeshes)
            {
                int index = 0;
                foreach (Assimp.Mesh mesh in aiScene.Meshes)
                {
                    models[index++] = new AnimationModel(mesh, container);
                }
            }
            if (aiScene.RootNode != null)
            {
                mat4 parentTransform = mat4.identity();
                BuildNode(aiScene.RootNode, parentTransform, models, rootElement, ref max, ref min, ref first);
            }

            vec3 center = max / 2.0f + min / 2.0f;
            vec3 size = max - min;
            float v = size.x;
            if (v < size.y) { v = size.y; } if (v < size.z) { v = size.z; }
            this.scene.Camera.Position = center + size;
            this.scene.Camera.Target = center;
            //rootElement.WorldPosition = center;
            this.manipulater.StepLength = v / 30.0f;
        }

        private void BuildNode(Assimp.Node aiNode, mat4 parentTransform, AnimationModel[] models, SceneNodeBase rootElement, ref vec3 max, ref vec3 min, ref bool first)
        {
            mat4 thisTransform = parentTransform * aiNode.Transform.ToMat4();
            if (aiNode.HasMeshes)
            {
                vec3 worldPosition, scale; vec4 rotation;
                thisTransform.ParseRST(out worldPosition, out scale, out rotation);
                foreach (int meshIndex in aiNode.MeshIndices)
                {
                    AnimationModel model = models[meshIndex];
                    GetBound(model.mesh, ref max, ref min, ref first);
                    var node = AnimationNode.Create(model);
                    var random = new Random();
                    node.DiffuseColor = Color.FromArgb(
                        (byte)random.Next(0, 256),
                        (byte)random.Next(0, 256),
                        (byte)random.Next(0, 256),
                        (byte)random.Next(0, 256)
                        );
                    node.WorldPosition = worldPosition;
                    node.Scale = scale;
                    node.RotationAxis = new vec3(rotation.x, rotation.y, rotation.z);
                    node.RotationAngle = rotation.w;
                    rootElement.Children.Add(node);
                }
            }

            if (aiNode.HasChildren)
            {
                foreach (Assimp.Node child in aiNode.Children)
                {
                    BuildNode(child, thisTransform, models, rootElement, ref max, ref min, ref first);
                }
            }
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
                CreateAnimationNodes(filename);
                CreateNodePointNode(filename);
                CreateNodeLineNode(filename);
            }
        }

    }
}
