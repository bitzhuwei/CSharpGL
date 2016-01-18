using GLM;
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
using CSharpGL;
using CSharpGL.Objects.Models;
using CSharpGL.Objects.SceneElements;
using CSharpGL.Objects.ModelFactories;
using FormShaderDesigner1594Demos.SceneElements;

namespace FormShaderDesigner1594Demos
{
    /// <summary>
    /// 本例演示了SimpleUIAxis、SimpleUIRect的用法，也证明了CSharpGL.Maths库里的mat4的mvp相乘的结果与glgl里的结果相同。
    /// </summary>
    public partial class FormXRay : Form
    {
        SimpleUIAxis uiLeftBottomAxis;
        //SimpleUIAxis uiLeftTopAxis;
        //SimpleUIAxis uiRightBottomAxis;
        //SimpleUIAxis uiRightTopAxis;

        //SimpleUIRect uiLeftBottomRect;
        //SimpleUIRect uiLeftTopRect;
        //SimpleUIRect uiRightBottomRect;
        //SimpleUIRect uiRightTopRect;

        XRayElement element;
        //PointLightElement lightElement;

        Camera camera;

        SatelliteRotator satelliteRoration;

        public FormXRay()
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
            //param = new IUILayoutParam(AnchorStyles.Left | AnchorStyles.Top, padding, size);
            //uiLeftTopAxis = new SimpleUIAxis(param);
            //param = new IUILayoutParam(AnchorStyles.Right | AnchorStyles.Bottom, padding, size);
            //uiRightBottomAxis = new SimpleUIAxis(param);
            //param = new IUILayoutParam(AnchorStyles.Right | AnchorStyles.Top, padding, size);
            //uiRightTopAxis = new SimpleUIAxis(param);

            uiLeftBottomAxis.Initialize();
            //uiLeftTopAxis.Initialize();
            //uiRightBottomAxis.Initialize();
            //uiRightTopAxis.Initialize();

            param = new IUILayoutParam(AnchorStyles.Left | AnchorStyles.Bottom, padding, size);
            //uiLeftBottomRect = new SimpleUIRect(param);
            //param = new IUILayoutParam(AnchorStyles.Left | AnchorStyles.Top, padding, size);
            //uiLeftTopRect = new SimpleUIRect(param);
            //param = new IUILayoutParam(AnchorStyles.Right | AnchorStyles.Bottom, padding, size);
            //uiRightBottomRect = new SimpleUIRect(param);
            //param = new IUILayoutParam(AnchorStyles.Right | AnchorStyles.Top, padding, size);
            //uiRightTopRect = new SimpleUIRect(param);

            //uiLeftBottomRect.Initialize();
            //uiLeftTopRect.Initialize();
            //uiRightBottomRect.Initialize();
            //uiRightTopRect.Initialize();

            ////IModel model = SphereModel.GetModel(2);
            //IModel model = IceCreamModel.GetModel(2, 10, 10);
            ////IModel model = CubeModel.GetModel();
            //element = new XRayElement(model);
            //element.Initialize();
            //element.BeforeRendering += element_BeforeRendering;
            //element.AfterRendering += element_AfterRendering;
            CreateElement();

            //lightElement = new PointLightElement();
            //lightElement.Initialize();
            //lightElement.BeforeRendering += pointLightElement_BeforeRendering;
            //lightElement.AfterRendering += pointLightElement_AfterRendering;

            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
            this.glCanvas1.KeyPress += glCanvas1_KeyPress;
            this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            this.glCanvas1.Resize += glCanvas1_Resize;

            Application.Idle += Application_Idle;
        }

        void Application_Idle(object sender, EventArgs e)
        {
            PrintCameraInfo();
        }

        void pointLightElement_AfterRendering(object sender, RenderEventArgs e)
        {
            IMVP element = sender as IMVP;

            element.ResetShaderProgram();
        }

        void pointLightElement_BeforeRendering(object sender, RenderEventArgs e)
        {
            mat4 projectionMatrix = camera.GetProjectionMat4();
            projectionMatrix = glm.translate(projectionMatrix, new vec3(translateX, translateY, translateZ));//
            //projectionMatrix = glm.scale(projectionMatrix, new vec3(0.1f, 0.1f, 0.1f));

            mat4 viewMatrix = camera.GetViewMat4();

            mat4 modelMatrix = glm.scale(mat4.identity(), new vec3(0.1f, 0.1f, 0.1f));

            mat4 mvp = projectionMatrix * viewMatrix * modelMatrix;

            IMVP element = sender as IMVP;

            element.SetShaderProgram(mvp);
        }

