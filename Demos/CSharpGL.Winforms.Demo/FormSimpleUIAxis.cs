using CSharpGL.Maths;
using CSharpGL.Objects;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.Demos.UIs;
using CSharpGL.Objects.SceneElements;
using CSharpGL.Objects.Shaders;
using CSharpGL.UIs;
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
    /// <summary>
    /// 本例演示了SimpleUIAxis、SimpleUIRect的用法，也证明了CSharpGL.Maths库里的mat4的mvp相乘的结果与glgl里的结果相同。
    /// </summary>
    public partial class FormSimpleUIAxis : Form
    {
        SimpleUIAxis uiLeftBottomAxis;
        SimpleUIAxis uiLeftTopAxis;
        SimpleUIAxis uiRightBottomAxis;
        SimpleUIAxis uiRightTopAxis;

        SimpleUIRect uiLeftBottomRect;
        SimpleUIRect uiLeftTopRect;
        SimpleUIRect uiRightBottomRect;
        SimpleUIRect uiRightTopRect;

        AxisElement axisElement;
        AxisElement2 axisElement2;

        Camera camera;

        SatelliteRotator satelliteRoration;

        public FormSimpleUIAxis()
        {
            InitializeComponent();

            //if (CameraDictionary.Instance.ContainsKey(this.GetType().Name))
            //{
            //    this.camera = CameraDictionary.Instance[this.GetType().Name];
            //}
            //else
            {
                this.camera = new Camera(CameraType.Ortho, this.glCanvas1.Width, this.glCanvas1.Height);
                //CameraDictionary.Instance.Add(this.GetType().Name, this.camera);
            }

            satelliteRoration = new SatelliteRotator(camera);

            Padding padding = new System.Windows.Forms.Padding(40, 40, 40, 40);
            Size size = new Size(100, 100);
            //Size size = new Size(5, 5);
            IUILayoutParam param;
            param = new IUILayoutParam(AnchorStyles.Left | AnchorStyles.Bottom, padding, size);
            uiLeftBottomAxis = new SimpleUIAxis(param);
            param = new IUILayoutParam(AnchorStyles.Left | AnchorStyles.Top, padding, size);
            uiLeftTopAxis = new SimpleUIAxis(param);
            param = new IUILayoutParam(AnchorStyles.Right | AnchorStyles.Bottom, padding, size);
            uiRightBottomAxis = new SimpleUIAxis(param);
            param = new IUILayoutParam(AnchorStyles.Right | AnchorStyles.Top, padding, size);
            uiRightTopAxis = new SimpleUIAxis(param);

            uiLeftBottomAxis.Initialize();
            uiLeftTopAxis.Initialize();
            uiRightBottomAxis.Initialize();
            uiRightTopAxis.Initialize();

            param = new IUILayoutParam(AnchorStyles.Left | AnchorStyles.Bottom, padding, size);
            uiLeftBottomRect = new SimpleUIRect(param);
            param = new IUILayoutParam(AnchorStyles.Left | AnchorStyles.Top, padding, size);
            uiLeftTopRect = new SimpleUIRect(param);
            param = new IUILayoutParam(AnchorStyles.Right | AnchorStyles.Bottom, padding, size);
            uiRightBottomRect = new SimpleUIRect(param);
            param = new IUILayoutParam(AnchorStyles.Right | AnchorStyles.Top, padding, size);
            uiRightTopRect = new SimpleUIRect(param);

            uiLeftBottomRect.Initialize();
            uiLeftTopRect.Initialize();
            uiRightBottomRect.Initialize();
            uiRightTopRect.Initialize();

            axisElement = new AxisElement();
            axisElement.Initialize();
            axisElement.BeforeRendering += axisElement_BeforeRendering;
            axisElement.AfterRendering += axisElement_AfterRendering;

            axisElement2 = new AxisElement2();
            axisElement2.Initialize();
            axisElement2.BeforeRendering += axisElement2_BeforeRendering;
            axisElement2.AfterRendering += axisElement2_AfterRendering;

            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
            this.glCanvas1.KeyPress += glCanvas1_KeyPress;
            this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            this.glCanvas1.Resize += glCanvas1_Resize;
        }

        //void SimpleUIRect_AfterRendering(object sender, Objects.RenderEventArgs e)
        //{
        //    IMVP element = sender as IMVP;
        //    element.UnbindShaderProgram();
        //}

        //void SimpleUIRect_BeforeRendering(object sender, Objects.RenderEventArgs e)
        //{
        //    mat4 projectionMatrix, viewMatrix, modelMatrix;

        //    {
        //        IUILayout element = sender as IUILayout;
        //        element.GetMatrix(out projectionMatrix, out viewMatrix, out modelMatrix, this.camera);
        //    }

        //    {
        //        IMVP element = sender as IMVP;
        //        element.UpdateMVP(projectionMatrix * viewMatrix * modelMatrix);
        //    }
        //}

        void axisElement_AfterRendering(object sender, Objects.RenderEventArgs e)
        {
            IMVP element = sender as IMVP;

            element.ResetShaderProgram();
        }

        void axisElement_BeforeRendering(object sender, Objects.RenderEventArgs e)
        {
            mat4 projectionMatrix = camera.GetProjectionMat4();
            projectionMatrix = glm.translate(projectionMatrix, new vec3(translateX, translateY, translateZ));//

            mat4 viewMatrix = camera.GetViewMat4();

            mat4 modelMatrix = mat4.identity();

            mat4 mvp = projectionMatrix * viewMatrix * modelMatrix;

            IMVP element = sender as IMVP;

            element.SetShaderProgram(mvp);
        }

        void axisElement2_AfterRendering(object sender, Objects.RenderEventArgs e)
        {
            AxisElement2 element = sender as AxisElement2;

            element.shaderProgram.Unbind();
        }

        void axisElement2_BeforeRendering(object sender, Objects.RenderEventArgs e)
        {
            AxisElement2 element = sender as AxisElement2;

            mat4 projectionMatrix = camera.GetProjectionMat4();
            projectionMatrix = glm.translate(projectionMatrix, new vec3(translateX, translateY, translateZ));//

            mat4 viewMatrix = camera.GetViewMat4();

            mat4 modelMatrix = mat4.identity();

            ShaderProgram shaderProgram = element.shaderProgram;

            shaderProgram.Bind();

            shaderProgram.SetUniformMatrix4(AxisElement2.strprojectionMatrix, projectionMatrix.to_array());
            shaderProgram.SetUniformMatrix4(AxisElement2.strviewMatrix, viewMatrix.to_array());
            shaderProgram.SetUniformMatrix4(AxisElement2.strmodelMatrix, modelMatrix.to_array());
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

        void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            PrintCameraInfo();

            GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            var arg = new RenderEventArgs(RenderModes.Render, this.camera);

            if (this.renderState == 2 || this.renderState == 4)
            {
                axisElement.Render(arg);
            }

            if (this.renderState == 3 || this.renderState == 4)
            {
                axisElement2.Render(arg);
            }

            uiLeftBottomAxis.Render(arg);
            uiLeftTopAxis.Render(arg);
            uiRightBottomAxis.Render(arg);
            uiRightTopAxis.Render(arg);

            uiLeftBottomRect.Render(arg);
            uiLeftTopRect.Render(arg);
            uiRightBottomRect.Render(arg);
            uiRightTopRect.Render(arg);
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
            builder.Append(string.Format("camera:"));
            builder.Append(string.Format(" position:{0}", this.camera.Position));
            builder.Append(string.Format(" target:{0}", this.camera.Target));
            builder.Append(string.Format(" up:{0}", this.camera.UpVector));
            builder.Append(string.Format(" camera type: {0}", this.camera.CameraType));
            builder.Append(string.Format(" rendering: {0}, {1}",
                this.renderState == 2 || this.renderState == 4,
                this.renderState == 3 || this.renderState == 4));

            this.txtInfo.Text = builder.ToString();
        }

        float translateX = 0, translateY = 0, translateZ = 0;
        const float interval = 0.1f;
        private int renderState = 4;

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
            }
            else if (e.KeyChar == '1')
            {
                this.renderState = 1;
            }
            else if (e.KeyChar == '2')
            {
                this.renderState = 2;
            }
            else if (e.KeyChar == '3')
            {
                this.renderState = 3;
            }
            else if (e.KeyChar == '4')
            {
                this.renderState = 4;
            }
            else if (e.KeyChar == 'w')
            {
                translateY += interval;
            }
            else if (e.KeyChar == 's')
            {
                translateY -= interval;
            }
            else if (e.KeyChar == 'a')
            {
                translateX -= interval;
            }
            else if (e.KeyChar == 'd')
            {
                translateX += interval;
            }
            else if (e.KeyChar == 'q')
            {
                translateZ -= interval;
            }
            else if (e.KeyChar == 'e')
            {
                translateZ += interval;
            }
        }
    }
}
