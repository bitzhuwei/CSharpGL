using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSharpGL;

namespace EZMFileViewer
{
    public partial class FormMain : Form
    {
        private Scene scene;
        private ActionList actionList;

        public FormMain()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var position = new vec3(-5, 6, 4) * 3;
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

            var rootElement = this.scene.RootNode;
            rootElement.Children.Clear();
            string filename = @"D:\GitHub\CSharpGL\Demos\EZMFileViewer\media\dwarf_anim.ezm";
            CreateTextureNode(filename);
            CreateBonePointNode(filename);
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

        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var rootElement = this.scene.RootNode;
                rootElement.Children.Clear();
                string filename = this.openFileDialog1.FileName;
                CreateTextureNode(filename);
                CreateBonePointNode(filename);
            }
        }

        private void CreateDualQuatNode(string filename)
        {
            EZMFile ezmFile = EZMFile.Load(filename);
            ezmFile.LoadTextures();
            var rootElement = this.scene.RootNode;
            for (int i = 0; i < ezmFile.MeshSystem.Meshes.Length; i++)
            {
                EZMMesh mesh = ezmFile.MeshSystem.Meshes[i];
                EZMAnimation animation = ezmFile.MeshSystem.Animations.Length > 0 ? ezmFile.MeshSystem.Animations[0] : null;
                var container = new EZMVertexBufferContainer(mesh, null);
                for (int j = 0; j < mesh.MeshSections.Length; j++)
                {
                    var model = new EZMDualQuatModel(container, mesh.MeshSections[j]);
                    var node = EZMDualQuatNode.Create(model);
                    rootElement.Children.Add(node);
                }
            }
        }

        private void CreateBonePointNode(string filename)
        {
            EZMFile ezmFile = EZMFile.Load(filename);
            ezmFile.LoadTextures();
            var rootElement = this.scene.RootNode;
            for (int i = 0; i < ezmFile.MeshSystem.Meshes.Length; i++)
            {
                EZMMesh mesh = ezmFile.MeshSystem.Meshes[i];
                var model = new NodePointModel(mesh.Skeleton.Bones);
                var node = NodePointNode.Create(model);
                node.DiffuseColor = Color.Red;
                rootElement.Children.Add(node);
            }
        }

        private void CreateTextureNode(string filename)
        {
            EZMFile ezmFile = EZMFile.Load(filename);
            ezmFile.LoadTextures();
            var rootElement = this.scene.RootNode;
            for (int i = 0; i < ezmFile.MeshSystem.Meshes.Length; i++)
            {
                EZMMesh mesh = ezmFile.MeshSystem.Meshes[i];
                EZMAnimation animation = ezmFile.MeshSystem.Animations.Length > 0 ? ezmFile.MeshSystem.Animations[0] : null;
                var container = new EZMVertexBufferContainer(mesh, animation);
                for (int j = 0; j < mesh.MeshSections.Length; j++)
                {
                    var model = new EZMTextureModel(container, mesh.MeshSections[j]);
                    var node = EZMTextureNode.Create(model);
                    rootElement.Children.Add(node);
                }
            }
        }

        //private void CreateSectionNode(string filename)
        //{
        //    var random = new Random();
        //    EZMFile ezmFile = EZMFile.Load(filename);
        //    var rootElement = this.scene.RootNode;
        //    var model = new EZMSectionModel(ezmFile);
        //    var node = EZMSectionNode.Create(model);
        //    node.Color = Color.FromArgb(
        //        (byte)random.Next(0, 256),
        //        (byte)random.Next(0, 256),
        //        (byte)random.Next(0, 256),
        //        (byte)random.Next(0, 256)
        //        );
        //    //float max = node.ModelSize.max();
        //    //node.Scale *= 16.0f / max;
        //    //node.WorldPosition = new vec3(0, 0, 0);
        //    rootElement.Children.Add(node);
        //}

        //private void CreateDummyNodes(string filename)
        //{
        //    var random = new Random();
        //    EZMFile ezmFile = EZMFile.Load(filename);
        //    var rootElement = this.scene.RootNode;
        //    var mesh = ezmFile.MeshSystem.Meshes[0];
        //    byte[] positionBuffer = mesh.Vertexbuffer.Buffers[0].array;
        //    for (int i = 0; i < mesh.MeshSections.Length; i++)
        //    {
        //        var model = new EZMDummyModel(positionBuffer,
        //            mesh.MeshSections[i].Indexbuffer
        //            );
        //        var node = EZMDummyNode.Create(model);
        //        node.Color = Color.FromArgb(
        //            (byte)random.Next(0, 256),
        //            (byte)random.Next(0, 256),
        //            (byte)random.Next(0, 256),
        //            (byte)random.Next(0, 256)
        //            );
        //        //float max = node.ModelSize.max();
        //        //node.Scale *= 16.0f / max;
        //        //node.WorldPosition = new vec3(0, 0, 0);
        //        rootElement.Children.Add(node);
        //    }
        //}
    }
}
