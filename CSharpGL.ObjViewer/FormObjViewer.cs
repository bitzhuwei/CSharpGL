using CSharpGL.Objects;
using CSharpGL.Objects.Cameras;
using CSharpGL.OBJParser;
using GLM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.ObjViewer
{
    public partial class FormObjViewer : Form
    {
        List<ObjModelElement> elements = new List<ObjModelElement>();
        private Camera camera;
        SatelliteRotator satelliteRoration;
        public FormObjViewer()
        {
            InitializeComponent();

            this.camera = new Camera(CameraType.Ortho, this.glCanvas1.Width, this.glCanvas1.Height);
            satelliteRoration = new SatelliteRotator(camera);

            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
            this.glCanvas1.KeyPress += glCanvas1_KeyPress;
            this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            this.glCanvas1.Resize += glCanvas1_Resize;
        }

        void element_AfterRendering(object sender, Objects.RenderEventArgs e)
        {
        }

        void element_BeforeRendering(object sender, Objects.RenderEventArgs e)
        {
            mat4 projectionMatrix = camera.GetProjectionMat4();

            mat4 viewMatrix = camera.GetViewMat4();

            mat4 modelMatrix = mat4.identity();

            //mat4 mvp = projectionMatrix * viewMatrix * modelMatrix;

            ObjModelElement element = sender as ObjModelElement;
            element.projectionMatrix = projectionMatrix;
            element.viewMatrix = viewMatrix;
            element.modelMatrix = modelMatrix;
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

        private void glCanvas1_Resize(object sender, EventArgs e)
        {
            //this.camera.Resize(this.glCanvas1.Width, this.glCanvas1.Height);
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
        }

        private void glCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            if (satelliteRoration.MouseDownFlag)
            {
                satelliteRoration.MouseMove(e.X, e.Y);
            }
        }

        private void glCanvas1_MouseUp(object sender, MouseEventArgs e)
        {
            satelliteRoration.MouseUp(e.X, e.Y);
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

            }

        }
        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.openFileDialog1.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                this.elements.Clear();

                ObjFile file = OBJParser.ObjFile.Load(this.openFileDialog1.FileName);
                foreach (var item in file.Models)
                {
                    ObjModelElement element = new ObjModelElement(item);
                    element.Initialize();
                    element.BeforeRendering += element_BeforeRendering;
                    element.AfterRendering += element_AfterRendering;
                    elements.Add(element);
                }
            }

        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            //  Clear the color and depth buffer.
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            //GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);

            RenderEventArgs args = new RenderEventArgs(RenderModes.Render, this.camera);

            foreach (var item in this.elements)
            {
                item.Render(args);
            }
        }
    }
}
