using CSharpGL.Objects;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.Common;
using CSharpGL.Objects.Demos;
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

namespace CSharpGL.Winforms.Demo
{
    public partial class FormNormalLine : Form
    {
        GroundRenderer groundRenderer;

        SimpleUIAxis uiAxis;
        NormalLineRenderer renderer;
        NormalLineRenderer lifeBarRenderer;
        ArcBallRotator modelRotator;

        Camera camera;
        SatelliteRotator cameraRotator;

        //Camera modelRotationCamera;
        //SatelliteRotator modelRotator;
        //private float rotateAngle;

        public FormNormalLine()
        {
            InitializeComponent();

            this.camera = new Camera(CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
            this.camera.Position = new GLM.vec3(5, 5, 5);

            this.cameraRotator = new SatelliteRotator(this.camera);

            //this.modelRotationCamera = new Camera(CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
            //this.modelRotator = new SatelliteRotator(this.modelRotationCamera);
            this.modelRotator = new ArcBallRotator(this.camera);

            //this.groundRenderer = new GroundRenderer(new Ground(100, 100, 0.1f, 0.1f));
            this.groundRenderer = new GroundRenderer(new Ground(100, 100, 1f, 1f));
            this.groundRenderer.Initialize();

            Padding uiPadding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            Size uiSize = new System.Drawing.Size(50, 50);
            IUILayoutParam uiParam = new IUILayoutParam(AnchorStyles.Left | AnchorStyles.Bottom, uiPadding, uiSize);
            uiAxis = new SimpleUIAxis(uiParam);
            uiAxis.Initialize();

            IModel model = (new TeapotFactory()).Create(1.0f);
            this.renderer = new NormalLineRenderer(model);
            this.renderer.Initialize();//不在此显式初始化也可以。

            this.lifebar = new LifeBar(5, 0.2f, 4);
            this.lifeBarRenderer = new NormalLineRenderer(this.lifebar);
            this.lifeBarRenderer.Initialize();

            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
            this.glCanvas1.KeyPress += glCanvas1_KeyPress;
            this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            this.glCanvas1.Resize += glCanvas1_Resize;

            var displayer = new FormNormalLineDisplay(this.lifeBarRenderer);
            displayer.Show();
            displayer = new FormNormalLineDisplay(this.renderer);
            displayer.Show();

        }

        private void CreateElement()
        {
            var element = new NormalLineRenderer(factories[currentModelIndex].Create(this.radius));
            element.Initialize();
            this.newRenderer = element;
        }

        int currentModelIndex = 0;
        //static readonly IModel[] models = new IModel[] { CubeModel.GetModel(), IceCreamModel.GetModel(), SphereModel.GetModel(), };
        static readonly ModelFactory[] factories = new ModelFactory[] { new TeapotFactory(), new CubeFactory(), new IceCreamFactory(), new SphereFactory(), };
        private float radius = 1;
        NormalLineRenderer newRenderer;

        //private float translateX;
        //private float translateY;
        //private float translateZ;
        private vec3 translate = new vec3();
        private float interval = 0.1f;
        private LifeBar lifebar;

        private void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            this.camera.MouseWheel(e.Delta);
        }

        private void FormGLCanvas_Load(object sender, EventArgs e)
        {
            GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            glCanvas1_Resize(this.glCanvas1, e);

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("This is a diffuse reflection demo with directional light and ambient light.");
            builder.AppendLine("Use 'm' to change model.");
            builder.AppendLine("Use 'c' to switch camera types between perspective and ortho.");
            builder.AppendLine("Use right mouse to rotate camera.");
            builder.AppendLine("Use left mouse to rotate model.");
            builder.AppendLine("Use 'j' to decrease vertex count.");
            builder.AppendLine("Use 'k' to increase vertex count.");
            builder.AppendLine("Use '1' to show/hide model.");
            builder.AppendLine("Use '2' to show/hide normal.");

            MessageBox.Show(builder.ToString());

        }

        void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            if (this.newRenderer != null)
            {
                this.renderer = newRenderer;
                this.newRenderer = null;
            }

            var arg = new RenderEventArgs(RenderModes.Render, this.camera);
            mat4 projectionMatrix = camera.GetProjectionMat4();
            mat4 viewMatrix = camera.GetViewMat4();
            //mat4 modelMatrix = glm.rotate(rotateAngle, new vec3(0, 1, 0)); //modelRotationCamera.GetViewMat4(); //mat4.identity();
            //rotateAngle += 0.03f;
            //mat4 modelMatrix = this.modelRotator.GetModelRotation();//glm.rotate(rotateAngle, new vec3(0, 1, 0)); //modelRotationCamera.GetViewMat4(); //mat4.identity();
            mat4 modelMatrix = this.modelRotator.GetRotationMatrix();

