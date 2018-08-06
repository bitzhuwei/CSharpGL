using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSharpGL;

namespace c15d01_ParticleSystem2
{
    public partial class Form1 : Form
    {
        private Scene scene;
        private ActionList actionList;

        public Form1()
        {
            InitializeComponent();

            this.winGLCanvas1.TimerTriggerInterval = 1 + (int)(1000.0f / 60.0f);
            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
            this.winGLCanvas1.KeyPress += winGLCanvas1_KeyPress;
        }

        void winGLCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'p')
            {
                if (this.stopped)
                {
                    this.particleNode.Stopped = stopped;
                    this.stopped = false;
                }
                else
                {
                    this.particleNode.Stopped = stopped;
                    this.stopped = true;
                }
            }
            else if (e.KeyChar == 'b')
            {
                if (this.attractorsNode.EnableRendering == ThreeFlags.None)
                {
                    this.attractorsNode.EnableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
                }
                else
                {
                    this.attractorsNode.EnableRendering = ThreeFlags.None;
                }
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var position = new vec3(5, 3, 4) * 1.6f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);

            this.scene = new Scene(camera);
            this.scene.ClearColor = Color.Black.ToVec4();
            {
                var particlesNode = ParticlesNode.Create(10000);
                this.particleNode = particlesNode;
                var attractorsNode = AttractorsNode.Create(particlesNode);
                this.attractorsNode = attractorsNode;
                var cubeNode = CubeNode.Create();
                cubeNode.RenderUnit.Methods[0].SwitchList.Add(new PolygonModeSwitch(PolygonMode.Line));
                var groupNode = new GroupNode(particlesNode, attractorsNode);//, cubeNode);
                this.scene.RootNode = groupNode;
            }

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
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

        private bool stopped = false;
        private ParticlesNode particleNode;
        private AttractorsNode attractorsNode;

    }
}
