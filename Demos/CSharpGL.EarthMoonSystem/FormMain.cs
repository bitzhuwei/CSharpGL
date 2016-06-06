using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.EarthMoonSystem
{
    public partial class FormMain : Form
    {

        private Camera camera;
        private SatelliteRotator rotator;
        private PickableRenderer earthRenderer;
        private sampler2D earthColorTexture;
        public Color ClearColor { get; set; }

        public FormMain()
        {
            InitializeComponent();


            this.Load += FormMain_Load;
            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
            this.glCanvas1.Resize += glCanvas1_Resize;
        }

        void glCanvas1_Resize(object sender, EventArgs e)
        {
            Camera camera = this.camera;
            Control control = sender as Control;
            if (camera != null)
            {
                camera.Resize(control.Width, control.Height);
            }
        }

        void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            // set background color.
            OpenGL.ClearColor(ClearColor.R / 255.0f, ClearColor.G / 255.0f, ClearColor.B / 255.0f, ClearColor.A / 255.0f);

            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            var arg = new RenderEventArgs(RenderModes.Render, this.glCanvas1.ClientRectangle, this.camera);

            mat4 projection = this.camera.GetProjectionMat4();
            mat4 view = this.camera.GetViewMat4();
            mat4 model = new mat4(1.0f);
            this.earthRenderer.SetUniform("projectionMatrix", projection);
            this.earthRenderer.SetUniform("viewMatrix", view);
            this.earthRenderer.SetUniform("modelMatrix", model);
            this.earthRenderer.Render(arg);
        }

    }
}
