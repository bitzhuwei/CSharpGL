using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RenderToTexture
{
    public partial class FormMain : Form
    {
        private Scene scene;
        //private LegacyRectangleRenderer rectangle;//LegacyRectangleRenderer dosen't work in rendering-to-texture.
        private TeapotRenderer teapot;
        private RTTRenderer rtt;
        private RectangleRenderer rectangle;
        public FormMain()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var teapot = TeapotRenderer.Create();
            this.teapot = teapot;

            int width = 400, height = 200;
            var rtt = new RTTRenderer(width, height, new Camera(new vec3(0, 0, 5), new vec3(0, 0, 0), new vec3(0, 1, 0), CameraType.Perspecitive, width, height));
            rtt.Children.Add(teapot);// rendered to framebuffer, then to texture.
            this.rtt = rtt;

            var rectangle = RectangleRenderer.Create();
            //var rectangle = new LegacyRectangleRenderer();//LegacyRectangleRenderer dosen't work in rendering-to-texture.
            rectangle.TextureSource = rtt;
            rectangle.Scale = new vec3(7, 7, 7);
            this.rectangle = rectangle;

            var group = new GroupRenderer();
            group.Children.Add(rtt);
            group.Children.Add(rectangle);

            var position = new vec3(5, 1, 4);
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            this.scene = new Scene(camera, this.winGLCanvas1)
            {
                ClearColor = Color.SkyBlue.ToVec4(),
                RootElement = group,
            };

        }

        private void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            Scene scene = this.scene;
            if (scene != null)
            {
                scene.Render();
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
                IWorldSpace renderer = this.rectangle;
                if (renderer != null)
                {
                    renderer.RotationAngle += 1;
                }
            }

            if (this.rotateTeapot)
            {
                IWorldSpace renderer = this.teapot;
                if (renderer != null)
                {
                    renderer.RotationAngle += 10;
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
            this.rtt.TransparentBackground = this.chkRenderBackground.Checked;
        }
    }
}
