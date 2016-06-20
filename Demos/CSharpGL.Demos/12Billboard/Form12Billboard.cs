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
    public partial class Form12Billboard : Form
    {

        private Camera camera;
        private SatelliteRotator rotator;


        public Form12Billboard()
        {
            InitializeComponent();

            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
            this.glCanvas1.Resize += glCanvas1_Resize;

            OpenGL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            RenderEventArgs arg = new RenderEventArgs(RenderModes.Render, this.glCanvas1.ClientRectangle, this.camera);

            {
                this.movableRenderer.Render(arg);
            }
            {
                this.ground.Render(arg);
            }
            {
                this.billboardRenderer.Render(arg);
            }
            {
                this.labelRenderer.WorldPosition = this.movableRenderer.Position + new vec3(0, 0.6f, 0);
                this.labelRenderer.Render(arg);
            }
            {
                UIRenderersDraw(arg);
            }

            // Cross cursor shows where the mouse is.
            OpenGL.DrawText(this.lastMousePosition.X - offset.X,
                this.glCanvas1.Height - (this.lastMousePosition.Y + offset.Y) - 1,
                Color.Red, "Courier New", crossCursorSize, "o");
        }

        vec3 position = new vec3(0, 0, 0);


        private const float crossCursorSize = 40.0f;

        private Point offset = new Point(13, 11);
        private void UIRenderersDraw(RenderEventArgs arg)
        {
            GLControl uiRoot = this.uiRoot;
            if (uiRoot != null)
            {
                uiRoot.Layout();
                mat4 projection, view, model;
                {
                    projection = glAxis.GetOrthoProjection();
                    vec3 position = (this.camera.Position - this.camera.Target).normalize();
                    view = glm.lookAt(position, new vec3(0, 0, 0), camera.UpVector);
                    float length = Math.Max(glAxis.Size.Width, glAxis.Size.Height) / 2;
                    model = glm.scale(mat4.identity(),
                        new vec3(length, length, length));
                    glAxis.Renderer.SetUniform("projectionMatrix", projection);
                    glAxis.Renderer.SetUniform("viewMatrix", view);
                    glAxis.Renderer.SetUniform("modelMatrix", model);

                    glAxis.Render(arg);
                }
            }
        }
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

            this.uiRoot.Size = this.glCanvas1.Size;
        }


        private void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            const float deltaDistance = 0.1f;

            if (e.KeyChar == 'w')
            {
                vec3 front = this.camera.GetFront();
                front.y = 0;
                this.position += deltaDistance * front.normalize();
                this.movableRenderer.SetDirection(front);
            }
            else if (e.KeyChar == 's')
            {
                vec3 back = this.camera.GetBack();
                back.y = 0;
                this.position += deltaDistance * back.normalize();
                this.movableRenderer.SetDirection(back);
            }
            else if (e.KeyChar == 'a')
            {
                vec3 left = this.camera.GetLeft();
                left.y = 0;
                this.position += deltaDistance * left.normalize();
                this.movableRenderer.SetDirection(left);
            }
            else if (e.KeyChar == 'd')
            {
                vec3 right = this.camera.GetRight();
                right.y = 0;
                this.position += deltaDistance * right.normalize();
                this.movableRenderer.SetDirection(right);
            }
            else if (e.KeyChar == 'r')
            {
                this.position = new vec3(0, 0, 0);
            }

            this.movableRenderer.Position = this.position;

            this.lblCubePosition.Text = string.Format("Cube Pos: {0}", this.position);
        }

    }

}
