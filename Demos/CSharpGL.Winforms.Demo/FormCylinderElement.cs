using GLM;
using CSharpGL.Objects;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.SceneElements;
using CSharpGL.Objects.Shaders;
using System;
using System.Text;
using System.Windows.Forms;

namespace CSharpGL.Winforms.Demo
{
    public partial class FormCylinderElement : Form
    {
        CylinderElement cylinderElement;

        Camera camera;

        SatelliteRotator satelliteRoration;

        public FormCylinderElement()
        {
            InitializeComponent();

            //if (CameraDictionary.Instance.ContainsKey(this.GetType().Name))
            //{
            //    this.camera = CameraDictionary.Instance[this.GetType().Name];
            //}
            //else
            {
                this.camera = new Camera(CameraType.Ortho, this.glCanvas1.Width, this.glCanvas1.Height);
                //CameraDictionary.Instance.Add(this.GetType().Name, this.camera);
            }

            satelliteRoration = new SatelliteRotator(camera);

            var faceCount = 18;
            var radius = 1f;
            var height = 3f;
            cylinderElement = new CylinderElement(radius, height, faceCount);
            cylinderElement.Initialize();

            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
            this.glCanvas1.KeyPress += glCanvas1_KeyPress;
            this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            this.glCanvas1.Resize += glCanvas1_Resize;
        }

        private void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            this.camera.MouseWheel(e.Delta);
        }

        private void FormGLCanvas_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Use 'c' to switch camera types between perspective and ortho");

            // Init GL
            GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            // first resize
            glCanvas1_Resize(this.glCanvas1, e);
        }

        void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            var arg = new RenderEventArgs(RenderModes.Render, this.camera);
            mat4 projectionMatrix = camera.GetProjectionMat4();
            mat4 viewMatrix = camera.GetViewMat4();
            mat4 modelMatrix = mat4.identity();
            mat4 mvp = projectionMatrix * viewMatrix * modelMatrix;

            cylinderElement.mvp = mvp;

            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            cylinderElement.Render(arg);
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
            if (satelliteRoration.MouseDownFlag)
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
            builder.Append(string.Format(" camera type: {0}", this.camera.CameraType));

            this.txtInfo.Text = builder.ToString();
        }

        private void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'c')
            {
                switch (this.camera.CameraType)
                {
                    case CameraType.Perspecitive:
                        this.camera.CameraType = CameraType.Ortho;
                        break;
                    case CameraType.Ortho:
                        this.camera.CameraType = CameraType.Perspecitive;
                        break;
                    default:
                        throw new NotImplementedException();
                }

                PrintCameraInfo();
            }

        }
    }
}
