using CSharpGL.Maths;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.SceneElements;
using CSharpGL.Objects.Shaders;
using CSharpGL.Objects.UI.SimpleUI;
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
    public partial class FormSimpleUIAxis : Form
    {
        SimpleUIAxis uiAxisElement;

        AxisElement axisElement;

        ScientificCamera camera;

        SatelliteRotator satelliteRoration;

        public FormSimpleUIAxis()
        {
            InitializeComponent();

            if (CameraDictionary.Instance.ContainsKey(this.GetType().Name))
            {
                this.camera = CameraDictionary.Instance[this.GetType().Name];
            }
            else
            {
                this.camera = new ScientificCamera(CameraTypes.Ortho, this.glCanvas1.Width, this.glCanvas1.Height);
                CameraDictionary.Instance.Add(this.GetType().Name, this.camera);
            }

            satelliteRoration = new SatelliteRotator(camera);

            uiAxisElement = new SimpleUIAxis(AnchorStyles.Left | AnchorStyles.Bottom, new Padding(20,20,20,20), new Size(5,5));
            uiAxisElement.Initialize();
            uiAxisElement.BeforeRendering += uiRectElement_BeforeRendering;
            uiAxisElement.AfterRendering += uiRectElement_AfterRendering;

            axisElement = new AxisElement();
            axisElement.Initialize();
            axisElement.BeforeRendering += axisElement_BeforeRendering;
            axisElement.AfterRendering += axisElement_AfterRendering;

            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
        }

        void axisElement_AfterRendering(object sender, Objects.RenderEventArgs e)
        {
            axisElement.shaderProgram.Unbind();
        }

        void axisElement_BeforeRendering(object sender, Objects.RenderEventArgs e)
        {
            mat4 projectionMatrix = camera.GetProjectionMat4();

            mat4 viewMatrix = camera.GetViewMat4();

            mat4 modelMatrix = mat4.identity();

            ShaderProgram shaderProgram = axisElement.shaderProgram;

            shaderProgram.Bind();

            shaderProgram.SetUniformMatrix4(AxisElement.strprojectionMatrix, projectionMatrix.to_array());
            shaderProgram.SetUniformMatrix4(AxisElement.strviewMatrix, viewMatrix.to_array());
            shaderProgram.SetUniformMatrix4(AxisElement.strmodelMatrix, modelMatrix.to_array());
        }

        void uiRectElement_AfterRendering(object sender, Objects.RenderEventArgs e)
        {
            this.uiAxisElement.shaderProgram.Unbind();
        }

        void uiRectElement_BeforeRendering(object sender, Objects.RenderEventArgs e)
        {
            SimpleUIRectArgs args = this.uiAxisElement.GetArgs();

            mat4 projectionMatrix = glm.ortho((float)args.left, (float)args.right, (float)args.bottom, (float)args.top,
                this.uiAxisElement.zNear, this.uiAxisElement.zFar);

            mat4 viewMatrix;
            IViewCamera camera = this.camera;
            if (camera == null)
            {
                viewMatrix = glm.lookAt(new vec3(0, 0, 1), new vec3(0, 0, 0), new vec3(0, 1, 0));
            }
            else
            {
                vec3 position = camera.Position - camera.Target;
                position.Normalize();
                viewMatrix = glm.lookAt(position, new vec3(0, 0, 0), camera.UpVector);
            }

            mat4 modelMatrix = glm.scale(mat4.identity(), 
                new vec3(args.UIWidth / 2, args.UIHeight / 2, (float)Math.Max(args.UIWidth, args.UIHeight) / 2));

            {
                ShaderProgram shaderProgram = this.uiAxisElement.shaderProgram;

                shaderProgram.Bind();

                shaderProgram.SetUniformMatrix4(SimpleUIAxis.strprojectionMatrix, projectionMatrix.to_array());
                shaderProgram.SetUniformMatrix4(SimpleUIAxis.strviewMatrix, viewMatrix.to_array());
                shaderProgram.SetUniformMatrix4(SimpleUIAxis.strmodelMatrix, modelMatrix.to_array());
            }
        }

        private void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            this.camera.Scale(e.Delta);
        }

        private void FormTranslateOnScreen_Load(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("{1}{0}{2}{0}{3}{0}{4}",
                Environment.NewLine,
                "Use 'c' to switch camera types between perspective and ortho",
                "w/s for y axis up/down",
                "a/d for x axis left/right",
                "e/q for z axis near/far"));
        }

        private void glCanvas1_OpenGLDraw(object sender, RenderEventArgs e)
        {
            PrintCameraInfo();

            GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            axisElement.Render(Objects.RenderModes.Render);
            uiAxisElement.Render(Objects.RenderModes.Render);
        }

        private void glCanvas_Resize(object sender, EventArgs e)
        {
            if (this.camera != null)
            {
                this.camera.Resize(this.glCanvas1.Width, this.glCanvas1.Height);
            }
        }


        private void glCanvas1_MouseDown(object sender, MouseEventArgs e)
        {
            satelliteRoration.SetBounds(this.glCanvas1.Width, this.glCanvas1.Height);
            satelliteRoration.MouseDown(e.X, e.Y);
        }

        private void glCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            if (satelliteRoration.mouseDownFlag)
            {
                satelliteRoration.MouseMove(e.X, e.Y);
            }
        }

        private void glCanvas1_MouseUp(object sender, MouseEventArgs e)
        {
            satelliteRoration.MouseUp(e.X, e.Y);
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
                    case CameraTypes.Perspecitive:
                        this.camera.CameraType = CameraTypes.Ortho;
                        break;
                    case CameraTypes.Ortho:
                        this.camera.CameraType = CameraTypes.Perspecitive;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }
    }
}
