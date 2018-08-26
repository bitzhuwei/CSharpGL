using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace c03d06_FragCoord
{
    public partial class Form1 : Form
    {
        private Scene scene;
        private ActionList actionList;
        private RectNode rectNode;

        public Form1()
        {
            InitializeComponent();

            // init resources.
            this.Load += FormMain_Load;
            // render event.
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            // resize event.
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;

            this.winGLCanvas1.MouseMove += winGLCanvas1_MouseMove;
        }

        void winGLCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X, y = this.winGLCanvas1.Height - e.Y - 1;
            Color color = GetColorAtMouse(x, y);
            this.lblInfo.Text = string.Format("Color at Mouse: {0}", color);
        }


        private Color GetColorAtMouse(int x, int y)
        {
            byte[] colors = new byte[4];
            GL.Instance.ReadPixels(x, y, 1, 1, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, colors);
            Color c = Color.FromArgb(colors[3], colors[0], colors[1], colors[2]);

            return c;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var position = new vec3(5, 3, 4) * 0.5f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            int width = this.winGLCanvas1.Width, height = this.winGLCanvas1.Height;
            this.rectNode = RectNode.Create(0, 0, width, height);
            var scene = new Scene(camera);
            scene.RootNode = rectNode;
            this.scene = scene;

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

        }

        private void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            ActionList list = this.actionList;
            if (list != null)
            {
                vec4 clearColor = this.scene.ClearColor;
                GL.Instance.ClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                int width = this.winGLCanvas1.Width, height = this.winGLCanvas1.Height;
                //    var scissor = new int[4];
                //    var viewport = new int[4];
                //    GL.Instance.GetIntegerv((uint)GetTarget.ScissorBox, scissor);
                //    GL.Instance.GetIntegerv((uint)GetTarget.Viewport, viewport);

                Viewport viewport = Viewport.GetCurrent();
                list.Act(new ActionParams(viewport));

                // Reset viewport.
                GL.Instance.Scissor(0, 0, width, height);
                GL.Instance.Viewport(0, 0, width, height);

            }
        }

        void winGLCanvas1_Resize(object sender, EventArgs e)
        {
            this.scene.Camera.AspectRatio = ((float)this.winGLCanvas1.Width) / ((float)this.winGLCanvas1.Height);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //this.cubeNode.RotationAxis = new vec3(0, 1, 0);
            //this.rectNode.RotationAngle += 7f;
        }
    }
}
