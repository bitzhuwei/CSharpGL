using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form12Billboard : Form
    {
        private vec3 position;

        public Form12Billboard()
        {
            InitializeComponent();

            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;

            Application.Idle += Application_Idle;
            OpenGL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
        }

        void Application_Idle(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} - FPS: {1}", this.GetType().Name, this.glCanvas1.FPS.ToShortString());
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            this.scene.Render(RenderModes.Render, this.glCanvas1.ClientRectangle, this.glCanvas1.PointToClient(Control.MousePosition));
        }

        private void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            const float deltaDistance = 0.1f;
            ICamera camera = this.scene.Camera;

            if (e.KeyChar == 'w')
            {
                vec3 front = camera.GetFront();
                front.y = 0;
                this.position += deltaDistance * front.normalize();
                this.movableRenderer.SetDirection(front);
            }
            else if (e.KeyChar == 's')
            {
                vec3 back = camera.GetBack();
                back.y = 0;
                this.position += deltaDistance * back.normalize();
                this.movableRenderer.SetDirection(back);
            }
            else if (e.KeyChar == 'a')
            {
                vec3 left = camera.GetLeft();
                left.y = 0;
                this.position += deltaDistance * left.normalize();
                this.movableRenderer.SetDirection(left);
            }
            else if (e.KeyChar == 'd')
            {
                vec3 right = camera.GetRight();
                right.y = 0;
                this.position += deltaDistance * right.normalize();
                this.movableRenderer.SetDirection(right);
            }
            else if (e.KeyChar == 'r')
            {
                this.position = new vec3(0, 0, 0);
            }

            this.movableRenderer.WorldPosition = this.position;

            this.lblCubePosition.Text = string.Format("Cube Pos: {0}", this.position);
        }


    }

}
