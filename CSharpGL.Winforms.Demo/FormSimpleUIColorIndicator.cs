using CSharpGL.Maths;
using CSharpGL.Objects;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.Demos.UIs;
using CSharpGL.Objects.SceneElements;
using CSharpGL.Objects.Shaders;
using CSharpGL.Objects.UIs;
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
    public partial class FormSimpleUIColorIndicator : Form
    {
        SimpleUIColorIndicator uiBottomColorIndicator;
        SimpleUIColorIndicator uiTopColorIndicator;
        SimpleUIPointSpriteStringElement[] numbers;

        AxisElement axisElement;

        ScientificCamera camera;

        SatelliteRotator satelliteRoration;

        public FormSimpleUIColorIndicator()
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

            ColorPalette colorPalette = ColorPaletteFactory.CreateRainbow();

            Padding padding = new System.Windows.Forms.Padding(40, 40, 40, 40);
            Size size = new Size(100, 30);
            //Size size = new Size(5, 5);
            IUILayoutParam param;
            param = new IUILayoutParam(AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right, padding, size);
            param = new IUILayoutParam(AnchorStyles.Left | AnchorStyles.Bottom, padding, size);
            uiBottomColorIndicator = new SimpleUIColorIndicator(param, colorPalette, -100, 100, 5);
            param = new IUILayoutParam(AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right, padding, size);
            uiTopColorIndicator = new SimpleUIColorIndicator(param, colorPalette, -100, 100, 5);

            uiBottomColorIndicator.Initialize();
            uiTopColorIndicator.Initialize();

            uiBottomColorIndicator.BeforeRendering += SimpleUIColorIndicator_BeforeRendering;
            uiTopColorIndicator.BeforeRendering += SimpleUIColorIndicator_BeforeRendering;

            uiBottomColorIndicator.AfterRendering += SimpleUIColorIndicator_AfterRendering;
            uiTopColorIndicator.AfterRendering += SimpleUIColorIndicator_AfterRendering;

            const float posY=-1.0f;
            float[] coords = colorPalette.Coords;
            float coordLength = coords[coords.Length - 1] - coords[0];
            this.numbers = new SimpleUIPointSpriteStringElement[5];
            param = new IUILayoutParam(AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right, padding, size);
            this.numbers[0] = new SimpleUIPointSpriteStringElement(param, (-100.0f).ToShortString(),
                new vec3(-0.5f, posY, 0));
            this.numbers[0].Initialize();
            this.numbers[0].BeforeRendering += number_BeforeRendering;
            this.numbers[0].AfterRendering += number_AfterRendering;
            for (int i = 1; i < coords.Length; i++)
            {
                float x = (coords[i] - coords[0]) / coordLength - 0.5f;
                if (i + 1 == coords.Length)
                {
                    var number = new SimpleUIPointSpriteStringElement(param,
                        (100.0f).ToShortString(), new vec3(x, posY, 0));
                    number.Initialize();
                    number.BeforeRendering += number_BeforeRendering;
                    number.AfterRendering += number_AfterRendering;
                    this.numbers[i] = number;
                }
                else
                {
                    var number = new SimpleUIPointSpriteStringElement(param,
                        (-100.0f + i * (100 - (-100)) / 5).ToShortString(), new vec3(x, posY, 0));
                    number.Initialize();
                    number.BeforeRendering += number_BeforeRendering;
                    number.AfterRendering += number_AfterRendering;
                    this.numbers[i] = number;
                }
            }

            axisElement = new AxisElement();
            axisElement.Initialize();
            axisElement.BeforeRendering += axisElement_BeforeRendering;
            axisElement.AfterRendering += axisElement_AfterRendering;

            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
            this.glCanvas1.KeyPress += glCanvas1_KeyPress;
            this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            this.glCanvas1.Resize += glCanvas1_Resize;
        }

        void number_AfterRendering(object sender, Objects.RenderEventArgs e)
        {
            IMVP element = sender as IMVP;

            element.UnbindShaderProgram();
        }

        void number_BeforeRendering(object sender, Objects.RenderEventArgs e)
        {

            mat4 projectionMatrix, viewMatrix, modelMatrix;

            {
                IUILayout element = sender as IUILayout;
                element.GetMatrix(out projectionMatrix, out viewMatrix, out modelMatrix);
            }

            {
                mat4 mvp = projectionMatrix * viewMatrix * modelMatrix;

                IMVP element = sender as IMVP;

                element.UpdateMVP(mvp);
            }
        }

        void SimpleUIColorIndicator_AfterRendering(object sender, Objects.RenderEventArgs e)
        {
            SimpleUIColorIndicator element = sender as SimpleUIColorIndicator;

            element.shaderProgram.Unbind();
        }

        void SimpleUIColorIndicator_BeforeRendering(object sender, Objects.RenderEventArgs e)
        {
            SimpleUIColorIndicator element = sender as SimpleUIColorIndicator;

            mat4 projectionMatrix, viewMatrix, modelMatrix;

            element.GetMatrix(out projectionMatrix, out viewMatrix, out modelMatrix);

            ShaderProgram shaderProgram = element.shaderProgram;

            shaderProgram.Bind();

            shaderProgram.SetUniformMatrix4(SimpleUIColorIndicator.strprojectionMatrix, projectionMatrix.to_array());
            shaderProgram.SetUniformMatrix4(SimpleUIColorIndicator.strviewMatrix, viewMatrix.to_array());
            shaderProgram.SetUniformMatrix4(SimpleUIColorIndicator.strmodelMatrix, modelMatrix.to_array());
        }

        void axisElement_AfterRendering(object sender, Objects.RenderEventArgs e)
        {
            IMVP element = sender as IMVP;

            element.UnbindShaderProgram();
        }

        void axisElement_BeforeRendering(object sender, Objects.RenderEventArgs e)
        {
            mat4 projectionMatrix = camera.GetProjectionMat4();

            mat4 viewMatrix = camera.GetViewMat4();

            mat4 modelMatrix = mat4.identity();

            mat4 mvp = projectionMatrix * viewMatrix * modelMatrix;

            IMVP element = sender as IMVP;

            element.UpdateMVP(mvp);
        }

        private void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            this.camera.MouseWheel(e.Delta);
        }

        private void FormTranslateOnScreen_Load(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("{0}",
                "Use 'c' to switch camera types between perspective and ortho"));
        }

        private void glCanvas1_OpenGLDraw(object sender, RenderEventArgs e)
        {
            PrintCameraInfo();

            GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            axisElement.Render(Objects.RenderModes.Render);

            uiBottomColorIndicator.Render(Objects.RenderModes.Render);
            uiTopColorIndicator.Render(Objects.RenderModes.Render);

            foreach (var item in this.numbers)
            {
                item.Render(Objects.RenderModes.Render);
            }
        }

        private void glCanvas1_Resize(object sender, EventArgs e)
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
            builder.Append(string.Format(" window: {0}, {1}", this.glCanvas1.Width, this.glCanvas1.Height));
            int[] viewport = new int[4];
            GL.GetInteger(GetTarget.Viewport, viewport);
            builder.Append(string.Format(" viewport: {0}, {1}", viewport[2], viewport[3]));

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
