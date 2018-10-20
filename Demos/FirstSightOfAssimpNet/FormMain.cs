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
            manipulater.StepLength = 10;

            var rootElement = this.scene.RootNode;
            rootElement.Children.Clear();
            string filename = @"skull.obj_";
            CreateDummyNodes(filename);
            //CreateTextureNode(filename);
            //CreateBoneNode(filename);
            //CreateDualQuatNode(filename);

        }

        private void CreateDummyNodes(string filename)
        {
            var importer = new Assimp.AssimpImporter();
            Assimp.Scene aiScene = importer.ImportFile(filename);
            if (aiScene == null) { return; }
            var rootElement = this.scene.RootNode;
            var random = new Random();
            foreach (Assimp.Mesh mesh in aiScene.Meshes)
            {
                var model = new PositionModel(mesh);
                var node = PositionNode.Create(model);
                node.Color = Color.FromArgb(
                    (byte)random.Next(0, 256),
                    (byte)random.Next(0, 256),
                    (byte)random.Next(0, 256),
                    (byte)random.Next(0, 256)
                    );
                rootElement.Children.Add(node);
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

    }
}
