using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RenderToTexture
{
    public partial class FormMain : Form
    {
        private Scene scene;
        private ActionList actionList;
        //private LegacyRectangleRenderer rectangle;//LegacyRectangleRenderer dosen't work in rendering-to-texture.
        private TeapotNode teapot;
        private RenderToTexttureNode rtt;
        private RectangleNode rectangle;
        public FormMain()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var teapot = TeapotNode.Create();
            this.teapot = teapot;

            int width = 400, height = 200;
            var rtt = new RenderToTexttureNode(width, height, new Camera(new vec3(0, 0, 5), new vec3(0, 0, 0), new vec3(0, 1, 0), CameraType.Perspecitive, width, height), new ColoredFramebufferProvider());
            rtt.Children.Add(teapot);// rendered to framebuffer, then to texture.
            this.rtt = rtt;

            var rectangle = RectangleNode.Create();
            //var rectangle = new LegacyRectangleRenderer();//LegacyRectangleRenderer dosen't work in rendering-to-texture.
            rectangle.TextureSource = rtt;
            rectangle.Scale = new vec3(7, 7, 7);
            this.rectangle = rectangle;

            var group = new GroupNode();
            group.Children.Add(rtt);
            group.Children.Add(rectangle);

            var position = new vec3(5, 1, 4);
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            this.scene = new Scene(camera)

            {
                ClearColor = Color.SkyBlue.ToVec4(),
                RootElement = group,
            };

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

                list.Act(new ActionParams(Viewport.GetCurrent()));
            }
        }

        void winGLCanvas1_Resize(object sender, EventArgs e)
        {
            this.scene.Camera.AspectRatio = ((float)this.winGLCanvas1.Width) / ((float)this.winGLCanvas1.Height);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.rotateRect)
            {
                IWorldSpace node = this.rectangle;
                if (node != null)
                {
                    node.RotationAngle += 1;
                }
            }

            if (this.rotateTeapot)
            {
                IWorldSpace node = this.teapot;
                if (node != null)
                {
                    node.RotationAngle += 10;
                }
            }
        }

        private bool rotateRect = true;
        private bool rotateTeapot = true;
        private void chkRotateRect_CheckedChanged(object sender, EventArgs e)
        {
            this.rotateRect = this.chkRotateRect.Checked;
        }

        private void chkRotateTeapot_CheckedChanged(object sender, EventArgs e)
        {
            this.rotateTeapot = this.chkRotateTeapot.Checked;
        }

        private void chkTransparentBackground_CheckedChanged(object sender, EventArgs e)
        {
            this.rectangle.TransparentBackground = this.chkRenderBackground.Checked;
        }
    }
}
