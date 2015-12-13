using CSharpGL.Objects;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.Demos.VolumeRendering;
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

namespace CSharpGL.Winforms.Demo
{
    public partial class FormVolumeRendering01 : Form
    {
        private CRawDataProcessor processor = new CRawDataProcessor();
        private CTranformationMgr m_pTransform = new CTranformationMgr();
        private CRendererHelper m_Renderer = new CRendererHelper();
        private bool nFlags;


        public FormVolumeRendering01()
        {
            InitializeComponent();

            processor.ReadFile("head256x256x109", 256, 256, 109);
            m_Renderer.Initialize(processor, m_pTransform);

            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
            this.glCanvas1.KeyPress += glCanvas1_KeyPress;
            this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            this.glCanvas1.Resize += glCanvas1_Resize;

       }

        private void glCanvas1_Resize(object sender, EventArgs e)
        {
            //if (this.camera != null)
            //{
            //    this.camera.Resize(this.glCanvas1.Width, this.glCanvas1.Height);
            //}
            m_Renderer.Resize(this.glCanvas1.Width, this.glCanvas1.Height);
        }

        void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            //this.camera.MouseWheel(e.Delta);
        }

        void element_AfterRendering(object sender, Objects.RenderEventArgs e)
        {
            //IMVP element = sender as IMVP;

            //element.ResetShaderProgram();
        }

        void element_BeforeRendering(object sender, Objects.RenderEventArgs e)
        {
            //mat4 projectionMatrix = camera.GetProjectionMat4();

            //mat4 viewMatrix = camera.GetViewMat4();

            //mat4 modelMatrix = mat4.identity();

            //mat4 mvp = projectionMatrix * viewMatrix * modelMatrix;

            //IMVP element = sender as IMVP;

            //element.SetShaderProgram(mvp);
        }

        void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            //var arg = new RenderEventArgs(RenderModes.Render, this.camera);
            //element.Render(arg);

            m_Renderer.Render();
        }

        private void glCanvas1_MouseDown(object sender, MouseEventArgs e)
        {
            //this.rotator.SetBounds(this.glCanvas1.Width, this.glCanvas1.Height);
            //this.rotator.MouseDown(e.X, e.Y);
            if(e.Button== System.Windows.Forms.MouseButtons.Left)
            {
                lastPoint = e.Location;
                nFlags = true;
            }
        }

        Point lastPoint = new Point();

        private void glCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            //if (this.rotator.mouseDownFlag)
            //{
            //    this.rotator.MouseMove(e.X, e.Y);
            //}
            if (nFlags &&e.Button== System.Windows.Forms.MouseButtons.Left)
            {
                m_pTransform.Rotate(lastPoint.Y - e.Y, lastPoint.X - e.X, 0);
                lastPoint = e.Location;
            }
        }

        private void glCanvas1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                nFlags = false;
            }
            //this.rotator.MouseUp(e.X, e.Y);
        }

        private void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 'c')
            //{
            //    switch (this.camera.CameraType)
            //    {
            //        case CameraType.Perspecitive:
            //            this.camera.CameraType = CameraType.Ortho;
            //            break;
            //        case CameraType.Ortho:
            //            this.camera.CameraType = CameraType.Perspecitive;
            //            break;
            //        default:
            //            throw new NotImplementedException();
            //    }

            //}
        }

        private void 打开OToolStripButton_Click(object sender, EventArgs e)
        {
            //if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //CRawDataProcessor c = new CRawDataProcessor();
                //c.ReadFile(this.openFileDialog1.FileName, 256, 256, 109);
                //this.processor = c;
            }
        }

        private void FormVolumeRendering01_Load(object sender, EventArgs e)
        {
            this.glCanvas1_Resize(this.glCanvas1, e);
        }
    }
}