        void element_AfterRendering(object sender, CSharpGL.Objects.RenderEventArgs e)
        {
            //IMVP element = sender as IMVP;

            //element.ResetShaderProgram();
        }

        void element_BeforeRendering(object sender, CSharpGL.Objects.RenderEventArgs e)
        {
            mat4 projectionMatrix = camera.GetProjectionMat4();
            //projectionMatrix = glm.translate(projectionMatrix, new vec3(translateX, translateY, translateZ));//

            mat4 viewMatrix = camera.GetViewMat4();

            mat4 modelMatrix = mat4.identity();

            this.element.projectionMatrix = projectionMatrix;
            this.element.viewMatrix = viewMatrix;
            this.element.modelMatrix = modelMatrix;
        }

        private void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            this.camera.MouseWheel(e.Delta);
        }

        private void FormTranslateOnScreen_Load(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Use 'c' to switch camera types between perspective and ortho");
            builder.AppendLine("Use 'wsadqe' to translate light's position");
            builder.AppendLine("Use 'r' to reset lignt's position");
            builder.AppendLine("Use 'jk' to decrease/increase rendering element count");
            builder.AppendLine("Use 'p' to switch sphere's polygon mode");
            builder.AppendLine("Use 'm' to switch model");
            builder.AppendLine("Use '-' to decrease model size");
            builder.AppendLine("Use '+' to increase model size");
            MessageBox.Show(builder.ToString());
        }

        void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            PrintCameraInfo();

            GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            var arg = new RenderEventArgs(RenderModes.Render, this.camera);

            if (this.newElement != null)
            {
                this.element = this.newElement;
                this.newElement = null;
            }

            element.Render(arg);
            //lightElement.Render(arg);

            uiLeftBottomAxis.Render(arg);
            //uiLeftTopAxis.Render(arg);
            //uiRightBottomAxis.Render(arg);
            //uiRightTopAxis.Render(arg);

            //uiLeftBottomRect.Render(arg);
            //uiLeftTopRect.Render(arg);
            //uiRightBottomRect.Render(arg);
            //uiRightTopRect.Render(arg);
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
            if (satelliteRoration.MouseDownFlag)
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
            builder.Append(string.Format(" position:{0},", this.camera.Position));
            builder.Append(string.Format(" target:{0},", this.camera.Target));
            builder.Append(string.Format(" up:{0},", this.camera.UpVector));
            builder.Append(string.Format(" camera type: {0},", this.camera.CameraType));
            builder.Append(string.Format(" model size: {0}", this.radius));
            this.textBox1.Text = builder.ToString();
        }

        float translateX = 0, translateY = 0, translateZ = 0;
        const float interval = 0.1f;

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
            else if (e.KeyChar == 'j')
            {
                this.element.DecreaseVertexCount();
            }
            else if (e.KeyChar == 'k')
            {
                this.element.IncreaseVertexCount();
            }
            else if (e.KeyChar == 'p')
            {
                switch (this.element.polygonMode)
                {
                    case PolygonModes.Points:
                        this.element.polygonMode = PolygonModes.Lines;
                        break;
                    case PolygonModes.Lines:
                        this.element.polygonMode = PolygonModes.Filled;
                        break;
                    case PolygonModes.Filled:
                        this.element.polygonMode = PolygonModes.Points;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            else if (e.KeyChar == 'm')
            {
                currentModelIndex++;
                if (currentModelIndex >= factories.Length) { currentModelIndex = 0; }

                CreateElement();
            }
            else if (e.KeyChar == '-')
            {
                this.radius -= 0.1f;
                if (this.radius <= 0) { this.radius = 0.1f; }

                CreateElement();
            }
            else if (e.KeyChar == '+')
            {
                this.radius += 0.1f;

                CreateElement();
            }
        }

        private void CreateElement()
        {
            var element = new XRayElement(factories[currentModelIndex].Create(this.radius));
            element.Initialize();
            element.BeforeRendering += element_BeforeRendering;
            element.AfterRendering += element_AfterRendering;
            this.newElement = element;
        }

        int currentModelIndex = 1;
        //static readonly IModel[] models = new IModel[] { CubeModel.GetModel(), IceCreamModel.GetModel(), SphereModel.GetModel(), };
        static readonly ModelFactory[] factories = new ModelFactory[] { new CubeFactory(), new IceCreamFactory(), new SphereFactory(), new TeapotFactory(), };
        private float radius = 2;
        private XRayElement newElement;
    }
}
