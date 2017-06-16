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

        public FormMain()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
            this.winGLCanvas1.MouseClick += winGLCanvas1_MouseClick;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var position = new vec3(5, 3, 4);
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Ortho, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            var propeller = new LegacyPropellerRenderer();
            this.scene = new Scene(camera, this.winGLCanvas1)
            {
                RootElement = propeller,
            };
        }

        private void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            this.scene.Render();
        }

        void winGLCanvas1_Resize(object sender, EventArgs e)
        {
            this.scene.Camera.AspectRatio = ((float)this.winGLCanvas1.Width) / ((float)this.winGLCanvas1.Height);
        }

        /// <summary>
        /// click to pick and toggle the render wireframe state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void winGLCanvas1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = this.winGLCanvas1.Height - e.Y - 1;
            List<RendererBase> list = this.scene.Pick(x, y);
            foreach (var item in list)
            {
                var renderer = item as IRenderWireframe;
                if (renderer != null)
                {
                    renderer.RenderWireframe = !renderer.RenderWireframe;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            IWorldSpace renderer = this.scene.RootElement;
            if (renderer != null)
            {
                renderer.RotationAngle += 1;
            }
        }
    }
}
