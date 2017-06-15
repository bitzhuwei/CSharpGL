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
using CSharpGL.Models;

namespace DemoPLY
{
    public partial class Form1 : Form
    {
        Scene scene;
        private PLYRenderer renderer;

        public Form1()
        {
            InitializeComponent();

            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.MouseWheel += winGLCanvas1_MouseWheel;
            this.Load += Form1_Load;

        }

        void Form1_Load(object sender, EventArgs e)
        {
            var position = new vec3(5, 3, 4) / 1.0f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            this.scene = new Scene(camera, this.winGLCanvas1);

            {
                var model = new PLYModel(@"2.ply.txt");
                var renderer = PLYRenderer.Create(model);
                renderer.Scale *= 20;
                this.scene.RootElement = renderer;
                this.renderer = renderer;
            }
        }

        private void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            this.scene.Render();
        }

        void winGLCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            //if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                IWorldSpace renderer = this.renderer;
                if (renderer != null)
                {
                    renderer.Scale += new vec3(1, 1, 1) * 0.01f * e.Delta;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            IWorldSpace renderer = this.renderer;
            if (renderer != null)
            {
                renderer.RotationAngle += 11;
            }
        }
    }
}
