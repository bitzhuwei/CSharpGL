using CSharpGL.Objects;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.Demos.UIs;
using CSharpGL.Objects.ModelFactories;
using CSharpGL.Objects.Models;
using CSharpGL.UIs;
using GLM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.LightEffects
{
    public partial class FormDiffuseReflection : Form
    {
        SimpleUIAxis uiAxis;
        DiffuseReflectionRenderer renderer;

        Camera camera;
        SatelliteRotator cameraRotator;

        Camera modelRotationCamera;
        SatelliteRotator modelRotator;
        private float rotateAngle;

        public FormDiffuseReflection()
        {
            InitializeComponent();

            this.camera = new Camera(CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
            this.camera.Position = new GLM.vec3(5, 5, 5);

            this.cameraRotator = new SatelliteRotator(this.camera);

            this.modelRotationCamera = new Camera(CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
            this.modelRotator = new SatelliteRotator(this.modelRotationCamera);

            Padding uiPadding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            Size uiSize = new System.Drawing.Size(50, 50);
            IUILayoutParam uiParam = new IUILayoutParam(AnchorStyles.Left | AnchorStyles.Bottom, uiPadding, uiSize);
            uiAxis = new SimpleUIAxis(uiParam);
            uiAxis.Initialize();

            IModel model = (new TeapotFactory()).Create(1.0f);
            this.renderer = new DiffuseReflectionRenderer(model);
            this.renderer.Initialize();//不在此显式初始化也可以。

            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
            this.glCanvas1.KeyPress += glCanvas1_KeyPress;
            this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            this.glCanvas1.Resize += glCanvas1_Resize;
        }

        private void CreateElement()
        {
            var element = new DiffuseReflectionRenderer(factories[currentModelIndex].Create(this.radius));
            element.Initialize();
            this.newRenderer = element;
        }

        int currentModelIndex = 1;
        //static readonly IModel[] models = new IModel[] { CubeModel.GetModel(), IceCreamModel.GetModel(), SphereModel.GetModel(), };
        static readonly ModelFactory[] factories = new ModelFactory[] { new CubeFactory(), new IceCreamFactory(), new SphereFactory(), new TeapotFactory(), };
        private float radius = 2;
        DiffuseReflectionRenderer newRenderer;

        private void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            this.camera.MouseWheel(e.Delta);
        }

        private void FormGLCanvas_Load(object sender, EventArgs e)
        {
            GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            glCanvas1_Resize(this.glCanvas1, e);

            FormDiffuseReflectionController form = new FormDiffuseReflectionController(this.renderer);
            form.Show();
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("This is a diffuse reflection demo with point light and ambient light.");
            builder.AppendLine("Use 'c' to switch camera types between perspective and ortho.");
            builder.AppendLine("Use right mouse to rotate camera.");
            builder.AppendLine("Use left mouse to rotate model.");

            MessageBox.Show(builder.ToString());

        }

        void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            var arg = new RenderEventArgs(RenderModes.Render, this.camera);
            mat4 projectionMatrix = camera.GetProjectionMat4();
            mat4 viewMatrix = camera.GetViewMat4();
            mat4 modelMatrix = glm.rotate(rotateAngle, new vec3(0, 1, 0)); //modelRotationCamera.GetViewMat4(); //mat4.identity();
            //rotateAngle += 0.03f;
            //mat4 modelMatrix = this.modelRotator.GetModelRotation();//glm.rotate(rotateAngle, new vec3(0, 1, 0)); //modelRotationCamera.GetViewMat4(); //mat4.identity();

            this.renderer.projectionMatrix = projectionMatrix;
            this.renderer.viewMatrix = viewMatrix;
            this.renderer.modelMatrix = modelMatrix;

            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

            this.uiAxis.Render(arg);
            if (this.newRenderer != null)
            {
                this.renderer = newRenderer;
                this.newRenderer = null;
            }
            this.renderer.Render(arg);
        }

        private void glCanvas1_Resize(object sender, EventArgs e)
        {
            ////  Set the projection matrix.
            //GL.MatrixMode(GL.GL_PROJECTION);

            ////  Load the identity.
            //GL.LoadIdentity();

            ////  Create a perspective transformation.
            //GL.gluPerspective(60.0f, (double)Width / (double)Height, 0.01, 100.0);

            ////  Use the 'look at' helper function to position and aim the camera.
            //GL.gluLookAt(-5, 5, -5, 0, 0, 0, 0, 1, 0);

            ////  Set the modelview matrix.
            //GL.MatrixMode(GL.GL_MODELVIEW);
        }


        private void glCanvas1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                modelRotator.SetBounds(this.glCanvas1.Width, this.glCanvas1.Height);
                modelRotator.MouseDown(e.X, e.Y);
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                cameraRotator.SetBounds(this.glCanvas1.Width, this.glCanvas1.Height);
                cameraRotator.MouseDown(e.X, e.Y);
            }

            PrintCameraInfo();
        }

        private void glCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                modelRotator.MouseMove(e.X, e.Y);
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right && cameraRotator.MouseDownFlag)
            {
                cameraRotator.MouseMove(e.X, e.Y);
            }
            PrintCameraInfo();
        }

        private void glCanvas1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                modelRotator.MouseUp(e.X, e.Y);
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                cameraRotator.MouseUp(e.X, e.Y);
            }
            PrintCameraInfo();
        }

        private void PrintCameraInfo()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(string.Format("position:{0}", this.camera.Position));
            builder.Append(string.Format(" target:{0}", this.camera.Target));
            builder.Append(string.Format(" up:{0}", this.camera.UpVector));
            builder.Append(string.Format(" camera type: {0}", this.camera.CameraType));

            //this.txtInfo.Text = builder.ToString();
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

                PrintCameraInfo();
            }
            else if (e.KeyChar == 'm')
            {
                currentModelIndex++;
                if (currentModelIndex >= factories.Length) { currentModelIndex = 0; }

                CreateElement();
            }
        }

    }
}
