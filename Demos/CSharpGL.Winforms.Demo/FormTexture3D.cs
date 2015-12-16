using GLM;
using CSharpGL.Objects;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.Demos;
using CSharpGL.Objects.SceneElements;
using CSharpGL.Objects.Shaders;
using System;
using System.Windows.Forms;

namespace CSharpGL.Winforms.Demo
{
    public partial class FormTexture3D : Form
    {
        SatelliteRotator rotator;
        Camera camera;
        DemoTexImage2D element;

        public FormTexture3D()
        {
            InitializeComponent();

            //if (CameraDictionary.Instance.ContainsKey(this.GetType().Name))
            //{
            //    this.camera = CameraDictionary.Instance[this.GetType().Name];
            //}
            //else
            {
                this.camera = new Camera(CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                //CameraDictionary.Instance.Add(this.GetType().Name, this.camera);
            }

            this.camera.Position = new vec3(2, 2, 2);

            rotator = new SatelliteRotator(this.camera);
            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;

            element = new DemoTexImage2D("DemoTexImage2D.bmp");
            element.Initialize();

            element.BeforeRendering += element_BeforeRendering;
            element.AfterRendering += element_AfterRendering;

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
            if (this.camera != null)
            {
                this.camera.Resize(this.glCanvas1.Width, this.glCanvas1.Height);
            }
        }

        void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            this.camera.MouseWheel(e.Delta);
        }

        void element_AfterRendering(object sender, Objects.RenderEventArgs e)
        {
            IMVP element = sender as IMVP;

            element.ResetShaderProgram();
        }

        void element_BeforeRendering(object sender, Objects.RenderEventArgs e)
        {
            mat4 projectionMatrix = camera.GetProjectionMat4();

            mat4 viewMatrix = camera.GetViewMat4();

            mat4 modelMatrix = mat4.identity();

            mat4 mvp = projectionMatrix * viewMatrix * modelMatrix;

            IMVP element = sender as IMVP;

            element.SetShaderProgram(mvp);
        }

        void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            var arg = new RenderEventArgs(RenderModes.Render, this.camera);
            element.Render(arg);
        }

        private void glCanvas1_MouseDown(object sender, MouseEventArgs e)
        {
            this.rotator.SetBounds(this.glCanvas1.Width, this.glCanvas1.Height);
            this.rotator.MouseDown(e.X, e.Y);
        }

        private void glCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.rotator.mouseDownFlag)
            {
                this.rotator.MouseMove(e.X, e.Y);
            }
        }

        private void glCanvas1_MouseUp(object sender, MouseEventArgs e)
        {
            this.rotator.MouseUp(e.X, e.Y);
        }

        private void FormSatelliteRotation_Load(object sender, EventArgs e)
        {
            {
                var items = new TexImage2DFormats[] { TexImage2DFormats.Alpha, TexImage2DFormats.Luminance, TexImage2DFormats.LuminanceAlpha, TexImage2DFormats.RGB, TexImage2DFormats.RGBA };

                foreach (var item in items)
                {
                    this.cmbFormat.Items.Add(item);
                    this.cmbInternalformat.Items.Add(item);
                }
                
            }

            this.lblCameraType.Text = string.Format("camera type: {0}", this.camera.CameraType);

            MessageBox.Show("Use 'c' to switch camera types between perspective and ortho");
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

                this.lblCameraType.Text = string.Format("camera type: {0}", this.camera.CameraType);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if(this.openFileDialog1.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                this.txtTextureFile.Text = this.openFileDialog1.FileName;
                this.btnOK.Enabled = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var element = new DemoTexImage2D(this.txtTextureFile.Text);
            element.Initialize();
            element.BeforeRendering += element_BeforeRendering;
            element.AfterRendering += element_AfterRendering;

            this.element = element;
        }

    }
}
