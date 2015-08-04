using CSharpGL.Objects.Cameras;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.Winforms.Demo
{
    public partial class FormGLCanvas : Form
    {
        //private float rotation;

        //PyramidVAOElement element = new PyramidVAOElement();
        CylinderVAOElement element;// = new CylinderVAOElement(faceCount, radius, height);

        ScientificCamera camera; //= new ScientificCamera(CameraTypes.Ortho);

        SatelliteRotation satelliteRoration;

        /// <summary>
        ///
        /// </summary>
        public FormGLCanvas()
        {
            InitializeComponent();

            this.camera = new ScientificCamera(CameraTypes.Ortho, this.glCanvas1.Width, this.glCanvas1.Height);
            IPerspectiveCamera perspectiveCamera = this.camera;
            perspectiveCamera.FieldOfView = 60f;
            perspectiveCamera.AspectRatio = (double)this.glCanvas1.Width / (double)this.glCanvas1.Height;
            perspectiveCamera.Near = 0.01;
            perspectiveCamera.Far = 10000;

            IOrthoCamera orthoCamera = this.camera;
            orthoCamera.Left = -this.glCanvas1.Width / 2;
            orthoCamera.Right = this.glCanvas1.Width / 2;
            orthoCamera.Bottom = -this.glCanvas1.Height / 2;
            orthoCamera.Top = this.glCanvas1.Height / 2;
            orthoCamera.Near = -10000;
            orthoCamera.Far = 10000;

            satelliteRoration = new SatelliteRotation(camera);

            var faceCount = 18;
            var radius = 1f;
            var height = 3f;
            element = new CylinderVAOElement(camera, radius, height, faceCount);
            element.Initialize();

            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
        }

        private void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            this.camera.Scale(e.Delta);
        }

        private void FormGLCanvas_Load(object sender, EventArgs e)
        {
            // Init GL
            GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            // first resize
            glCanvas1_Resize(this.glCanvas1, e);
        }

        private void glCanvas1_OpenGLDraw(object sender, RenderEventArgs e)
        {
            //  Clear the color and depth buffer.
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            element.Render(Objects.RenderModes.Render);
            ////  Load the identity matrix.
            //GL.LoadIdentity();

            ////  Rotate around the Y axis.
            //GL.Rotate(rotation, 0.0f, 1.0f, 0.0f);

            ////  Draw a coloured pyramid.
            //GL.Begin(GL.GL_TRIANGLES);
            //GL.Color(1.0f, 0.0f, 0.0f);
            //GL.Vertex(0.0f, 1.0f, 0.0f);
            //GL.Color(0.0f, 1.0f, 0.0f);
            //GL.Vertex(-1.0f, -1.0f, 1.0f);
            //GL.Color(0.0f, 0.0f, 1.0f);
            //GL.Vertex(1.0f, -1.0f, 1.0f);
            //GL.Color(1.0f, 0.0f, 0.0f);
            //GL.Vertex(0.0f, 1.0f, 0.0f);
            //GL.Color(0.0f, 0.0f, 1.0f);
            //GL.Vertex(1.0f, -1.0f, 1.0f);
            //GL.Color(0.0f, 1.0f, 0.0f);
            //GL.Vertex(1.0f, -1.0f, -1.0f);
            //GL.Color(1.0f, 0.0f, 0.0f);
            //GL.Vertex(0.0f, 1.0f, 0.0f);
            //GL.Color(0.0f, 1.0f, 0.0f);
            //GL.Vertex(1.0f, -1.0f, -1.0f);
            //GL.Color(0.0f, 0.0f, 1.0f);
            //GL.Vertex(-1.0f, -1.0f, -1.0f);
            //GL.Color(1.0f, 0.0f, 0.0f);
            //GL.Vertex(0.0f, 1.0f, 0.0f);
            //GL.Color(0.0f, 0.0f, 1.0f);
            //GL.Vertex(-1.0f, -1.0f, -1.0f);
            //GL.Color(0.0f, 1.0f, 0.0f);
            //GL.Vertex(-1.0f, -1.0f, 1.0f);
            //GL.End();

            ////  Nudge the rotation.
            //rotation += 3.0f;

        }

        private void glCanvas1_Resize(object sender, EventArgs e)
        {
            ////  Set the projection matrix.
            //GL.MatrixMode(GL.GL_PROJECTION);

            ////  Load the identity.
            //GL.LoadIdentity();

            ////  Create a perspective transformation.
            //GL.gluPerspective(60.0f, (double)Width / (double)Height, 0.01, 100.0);

            ////  Use the 'look at' helper function to position and aim the camera.
            //GL.gluLookAt(-5, 5, -5, 0, 0, 0, 0, 1, 0);

            ////  Set the modelview matrix.
            //GL.MatrixMode(GL.GL_MODELVIEW);
        }


        private void glCanvas1_MouseDown(object sender, MouseEventArgs e)
        {
            satelliteRoration.SetBounds(this.glCanvas1.Width, this.glCanvas1.Height);
            satelliteRoration.MouseDown(e.X, e.Y);
            PrintCameraInfo();
        }

        private void glCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            if (satelliteRoration.mouseDownFlag)
            {
                satelliteRoration.MouseMove(e.X, e.Y);
                PrintCameraInfo();
            }
        }

        private void glCanvas1_MouseUp(object sender, MouseEventArgs e)
        {
            satelliteRoration.MouseUp(e.X, e.Y);
            PrintCameraInfo();
        }

        private void PrintCameraInfo()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(string.Format("position:{0}", this.camera.Position));
            builder.Append(string.Format(" target:{0}", this.camera.Target));
            builder.Append(string.Format(" up:{0}", this.camera.UpVector));

            this.txtInfo.Text = builder.ToString();
        }

        private void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'b')
            {
                //element.blend = !element.blend;
            }
            else if (e.KeyChar == 'c')
            {
                if (camera.CameraType == CameraTypes.Perspecitive)
                {
                    camera.CameraType = CameraTypes.Ortho;
                }
                else
                {
                    camera.CameraType = CameraTypes.Perspecitive;
                }
            }

        }
    }
}