            this.renderer.projectionMatrix = projectionMatrix;
            this.renderer.viewMatrix = glm.translate(viewMatrix, translate);
            this.renderer.modelMatrix = modelMatrix;

            this.lifeBarRenderer.projectionMatrix = projectionMatrix;
            this.lifeBarRenderer.viewMatrix = AlwaysFaceCamera(glm.translate(viewMatrix, translate));
            float length = (this.camera.Target - this.camera.Position).Magnitude();
            this.lifeBarRenderer.modelMatrix = glm.translate(AlwaysSameSize(viewMatrix), new vec3(0, 40 / length, 0));

            this.groundRenderer.projectionMatrix = projectionMatrix;
            this.groundRenderer.viewMatrix = viewMatrix;
            this.groundRenderer.modelMatrix = mat4.identity();

            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

            this.uiAxis.Render(arg);

            this.renderer.Render(arg);
            this.lifeBarRenderer.Render(arg);
            this.groundRenderer.Render(arg);
        }

        private mat4 AlwaysSameSize(mat4 viewMatrix)
        {
            float length = (this.camera.Target - this.camera.Position).Magnitude();
            //mat4 result = glm.translate(glm.scale(mat4.identity(),
            //    new vec3(length / this.lifebar.Length, length / this.lifebar.Wdith, 1)),
            //    new vec3(0, this.lifebar.Height / length, 0));
            mat4 result = glm.translate(glm.scale(mat4.identity(),
    new vec3(length / 8, length / 8, 1)),
    new vec3(0, this.lifebar.Height / length, 0));


            return result;
        }

        private mat4 AlwaysFaceCamera(mat4 viewMatrix)
        {
            mat4 result = mat4.identity();
            for (int i = 0; i < 3; i++)
            {
                vec4 v = result[i];
                v.w = viewMatrix[i].w;
                result[i] = v;
            }
            result[3] = viewMatrix[3];

            return result;
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
            else if (e.KeyChar == 'j')
            {
                this.renderer.DecreaseVertexCount();
            }
            else if (e.KeyChar == 'k')
            {
                this.renderer.IncreaseVertexCount();
            }
            else if (e.KeyChar == 'p')
            {
                switch (this.renderer.polygonMode)
                {
                    case PolygonModes.Points:
                        this.renderer.polygonMode = PolygonModes.Lines;
                        break;
                    case PolygonModes.Lines:
                        this.renderer.polygonMode = PolygonModes.Filled;
                        break;
                    case PolygonModes.Filled:
                        this.renderer.polygonMode = PolygonModes.Points;
                        break;
                    default:
                        break;
                }
            }
            else if (e.KeyChar == '1')
            {
                this.renderer.showModel = !this.renderer.showModel;
                this.lifeBarRenderer.showModel = !this.lifeBarRenderer.showModel;
            }
            else if (e.KeyChar == '2')
            {
                this.renderer.showNormal = !this.renderer.showNormal;
                this.lifeBarRenderer.showNormal = !this.lifeBarRenderer.showNormal;
            }
            else if (e.KeyChar == 'w')
            {
                vec3 direction = (this.camera.Target - this.camera.Position);
                direction.y = 0;
                direction.Normalize();
                vec3 movement = interval * direction;
                this.translate += movement;

                FollowTargetObject();
            }
            else if (e.KeyChar == 's')
            {
                vec3 direction = -(this.camera.Target - this.camera.Position);
                direction.y = 0;
                direction.Normalize();
                vec3 movement = interval * direction;
                this.translate += movement;

                FollowTargetObject();
            }
            else if (e.KeyChar == 'a')
            {
                vec3 direction = -this.camera.UpVector.cross(this.camera.Target - this.camera.Position);
                direction.y = 0;
                direction.Normalize();
                vec3 movement = interval * direction;
                this.translate += movement;

                FollowTargetObject();
            }
            else if (e.KeyChar == 'd')
            {
                vec3 direction = this.camera.UpVector.cross(-(this.camera.Target - this.camera.Position));
                direction.y = 0;
                direction.Normalize();
                vec3 movement = interval * direction;
                this.translate += movement;

                FollowTargetObject();
            }
        }

        private void FollowTargetObject()
        {
            vec3 eyeVector = this.camera.Position - this.camera.Target;
            this.camera.Target = this.translate;
            this.camera.Position = this.translate + eyeVector;
        }

    }
}
