using CSharpGL.Maths;
using CSharpGL.Objects;
using CSharpGL.Objects.Cameras;
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
    public partial class FormWholeFontTextureElement : Form
    {
        SatelliteRotator rotator;
        ScientificCamera camera;
        WholeFontTextureElement element;

        public FormWholeFontTextureElement()
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
            this.Load += FormWholeFontTextureElement_Load;

            element = new WholeFontTextureElement("msyh.ttc.png", "msyh.ttc.xml");
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
            GL.BindTexture(GL.GL_TEXTURE_2D, 0);

            if (element.blend)
            {
                GL.Disable(GL.GL_BLEND);
            }
        }
        void element_BeforeRendering(object sender, Objects.RenderEventArgs e)
        {
            CSharpGL.Objects.Texture2D texture = element.texture;
            texture.Bind();

            if (element.blend)
            {
                GL.Enable(GL.GL_BLEND);
                GL.BlendFunc(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA);
            }

            mat4 modelMatrix = mat4.identity();
            mat4 viewMatrix = this.camera.GetViewMat4();
            mat4 projectionMatrix = this.camera.GetProjectionMat4();

            ShaderProgram shaderProgram = element.shaderProgram;
            shaderProgram.Bind();
            shaderProgram.SetUniform(WholeFontTextureElement.strtex, texture.Name);
            shaderProgram.SetUniform(WholeFontTextureElement.strcolor, 1.0f, 1.0f, 1.0f, 1.0f);
            shaderProgram.SetUniformMatrix4(WholeFontTextureElement.strprojectionMatrix, projectionMatrix.to_array());
            shaderProgram.SetUniformMatrix4(WholeFontTextureElement.strviewMatrix, viewMatrix.to_array());
            shaderProgram.SetUniformMatrix4(WholeFontTextureElement.strmodelMatrix, modelMatrix.to_array());
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            element.Render(new RenderEventArgs(RenderModes.Render, this.camera));
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

        private void FormWholeFontTextureElement_Load(object sender, EventArgs e)
        {
            this.lblCameraType.Text = string.Format("camera type: {0}", this.camera.CameraType);

            MessageBox.Show(string.Format("{1}{0}{2}",
                Environment.NewLine,
                "Use 'c' to switch camera types between perspective and ortho",
                "Use 'b' to switch blend effect"));
        }

        private void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'b')
            {
                this.element.blend = !this.element.blend;
            }
            else if (e.KeyChar == 'c')
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
