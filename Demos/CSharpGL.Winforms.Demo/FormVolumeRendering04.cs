using GLM;
using CSharpGL.Objects;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.Demos;
using CSharpGL.Objects.SceneElements;
using CSharpGL.Objects.Shaders;
using System;
using System.Windows.Forms;
using CSharpGL.Objects.Demos.VolumeRendering;
using CSharpGL.Enumerations;

namespace CSharpGL.Winforms.Demo
{
    public partial class FormVolumeRendering04 : Form
    {
        SatelliteRotator rotator;
        Camera camera;
        DemoVolumeRendering04 element;
        DemoVolumeRendering04 elementReversed;
        private RenderOrder renderOrder;

        public FormVolumeRendering04()
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

            element = new DemoVolumeRendering04(false);
            element.Initialize();

            elementReversed = new DemoVolumeRendering04(true);
            elementReversed.Initialize();

            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
            this.glCanvas1.KeyPress += glCanvas1_KeyPress;
            this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            this.glCanvas1.Resize += glCanvas1_Resize;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            this.element.Dispose();
            this.elementReversed.Dispose();

            base.OnClosing(e);
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

        void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            var arg = new RenderEventArgs(RenderModes.Render, this.camera);
            mat4 projectionMatrix = camera.GetProjectionMat4();
            mat4 viewMatrix = camera.GetViewMat4();
            mat4 modelMatrix = mat4.identity();
            mat4 mvp = projectionMatrix * viewMatrix * modelMatrix;

            switch (this.renderOrder)
            {
                case RenderOrder.Increase:
                    element.mvp = mvp;

                    element.Render(arg);
                    break;
                case RenderOrder.Decrease:
                    elementReversed.mvp = mvp;

                    elementReversed.Render(arg);
                    break;
                case RenderOrder.IncreaseThenDecrease:
                    element.mvp = mvp;
                    elementReversed.mvp = mvp;

                    element.Render(arg);
                    elementReversed.Render(arg);
                    break;
                case RenderOrder.DecreaseThenIncrease:
                    elementReversed.mvp = mvp;
                    element.mvp = mvp;

                    elementReversed.Render(arg);
                    element.Render(arg);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void glCanvas1_MouseDown(object sender, MouseEventArgs e)
        {
            this.rotator.SetBounds(this.glCanvas1.Width, this.glCanvas1.Height);
            this.rotator.MouseDown(e.X, e.Y);
        }

        private void glCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.rotator.MouseDownFlag)
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
                //public BlendingSourceFactor sFactor = BlendingSourceFactor.SourceAlpha;
                //public BlendingDestinationFactor dFactor = BlendingDestinationFactor.OneMinusSourceAlpha;
                var values = Enum.GetValues(typeof(BlendingSourceFactor));
                foreach (var item in values)
                {
                    string name = item.ToString();
                    this.cmbSFactor.Items.Add(name);
                }
            }
            {
                var values = Enum.GetValues(typeof(BlendingDestinationFactor));
                foreach (var item in values)
                {
                    string name = item.ToString();
                    this.cmbDFactor.Items.Add(name);
                }
            }
            {
                var values = Enum.GetValues(typeof(RenderOrder));
                foreach (var item in values)
                {
                    string name = item.ToString();
                    this.cmbRenderOrder.Items.Add(name);
                }
                this.cmbRenderOrder.SelectedIndex = 0;
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

        private void trackAlpha_Scroll(object sender, EventArgs e)
        {
            var value = (float)this.trackAlpha.Value / 100.0f;
            this.element.alphaThreshold = value;
            this.lblAlphaThreshold.Text = value.ToShortString();
        }

        private void cmbSFactor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sfactor = (BlendingSourceFactor)Enum.Parse(typeof(BlendingSourceFactor), cmbSFactor.SelectedItem.ToString());
            this.element.sFactor = sfactor;
        }

        private void cmbDFactor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dfactor = (BlendingDestinationFactor)Enum.Parse(typeof(BlendingDestinationFactor), cmbDFactor.SelectedItem.ToString());
            this.element.dFactor = dfactor;
        }

        private void chkBlend_CheckedChanged(object sender, EventArgs e)
        {
            this.element.blend = this.chkBlend.Checked;
        }

        private void cmbRenderOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            var renderOrder = (RenderOrder)Enum.Parse(typeof(RenderOrder), cmbRenderOrder.SelectedItem.ToString());
            this.renderOrder = renderOrder;
        }

    }

    enum RenderOrder
    {
        Increase,
        Decrease,
        IncreaseThenDecrease,
        DecreaseThenIncrease,

    }
}
