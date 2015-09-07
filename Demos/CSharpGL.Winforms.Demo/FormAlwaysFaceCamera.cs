using CSharpGL.Maths;
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
    public partial class FormAlwaysFaceCamera : Form
    {
        SatelliteRotator rotator;
        ScientificCamera camera;
        PyramidElement element;

        public FormAlwaysFaceCamera()
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

            rotator = new SatelliteRotator(this.camera);
            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;

            element = new PyramidElement();
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
            element.shaderProgram.Unbind();
        }

        void element_BeforeRendering(object sender, Objects.RenderEventArgs e)
        {
            vec3 currentVector = this.camera.Position - this.camera.Target;
            vec3 defaultVector = ScientificCamera.defaultPosition - ScientificCamera.defaultTarget;
            currentVector.Normalize();
            defaultVector.Normalize();

            float cosAngle = currentVector.ScalarProduct(defaultVector);// / 1.0f;
            float angle = (float)Math.Acos(cosAngle);
            //vec3 axis = currentVector.VectorProduct(defaultVector);
            vec3 axis = defaultVector.VectorProduct(currentVector);
            //mat4 translate = glm.translate(mat4.identity(), new vec3(0.2f, 0.2f, 0.2f));
            mat4 modelMatrix = glm.rotate(angle, axis);

            //mat4 modelMatrix = mat4.identity();
            mat4 viewMatrix = this.camera.GetViewMat4();
            mat4 projectionMatrix = this.camera.GetProjectionMat4();

            ShaderProgram shaderProgram = element.shaderProgram;
            shaderProgram.Bind();

            shaderProgram.SetUniformMatrix4(PyramidElement.strprojectionMatrix, projectionMatrix.to_array());
            shaderProgram.SetUniformMatrix4(PyramidElement.strviewMatrix, viewMatrix.to_array());
            shaderProgram.SetUniformMatrix4(PyramidElement.strmodelMatrix, modelMatrix.to_array());
        }

        private void glCanvas1_OpenGLDraw(object sender, RenderEventArgs e)
        {
            GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            element.Render(Objects.RenderModes.Render);
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

        private void FormAlwaysFaceCamera_Load(object sender, EventArgs e)
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
