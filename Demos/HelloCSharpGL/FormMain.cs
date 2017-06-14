using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSharpGL;

namespace HelloCSharpGL
{
    public partial class FormMain : Form
    {
        Scene scene;

        public FormMain()
        {
            InitializeComponent();
        }

        private void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            this.scene.Render();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var camera = new Camera(new vec3(5, 3, 4), new vec3(0, 0, 0), new vec3(0, 1, 0), CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            this.scene = new Scene()
            {
                Camera = camera,
                ClearColor = Color.SkyBlue,
            };
        }
    }
}
