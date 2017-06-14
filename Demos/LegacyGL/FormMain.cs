using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LegacyGL
{
    public partial class FormMain : Form
    {
        private Scene scene;
        public FormMain()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
        }

        void FormMain_Load(object sender, EventArgs e)
        {
            var camera = new Camera(new vec3(5, 3, 4), new vec3(0, 0, 0), new vec3(0, 1, 0), CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            this.scene = new Scene()
            {
                Camera = camera,
                ClearColor = Color.SkyBlue,
            };
        }

        void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            this.scene.Render();
        }
    }
}
