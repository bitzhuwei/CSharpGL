using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.Texts;
using System;
using System.Text;
using System.Windows.Forms;

namespace CSharpGL.Winforms.Demo
{
    public partial class FormModernSingleTextureFont : Form
    {
        ScientificCamera camera; //= new ScientificCamera(CameraTypes.Ortho);

        SatelliteRotation satelliteRoration;

        ModernSingleTextureFont element;// = new ModernSingleTextureFont("simsun.ttf");
        public FormModernSingleTextureFont()
        {
            InitializeComponent();

            if (ScientificCamera.cameraDict.ContainsKey("FormModernSingleTextureFont"))
            {
                this.camera = ScientificCamera.cameraDict["FormModernSingleTextureFont"];
            }
            else
            {
                this.camera = new ScientificCamera(CameraTypes.Ortho, this.glCanvas1.Width, this.glCanvas1.Height, "FormModernSingleTextureFont");
            }
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

            element = new ModernSingleTextureFont(camera, "simsun.ttf", 48, '祝', '神');//char.MinValue, char.MaxValue);

            element.Initialize();

            element.SetText("祝神");

            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
        }

        void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            this.camera.Scale(e.Delta);
        }

        private void glCanvas1_OpenGLDraw(object sender, RenderEventArgs e)
        {
            GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            element.Render(Objects.RenderModes.Render);
        }

        private void FormFreeTypeTextVAOElement_Load(object sender, EventArgs e)
        {
            PrintCameraInfo();
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
                element.blend = !element.blend;
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
