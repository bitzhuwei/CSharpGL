using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultipleContexts
{
    public partial class Form1 : Form
    {
        private CubeNode cubeNode1;
        private ActionList actionList1;
        private Scene scene1;

        private CubeNode cubeNode2;
        private ActionList actionList2;
        private Scene scene2;

        public Form1()
        {
            InitializeComponent();

            // init resources.
            this.Load += FormMain_Load;
            // render event.
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            // resize event.
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
            // render event.
            this.winGLCanvas2.OpenGLDraw += winGLCanvas2_OpenGLDraw;
            // resize event.
            this.winGLCanvas2.Resize += winGLCanvas2_Resize;
        }

        private void winGLCanvas2_Resize(object sender, EventArgs e)
        {
            this.scene2.Camera.AspectRatio = ((float)this.winGLCanvas2.Width) / ((float)this.winGLCanvas2.Height);
        }

        private void winGLCanvas2_OpenGLDraw(object sender, PaintEventArgs e)
        {
            var canvas = sender as WinGLCanvas;
            canvas.MakeCurrent();
            ActionList list = this.actionList2;
            if (list != null)
            {
                vec4 clearColor = this.scene2.ClearColor;
                GL.Instance.ClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                Viewport viewport = Viewport.GetCurrent();
                list.Act(new ActionParams(viewport));
            }
        }
        private void winGLCanvas1_Resize(object sender, EventArgs e)
        {
            this.scene1.Camera.AspectRatio = ((float)this.winGLCanvas1.Width) / ((float)this.winGLCanvas1.Height);
        }

        private void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            var canvas = sender as WinGLCanvas;
            canvas.MakeCurrent();
            ActionList list = this.actionList1;
            if (list != null)
            {
                vec4 clearColor = this.scene1.ClearColor;
                GL.Instance.ClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                Viewport viewport = Viewport.GetCurrent();
                list.Act(new ActionParams(viewport));
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var thread = System.Threading.Thread.CurrentThread;
            {
                this.winGLCanvas1.MakeCurrent();
                var position = new vec3(5, 3, 4) * 0.5f;
                var center = new vec3(0, 0, 0);
                var up = new vec3(0, 1, 0);
                var camera = new Camera(position, center, up, CameraType.Perspective, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
                this.cubeNode1 = CubeNode.Create();
                var scene = new Scene(camera);
                scene.RootNode = cubeNode1;
                this.scene1 = scene;

                var list = new ActionList();
                var transformAction = new TransformAction(scene);
                list.Add(transformAction);
                var renderAction = new RenderAction(scene);
                list.Add(renderAction);
                this.actionList1 = list;

                //// uncomment these lines to enable manipualter of camera!
                //var manipulater = new FirstPerspectiveManipulater();
                //manipulater.BindingMouseButtons = System.Windows.Forms.MouseButtons.Right;
                //manipulater.Bind(camera, this.winGLCanvas1);
            }
            {
                this.winGLCanvas2.MakeCurrent();
                var position = new vec3(5, 3, 4) * 0.5f;
                var center = new vec3(0, 0, 0);
                var up = new vec3(0, 1, 0);
                var camera = new Camera(position, center, up, CameraType.Perspective, this.winGLCanvas2.Width, this.winGLCanvas2.Height);
                this.cubeNode2 = CubeNode.Create();
                var scene = new Scene(camera);
                scene.RootNode = cubeNode2;
                this.scene2 = scene;

                var list = new ActionList();
                var transformAction = new TransformAction(scene);
                list.Add(transformAction);
                var renderAction = new RenderAction(scene);
                list.Add(renderAction);
                this.actionList2 = list;

                //// uncomment these lines to enable manipualter of camera!
                //var manipulater = new FirstPerspectiveManipulater();
                //manipulater.BindingMouseButtons = System.Windows.Forms.MouseButtons.Right;
                //manipulater.Bind(camera, this.winGLCanvas1);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.cubeNode1.RotationAxis = new vec3(0, 1, 0);
            this.cubeNode1.RotationAngle += 7f;

            this.cubeNode2.RotationAxis = new vec3(0, 1, 0);
            this.cubeNode2.RotationAngle += 7f;
        }
    }
}
