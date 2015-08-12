using CSharpGL.Maths;
using CSharpGL.Objects.Cameras;
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
    public partial class FormSimpleUIRect : Form
    {
        SimpleUIRect element;

        ScientificCamera camera;

        SatelliteRotator satelliteRoration;

        public FormSimpleUIRect()
        {
            InitializeComponent();

            if (CameraDictionary.Instance.ContainsKey("FormTranslateOnScreen"))
            {
                this.camera = CameraDictionary.Instance["FormTranslateOnScreen"];
            }
            else
            {
                this.camera = new ScientificCamera(CameraTypes.Ortho, this.glCanvas1.Width, this.glCanvas1.Height);
                CameraDictionary.Instance.Add("FormTranslateOnScreen", this.camera);
            }

            satelliteRoration = new SatelliteRotator(camera);

            //var planColor = new vec3(1, 1, 0);
            //var faceCount = 10;
            //var radius = 0.1f;
            //var height = 10f;
            //element = new AxisElement(planColor, radius, height, faceCount);
            element = new SimpleUIRect(AnchorStyles.Left | AnchorStyles.Bottom, new Padding(1, 1, 1, 1), new Size(10, 20));
            element.Initialize();

            element.BeforeRendering += element_BeforeRendering;
            element.AfterRendering += element_AfterRendering;

            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
        }

        void element_AfterRendering(object sender, Objects.RenderEventArgs e)
        {
            //element.shaderProgram.Unbind();
        }

        void element_BeforeRendering(object sender, Objects.RenderEventArgs e)
        {
            //mat4 projectionMatrix = camera.GetProjectionMat4();
            //projectionMatrix = glm.translate(projectionMatrix, new vec3(translateX, translateY, translateZ));//

            //mat4 viewMatrix = camera.GetViewMat4();

            ////mat4 modelMatrix = glm.translate(mat4.identity(), new vec3(translateX, translateY, translateZ));// mat4.identity();
            //mat4 modelMatrix = mat4.identity();

            //ShaderProgram shaderProgram = element.shaderProgram;

            //shaderProgram.Bind();

            //shaderProgram.SetUniformMatrix4(CylinderVAOElement.strprojectionMatrix, projectionMatrix.to_array());
            //shaderProgram.SetUniformMatrix4(CylinderVAOElement.strviewMatrix, viewMatrix.to_array());
            //shaderProgram.SetUniformMatrix4(CylinderVAOElement.strmodelMatrix, modelMatrix.to_array());
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
            // Init GL
            GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            // first resize
            glCanvas_Resize(this.glCanvas1, e);
        }

        private void glCanvas1_OpenGLDraw(object sender, RenderEventArgs e)
        {
            GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            element.Render(Objects.RenderModes.Render);
        }

        private void glCanvas_Resize(object sender, EventArgs e)
        {
            if (element != null)
            {
                this.camera.Resize(this.glCanvas1.Width, this.glCanvas1.Height);
            }
        }


        private void glCanvas1_MouseDown(object sender, MouseEventArgs e)
        {
            satelliteRoration.SetBounds(this.glCanvas1.Width, this.glCanvas1.Height);
            satelliteRoration.MouseDown(e.X, e.Y);
            PrintCameraInfo();
        }

        private void glCanvas1_MouseMove(object sender, MouseEventArgs e)
        {

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

        }

    }
}
