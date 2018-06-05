using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VolumeRendering.Raycast
{
    public partial class FormMain : Form
    {
        private Scene scene;
        private ActionList actionList;

        private Picking pickingAction;
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
                var manipulater = new ArcBallManipulater(GLMouseButtons.Left | GLMouseButtons.Right);
                manipulater.Bind(camera, this.winGLCanvas1);
                manipulater.Rotated += manipulater_Rotated;
                var node = RaycastNode.Create();
                this.scene.RootNode = node;
                (new FormProperyGrid(node)).Show();
            }

            var list = new ActionList();
            var transformAction = new TransformAction(scene.RootNode);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            this.pickingAction = new Picking(scene);

            this.triangleTip = new LegacyTriangleNode();
            this.quadTip = new LegacyQuadNode();

        }

        void manipulater_Rotated(object sender, ArcBallManipulater.Rotation e)
        {
            SceneNodeBase node = this.scene.RootNode;
            node.RotationAngle = e.angleInDegree;
            node.RotationAxis = e.axis;
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
