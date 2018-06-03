using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSharpGL;

namespace c11d00_Arcball
{
    public partial class FormModel : Form
    {
        private Scene scene;
        private ActionList actionList;

        public FormModel()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
            this.winGLCanvas1.MouseWheel += winGLCanvas1_MouseWheel;
        }

        void winGLCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            this.scene.Camera.MouseWheel(e.Delta);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var position = new vec3(5, 3, 4);
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            this.scene = new Scene(camera);
            this.scene.RootNode = GetRootNode();

            var list = new ActionList();
            list.Add(new TransformAction(scene.RootNode));
            list.Add(new RenderAction(scene));
            this.actionList = list;

            //var manipulater = new FirstPerspectiveManipulater();
            //manipulater.Bind(camera, this.winGLCanvas1);

            var manipulater = new ArcBallManipulater(GLMouseButtons.Left);
            manipulater.Bind(camera, this.winGLCanvas1);
            manipulater.Rotated += manipulater_Rotated;

            var frmArcball = new FormArcball(camera, manipulater);
            frmArcball.Show();
        }

        void manipulater_Rotated(object sender, ArcBallManipulater.Rotation e)
        {
            {
                SceneNodeBase node = this.scene.RootNode;
                if (node != null)
                {
                    node.RotationAngle = e.angleInDegree;
                    node.RotationAxis = e.axis;
                }
            }
        }

        private SceneNodeBase GetRootNode()
        {
            TeapotNode node = TeapotNode.Create();
            node.RenderWireframe = false;
            //(new FormProperyGrid(node)).Show();
            return node;
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
