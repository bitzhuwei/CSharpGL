using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace c14d03_ParticleSystem
{
    public partial class FormMain : Form
    {
        private Scene scene;
        private ActionList actionList;

        public FormMain()
        {
            InitializeComponent();

            this.winGLCanvas1.TimerTriggerInterval = 1 + (int)(1000.0f / 60.0f);
            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var position = new vec3(5, 3, 4) * 0.2f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);

            this.scene = new Scene(camera);
            this.scene.ClearColor = Color.Black.ToVec4();
            {
                var node = ParticleNode.Create(1000);
                var ground = GroundNode.Create();
                ground.RenderUnit.Methods[0].SwitchList.Add(new PolygonModeSwitch(PolygonMode.Line));
                ground.EnableRendering = ThreeFlags.None;
                var group = new GroupNode(node, ground);
                this.scene.RootNode = group;
            }

            var list = new ActionList();
            var transformAction = new TransformAction(scene.RootNode);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.winGLCanvas1);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            //IWorldSpace node = this.scene.RootElement;
            //if (node != null)
            //{
            //    node.RotationAngle += 1;
            //}
        }
    }
}
