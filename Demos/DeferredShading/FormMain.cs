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
        private SceneNodeBase regularNode;
        private SceneNodeBase deferredShadingNode;

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
            this.scene = new Scene(camera)
;
            this.scene.RootElement = GetRootElement();
            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.winGLCanvas1);
            manipulater.StepLength = 1f;
        }

        private SceneNodeBase GetRootElement()
        {
            int lengthX = 50;
            int lengthY = 40;
            int lengthZ = 30;
            float scale = 1.5f;
            var model = new ManyCubesModel((int)(lengthX * scale), (int)(lengthY * scale), (int)(lengthZ * scale));

            var manyCubesNode = ManyCubesNode.Create(model);
            var deferredShadingNode = new DeferredShadingNode();
            deferredShadingNode.Children.Add(manyCubesNode);
            var fullScreenNode = FullScreenNode.Create(deferredShadingNode as ITextureSource);
            var groupNode = new GroupNode(deferredShadingNode, fullScreenNode);

            this.deferredShadingNode = groupNode;

            var manyCubesNode0 = ManyCubesNode0.Create(model);
            this.regularNode = manyCubesNode0;

            return groupNode;
        }

        private void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            ActionList list = this.actionList;
            if (list != null)
            {
                list.Act(new ActionParams(Viewport.GetCurrent()));
            }
        }

        void winGLCanvas1_Resize(object sender, EventArgs e)
        {
            if (this.scene != null)
            {
                this.scene.Camera.AspectRatio = ((float)this.winGLCanvas1.Width) / ((float)this.winGLCanvas1.Height);
            }
        }

        private void chkDeferredShading_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkDeferredShading.Checked)
            {
                this.scene.RootElement = this.deferredShadingNode;
            }
            else
            {
                this.scene.RootElement = this.regularNode;
            }
        }

    }
}
