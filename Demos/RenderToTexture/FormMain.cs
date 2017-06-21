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
        public FormMain()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var position = new vec3(5, 3, 4);
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            var teapot = TeapotRenderer.Create();
            var demo = new RenderToTextureRenderer(teapot);

            this.scene = new Scene(camera, this.winGLCanvas1)
            {
                RootElement = demo,
            };
        }

        private void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            Scene scene = this.scene;
            if (scene != null)
            {
                this.scene.Render();
            }
        }

        void winGLCanvas1_Resize(object sender, EventArgs e)
        {
            this.scene.Camera.AspectRatio = ((float)this.winGLCanvas1.Width) / ((float)this.winGLCanvas1.Height);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Scene scene = this.scene;
            if (scene != null)
            {
                IWorldSpace renderer = scene.RootElement;
                if (renderer != null)
                {
                    renderer.RotationAngle += 1;
                }
            }
        }
    }
}
