using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSharpGL;
using CSharpGL.Models;

namespace HelloCSharpGL
{
    public partial class FormMain : Form
    {
        Scene scene;
        private ProperllerRenderer properller;

        public FormMain()
        {
            InitializeComponent();

            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
        }

        private void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            this.scene.Render();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var position = new vec3(0, 0, 4);
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            var properller = new ProperllerRenderer() { WorldPosition = new vec3(0, -1f, 0) };
            var group = new RendererGroup(new ClockRenderer(new vec3()), properller);
            this.scene = new Scene(camera, this.winGLCanvas1)
            {
                RootElement = group,
            };

            this.properller = properller;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            IWorldSpace renderer = this.properller;
            if (renderer != null)
            {
                renderer.RotationAngle += 11;
            }
        }
    }
}
