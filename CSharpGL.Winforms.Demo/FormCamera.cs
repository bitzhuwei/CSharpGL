using CSharpGL.Maths;
using CSharpGL.Objects;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.SceneElements;
using CSharpGL.Objects.Shaders;
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
    public partial class FormCamera : Form
    {
        ScientificCamera camera;
        PyramidElement element;
        public mat4 projectionMatrix;
        public mat4 viewMatrix;
        public mat4 modelMatrix;
        private float rotation;

        public FormCamera()
        {
            InitializeComponent();

            if (CameraDictionary.Instance.ContainsKey(this.GetType().Name))
            {
                this.camera = CameraDictionary.Instance[this.GetType().Name];
            }
            else
            {
                this.camera = new ScientificCamera(CameraTypes.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                CameraDictionary.Instance.Add(this.GetType().Name, this.camera);
            }


            element = new PyramidElement();
            element.Initialize();

            element.BeforeRendering += element_BeforeRendering;
            element.AfterRendering += element_AfterRendering;

            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
            this.glCanvas1.KeyPress += glCanvas1_KeyPress;
            //this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            //this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            //this.glCanvas1.MouseUp += glCanvas1_MouseUp;
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

        private void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (this.camera != null)
            {
                this.camera.MouseWheel(e.Delta);
            }
        }

        void element_AfterRendering(object sender, Objects.RenderEventArgs e)
        {
            IMVP element = sender as IMVP;

            element.UnbindShaderProgram();
        }

        void element_BeforeRendering(object sender, Objects.RenderEventArgs e)
        {
            rotation += 3.0f;
            modelMatrix = glm.rotate(rotation, new vec3(0, 1, 0));
            viewMatrix = this.camera.GetViewMat4();
            projectionMatrix = this.camera.GetProjectionMat4();

            mat4 mvp = projectionMatrix * viewMatrix * modelMatrix;

            IMVP element = sender as IMVP;

            element.UpdateMVP(mvp);
        }

        void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            element.Render(new RenderEventArgs(RenderModes.Render, this.camera));
        }

        private void FormScientificCamera_Load(object sender, EventArgs e)
        {
            this.lblCameraType.Text = string.Format("camera type: {0}", this.camera.CameraType);

            MessageBox.Show("Use 'c' to switch camera types between perspective and ortho");
        }

        private void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'c')
            {
                switch (this.camera.CameraType)
                {
                    case CameraTypes.Perspecitive:
                        this.camera.CameraType = CameraTypes.Ortho;
                        break;
                    case CameraTypes.Ortho:
                        this.camera.CameraType = CameraTypes.Perspecitive;
                        break;
                    default:
                        throw new NotImplementedException();
                }

                this.lblCameraType.Text = string.Format("camera type: {0}", this.camera.CameraType);
            }
        }
    }
}
