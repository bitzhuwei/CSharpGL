using System;

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

        private void Application_Idle(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} - FPS: {1}", this.GetType().Name, this.glCanvas1.FPS.ToShortString());
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            //OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            //Point mousePosition = this.glCanvas1.PointToClient(Control.MousePosition);
            this.scene.Render();//, mousePosition);
        }

        private void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            const float deltaDistance = 0.1f;
            ICamera camera = this.scene.FirstCamera;

            if (e.KeyChar == 'w')
            {
                vec3 front = camera.GetFront();
                front.y = 0;
                this.position += deltaDistance * front.normalize();
                SetDirection(this.movableRenderer, front);
            }
            else if (e.KeyChar == 's')
            {
                vec3 back = camera.GetBack();
                back.y = 0;
                this.position += deltaDistance * back.normalize();
                SetDirection(this.movableRenderer, back);
            }
            else if (e.KeyChar == 'a')
            {
                vec3 left = camera.GetLeft();
                left.y = 0;
                this.position += deltaDistance * left.normalize();
                SetDirection(this.movableRenderer, left);
            }
            else if (e.KeyChar == 'd')
            {
                vec3 right = camera.GetRight();
                right.y = 0;
                this.position += deltaDistance * right.normalize();
                SetDirection(this.movableRenderer, right);
            }
            else if (e.KeyChar == 'r')
            {
                this.position = new vec3(0, 0, 0);
            }

            this.movableRenderer.SetWorldPosition(this.position);

            this.lblCubePosition.Text = string.Format("Cube Pos: {0}", this.position);
        }


        internal void SetDirection(IRenderable renderer, vec3 direction)
        {
            direction.y = 0;
            direction = direction.normalize();
            float cosRadian = direction.dot(new vec3(1, 0, 0));// (1, 0, 0) is teapot's default direction.
            float radian = (float)Math.Acos(cosRadian);
            if (direction.z > 0) { radian = -radian; }
            renderer.RotationAngleDegree = (float)(radian * 180.0 / Math.PI);
        }
    }
}