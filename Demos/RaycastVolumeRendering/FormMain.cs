using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RaycastVolumeRendering
{
    public partial class FormMain : Form
    {
        private Scene scene;
        private ActionList actionList;

        private PickingAction pickingAction;
        private LegacyTriangleNode triangleTip;
        private LegacyQuadNode quadTip;

        public FormMain()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;

            // picking events
            this.winGLCanvas1.MouseDown += glCanvas1_MouseDown;
            this.winGLCanvas1.MouseMove += glCanvas1_MouseMove;
            this.winGLCanvas1.MouseUp += glCanvas1_MouseUp;
            this.winGLCanvas1.MouseWheel += winGLCanvas1_MouseWheel;
        }

        void winGLCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            var scene = this.scene;
            if (scene != null)
            {
                scene.Camera.MouseWheel(e.Delta);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var position = new vec3(5, 3, 4) * 0.2f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);

            this.scene = new Scene(camera)
;
            {
                var manipulater = new ArcBallManipulater(GLMouseButtons.Right);
                manipulater.Bind(camera, this.winGLCanvas1);
                var node = RaycastNode.Create();
                node.BindManipulater(manipulater);
                this.scene.RootElement = node;
            }

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            this.pickingAction = new PickingAction(scene);

            this.triangleTip = new LegacyTriangleNode();
            this.quadTip = new LegacyQuadNode();

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
            this.scene.Camera.AspectRatio = ((float)this.winGLCanvas1.Width) / ((float)this.winGLCanvas1.Height);
        }

    }
}
