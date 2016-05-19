using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form09TextBoxRenderer : Form
    {

        private Camera camera;
        private SatelliteRotator rotator;
        private DummyTextBoxRenderer renderer;


        public Form09TextBoxRenderer()
        {
            InitializeComponent();

            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
            this.glCanvas1.Resize += glCanvas1_Resize;

            GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

            RenderEventArgs arg = new RenderEventArgs(RenderModes.Render, this.glCanvas1.ClientRectangle, this.camera);
            IRenderable renderer = this.renderer;
            if (renderer != null)
            {
                mat4 projection, view, model;
                {
                    this.uiRenderer.GetMatrix(out projection, out view, out model, arg.Camera);
                    this.uiRenderer.Renderer.SetUniformValue("projectionMatrix", projection);
                    this.uiRenderer.Renderer.SetUniformValue("viewMatrix", view);
                    this.uiRenderer.Renderer.SetUniformValue("modelMatrix", model);
                    this.uiRenderer.Render(arg);
                }

                if (this.useUILayout)
                {
                    this.renderer.GetMatrix(out projection, out view, out model, arg.Camera);
                    this.renderer.SetUniformValue("mvp", projection * view * model);
                }
                else
                {
                    projection = arg.Camera.GetProjectionMat4();
                    view = arg.Camera.GetViewMat4();
                    model = mat4.identity();
                    this.renderer.SetUniformValue("mvp", projection * view * model);
                }

                renderer.Render(arg);
            }

            // Cross cursor shows where the mouse is.
            GL.DrawText(this.lastMousePosition.X - offset.X,
                this.glCanvas1.Height - (this.lastMousePosition.Y + offset.Y) - 1,
                Color.Red, "Courier New", crossCursorSize, "o");
        }


        private const float crossCursorSize = 40.0f;

        private Point offset = new Point(13, 11);
        private bool useUILayout;

        void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            ICamera camera = this.camera;
            if (camera != null)
            {
                camera.MouseWheel(e.Delta);
            }
        }

        private void glCanvas1_Resize(object sender, EventArgs e)
        {
            if (camera != null)
            {
                camera.Resize(this.glCanvas1.Width, this.glCanvas1.Height);
            }
        }

        private void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'c')
            {
                this.useUILayout = !this.useUILayout;
            }
        }

    }
}
