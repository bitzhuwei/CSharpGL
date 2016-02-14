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
        List<ObjFileRenderer> elements = new List<ObjFileRenderer>();
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
        }

        private void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            this.camera.MouseWheel(e.Delta);
        }

        private void FormGLCanvas_Load(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Use 'c' to switch camera types between perspective and ortho");

            MessageBox.Show(builder.ToString());

            // Init GL
            GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
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
            else if (e.KeyChar == 'n')
            {

            }
        }
        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.elements.Clear();

                ObjFile file = OBJParser.ObjFile.Load(this.openFileDialog1.FileName);
                foreach (var item in file.Models)
                {
                    ObjFileRenderer element = new ObjFileRenderer(new ObjModelAdpater(item));
                    element.Initialize();
                    elements.Add(element);
                }

                if (file.Models.Count == 1)
                {
                    var model = file.Models[0];
                    this.lblInfo.Text = string.Format("{0} vertexes, {1} faces", model.positionList.Count, model.faceList.Count);
                }
                else
                {
                    this.lblInfo.Text = string.Format("{0} objects", file.Models.Count);
                }
            }

        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            //  Clear the color and depth buffer.
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            RenderEventArgs args = new RenderEventArgs(RenderModes.Render, this.camera);
            mat4 projectionMatrix = camera.GetProjectionMat4();
            mat4 viewMatrix = camera.GetViewMat4();
            mat4 modelMatrix = mat4.identity();

            foreach (var item in this.elements)
            {
                item.projectionMatrix = projectionMatrix;
                item.viewMatrix = viewMatrix;
                item.modelMatrix = modelMatrix;
                item.Render(args);
            }
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
