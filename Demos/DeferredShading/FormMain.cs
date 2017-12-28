using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DeferredShading
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
            var position = new vec3(5, 4, 3) * 20;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            this.scene = new Scene(camera, this.winGLCanvas1);
            this.scene.RootElement = GetRootElement();
            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.winGLCanvas1);
            manipulater.StepLength = 0.1f;
        }

        //private SceneNodeBase GetRootElement()
        //{
        //    var manyCubesNode = ManyCubesNode.Create(100, 80, 60);

        //    return manyCubesNode;
        //}
        private SceneNodeBase GetRootElement()
        {
            var manyCubesNode = ManyCubesNode.Create(50, 40, 30);
            var deferredShadingNode = new DeferredShadingNode();
            deferredShadingNode.Children.Add(manyCubesNode);
            var fullScreenNode = FullScreenNode.Create(deferredShadingNode as ITextureSource);
            var groupNode = new GroupNode(deferredShadingNode, fullScreenNode);

            return groupNode;
        }
        private void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            ActionList list = this.actionList;
            if (list != null)
            {
                list.Act();
            }
        }

        void winGLCanvas1_Resize(object sender, EventArgs e)
        {
            if (this.scene != null)
            {
                this.scene.Camera.AspectRatio = ((float)this.winGLCanvas1.Width) / ((float)this.winGLCanvas1.Height);
            }
        }

    }
}
