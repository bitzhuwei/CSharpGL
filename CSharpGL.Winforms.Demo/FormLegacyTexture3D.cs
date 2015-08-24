using CSharpGL.Maths;
using CSharpGL.Objects;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.Demos;
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
    public partial class FormLegacyTexture3D : Form
    {
        LegacySimpleUIRect legacyUIRect;
        SimpleUIRect modernUIRect;
        SimpleUIAxis leftUIAxis;
        SimpleUIAxis rightUIAxis;
        DemoLegacyTexture3DCubeElement element;

        ScientificCamera camera;
        private SatelliteRotator satelliteRoration;

        public FormLegacyTexture3D()
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

            Padding padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            Size size = new Size(100, 100);
            //Size size = new Size(5, 5);
            IUILayoutParam param;
            param = new IUILayoutParam(AnchorStyles.Left | AnchorStyles.Bottom, padding, size);
            legacyUIRect = new LegacySimpleUIRect(param, new Objects.GLColor(1, 0, 0, 1));

            param = new IUILayoutParam(AnchorStyles.Bottom | AnchorStyles.Right, padding, size);
            modernUIRect = new SimpleUIRect(param, new GLColor(0, 1, 1, 1));

            param = new IUILayoutParam(AnchorStyles.Left | AnchorStyles.Bottom, padding, size);
            leftUIAxis = new SimpleUIAxis(param, new GLColor(1, 1, 1, 1));

            param = new IUILayoutParam(AnchorStyles.Right | AnchorStyles.Bottom, padding, size);
            rightUIAxis = new SimpleUIAxis(param, new GLColor(1, 1, 1, 1));


            legacyUIRect.Initialize();
            modernUIRect.Initialize();
            leftUIAxis.Initialize();
            rightUIAxis.Initialize();

            legacyUIRect.BeforeRendering += legacyUIRect_BeforeRendering;
            modernUIRect.BeforeRendering += SimpleUIElement_BeforeRendering;
            leftUIAxis.BeforeRendering += SimpleUIElement_BeforeRendering;
            rightUIAxis.BeforeRendering += SimpleUIElement_BeforeRendering;

            legacyUIRect.AfterRendering += legacyUIRect_AfterRendering;
            modernUIRect.AfterRendering += SimpleUIElement_AfterRendering;
            leftUIAxis.AfterRendering += SimpleUIElement_AfterRendering;
            rightUIAxis.AfterRendering += SimpleUIElement_AfterRendering;

            element = new DemoLegacyTexture3DCubeElement();
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

            UpdateInfo();
        }

        void element_AfterRendering(object sender, Objects.RenderEventArgs e)
        {
            GL.MatrixMode(GL.GL_MODELVIEW);
            GL.PopMatrix();

            GL.MatrixMode(GL.GL_PROJECTION);
            GL.PopMatrix();
        }

        void element_BeforeRendering(object sender, Objects.RenderEventArgs e)
        {
            GL.MatrixMode(GL.GL_PROJECTION);
            GL.PushMatrix();
            GL.LoadIdentity();
            GL.gluPerspective(60, (double)glCanvas1.Width / (double)glCanvas1.Height, 0.001, 1000);

            IViewCamera camera = this.camera;
            if (camera == null)
            {
                GL.gluLookAt(0, 0, 1, 0, 0, 0, 0, 1, 0);
                //throw new Exception("Camera not set!");
            }
            else
            {
                vec3 position = camera.Position - camera.Target;
                position.Normalize();
                GL.gluLookAt(position.x, position.y, position.z,
                    0, 0, 0,
                    camera.UpVector.x, camera.UpVector.y, camera.UpVector.z);
            }

            GL.MatrixMode(GL.GL_MODELVIEW);
            GL.PushMatrix();
            GL.LoadIdentity();
            GL.Scale(0.1, 0.1, 0.1);
        }

        void legacyUIRect_AfterRendering(object sender, Objects.RenderEventArgs e)
        {
            LegacySimpleUIRect element = sender as LegacySimpleUIRect;

            GL.MatrixMode(GL.GL_PROJECTION);
            GL.PopMatrix();

            GL.MatrixMode(GL.GL_MODELVIEW);
            GL.PopMatrix();
        }

        void legacyUIRect_BeforeRendering(object sender, Objects.RenderEventArgs e)
        {
            LegacySimpleUIRect element = sender as LegacySimpleUIRect;

            IUILayoutArgs args = element.GetArgs();

            GL.MatrixMode(GL.GL_PROJECTION);
            GL.PushMatrix();
            GL.LoadIdentity();
            GL.Ortho((float)args.left, (float)args.right, (float)args.bottom, (float)args.top, element.Param.zNear, element.Param.zFar);
            //GL.Ortho(args.left / 2, args.right / 2, args.bottom / 2, args.top / 2, element.Param.zNear, element.Param.zFar);

            IViewCamera camera = this.camera;
            if (camera == null)
            {
                GL.gluLookAt(0, 0, 1, 0, 0, 0, 0, 1, 0);
                //throw new Exception("Camera not set!");
            }
            else
            {
                vec3 position = camera.Position - camera.Target;
                position.Normalize();
                GL.gluLookAt(position.x, position.y, position.z,
                    0, 0, 0,
                    camera.UpVector.x, camera.UpVector.y, camera.UpVector.z);
            }

            GL.MatrixMode(GL.GL_MODELVIEW);
            GL.PushMatrix();
            GL.Scale(args.UIWidth / 2, args.UIHeight / 2, args.UIWidth);

        }


        void SimpleUIElement_AfterRendering(object sender, Objects.RenderEventArgs e)
        {
            IMVP element = sender as IMVP;
            element.UnbindShaderProgram();
        }

        void SimpleUIElement_BeforeRendering(object sender, Objects.RenderEventArgs e)
        {
            mat4 projectionMatrix, viewMatrix, modelMatrix;

            {
                IUILayout element = sender as IUILayout;
                element.GetMatrix(out projectionMatrix, out viewMatrix, out modelMatrix, this.camera);
            }

            {
                IMVP element = sender as IMVP;
                element.UpdateMVP(projectionMatrix * viewMatrix * modelMatrix);
            }
        }

        private void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            this.camera.MouseWheel(e.Delta);
        }

        private void FormTranslateOnScreen_Load(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("{1}{0}{2}",
                Environment.NewLine,
                "Use 'c' to switch camera types between perspective and ortho",
                "Use 'a' to switch render sign between legacy and modern opengl"));
        }

        void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            //PrintCameraInfo();

            GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            var arg = new RenderEventArgs(RenderModes.Render, this.camera);
            legacyUIRect.Render(arg);
            modernUIRect.Render(arg);
            leftUIAxis.Render(arg);
            rightUIAxis.Render(arg);
            element.Render(arg);
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

        //private void PrintCameraInfo()
        //{
        //    StringBuilder builder = new StringBuilder();
        //    builder.Append(string.Format("position:{0}", this.camera.Position));
        //    builder.Append(string.Format(" target:{0}", this.camera.Target));
        //    builder.Append(string.Format(" up:{0}", this.camera.UpVector));
        //    builder.Append(string.Format(" camera type: {0}", this.camera.CameraType));

        //    this.txtInfo.Text = builder.ToString();
        //}

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

        private void positiveX_Scroll(object sender, ScrollEventArgs e)
        {
            if (element == null) { return; }

            element.positiveX = (float)(100 - e.NewValue) / 100;
            element.positiveTexX = (float)(100 - e.NewValue) / 100 / 2 + 0.5f;
            UpdateInfo();
        }

        private void UpdateInfo()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(string.Format("+:{6}X:{0}~{3}{6}Y:{1}~{4}{6}Z:{2}~{5}",
                element.positiveX, element.positiveY, element.positiveZ,
                element.positiveTexX, element.positiveTexY, element.positiveTexZ,
                Environment.NewLine));
            builder.AppendLine();
            builder.Append(string.Format("-:{6}X:{0}~{3}{6}Y:{1}~{4}{6}Z:{2}~{5}",
                element.negativeX, element.negativeY, element.negativeZ,
                element.negativeTexX, element.negativeTexY, element.negativeTexZ,
                Environment.NewLine));

            this.lblInfo.Text = builder.ToString();
        }

        private void positiveY_Scroll(object sender, ScrollEventArgs e)
        {
            if (element == null) { return; }

            element.positiveY = (float)(100 - e.NewValue) / 100;
            element.positiveTexY = (float)(100 - e.NewValue) / 100 / 2 + 0.5f;
            UpdateInfo();
        }

        private void positiveZ_Scroll(object sender, ScrollEventArgs e)
        {
            if (element == null) { return; }

            element.positiveZ = (float)(100 - e.NewValue) / 100;
            element.positiveTexZ = (float)(100 - e.NewValue) / 100 / 2 + 0.5f;
            UpdateInfo();
        }

        private void negtiveX_Scroll(object sender, ScrollEventArgs e)
        {
            if (element == null) { return; }

            element.negativeX = (float)(-100 - e.NewValue) / 100;
            element.negativeTexX = (float)(-100 - e.NewValue) / 100 / 2 + 0.5f;
            UpdateInfo();
        }

        private void negtiveY_Scroll(object sender, ScrollEventArgs e)
        {
            if (element == null) { return; }

            element.negativeY = (float)(-100 - e.NewValue) / 100;
            element.negativeTexY = (float)(-100 - e.NewValue) / 100 / 2 + 0.5f;
            UpdateInfo();
        }

        private void negtiveZ_Scroll(object sender, ScrollEventArgs e)
        {
            if (element == null) { return; }

            element.negativeZ = (float)(-100 - e.NewValue) / 100;
            element.negativeTexZ = (float)(-100 - e.NewValue) / 100 / 2 + 0.5f;
            UpdateInfo();
        }
    }
}
