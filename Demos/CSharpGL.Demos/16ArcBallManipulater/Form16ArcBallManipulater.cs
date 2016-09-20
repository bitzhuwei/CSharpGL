using System;
using System.Drawing;

using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form16ArcBallManipulater : Form
    {
        private Camera camera;
        private SatelliteManipulater cameraManipulater;

        public Form16ArcBallManipulater()
        {
            InitializeComponent();

            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            //this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            //this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            //this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            //this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
            this.glCanvas1.Resize += glCanvas1_Resize;
            this.glCanvas1.KeyPress += glCanvas1_KeyPress;

            Application.Idle += Application_Idle;
            OpenGL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
        }

        private void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '2')
            {
                var frmPropertyGrid = new FormProperyGrid(this.glCanvas1);
                frmPropertyGrid.Show();
            }
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} - FPS: {1}", this.GetType().Name, this.glCanvas1.FPS.ToShortString());
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            RenderEventArgs arg = new RenderEventArgs(RenderModes.Render, this.glCanvas1.ClientRectangle, this.camera);

            {
                mat4 projection = arg.Camera.GetProjectionMatrix();
                mat4 view = arg.Camera.GetViewMatrix();
                mat4 model = this.arcballManipulater.GetRotationMatrix();
                this.teapotRenderer.SetUniform("projectionMatrix", projection);
                this.teapotRenderer.SetUniform("viewMatrix", view);
                this.teapotRenderer.SetUniform("modelMatrix", model);
                this.teapotRenderer.Render(arg);
            }
            {
                this.ground.Render(arg);
            }
            {
                UIRoot uiRoot = this.uiRoot;
                if (uiRoot != null)
                {
                    uiRoot.Render(arg);
                }
            }

            Point mousePosition = this.glCanvas1.PointToClient(Control.MousePosition);
            // Cross cursor shows where the mouse is.
            OpenGL.DrawText(mousePosition.X - offset.X,
                this.glCanvas1.Height - (mousePosition.Y + offset.Y) - 1,
                Color.Red, "Courier New", crossCursorSize, "o");
        }

        private vec3 position = new vec3(0, 0, 0);

        private const float crossCursorSize = 40.0f;

        private Point offset = new Point(13, 11);

        private void glCanvas1_Resize(object sender, EventArgs e)
        {
            if (camera != null)
            {
                camera.Resize(this.glCanvas1.Width, this.glCanvas1.Height);
            }

            this.uiRoot.Size = this.glCanvas1.Size;
        }
    }
}