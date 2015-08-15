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
    public partial class FormDebugging : Form
    {
        LegacySimpleUIRect legacyLeftBottomRect;
        //LegacySimpleUIRect legacyLeftTopRect;
        //LegacySimpleUIRect legacyRightBottomRect;
        //LegacySimpleUIRect legacyRightTopRect;

        SimpleUIRect uiLeftBottomRect;
        //SimpleUIRect uiLeftTopRect;
        //SimpleUIRect uiRightBottomRect;
        //SimpleUIRect uiRightTopRect;

        AxisElement axisElement;

        ScientificCamera camera;

        SatelliteRotator satelliteRoration;

        public FormDebugging()
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
            param = new IUILayoutParam(AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right, padding, size);
            uiLeftBottomRect = new SimpleUIRect(param);
            //param = new IUILayoutParam(AnchorStyles.Left | AnchorStyles.Bottom, new Padding(0, 0, 0, 0), new Size(50, 50));
            legacyLeftBottomRect = new LegacySimpleUIRect(param, new Objects.GLColor(1, 1, 1, 1));

            //param = new IUILayoutParam(AnchorStyles.Left | AnchorStyles.Top, padding, size);
            //uiLeftTopRect = new SimpleUIRect(param);
            //legacyLeftTopRect = new LegacySimpleUIRect(param, new Objects.GLColor(1, 1, 1, 1));

            //param = new IUILayoutParam(AnchorStyles.Right | AnchorStyles.Bottom, padding, size);
            //uiRightBottomRect = new SimpleUIRect(param);
            //legacyRightBottomRect = new LegacySimpleUIRect(param, new Objects.GLColor(1, 1, 1, 1));

            //param = new IUILayoutParam(AnchorStyles.Right | AnchorStyles.Top, padding, size);
            //uiRightTopRect = new SimpleUIRect(param);
            //legacyRightTopRect = new LegacySimpleUIRect(param, new Objects.GLColor(1, 1, 1, 1));

            uiLeftBottomRect.Initialize();
            //uiLeftTopRect.Initialize();
            //uiRightBottomRect.Initialize();
            //uiRightTopRect.Initialize();

            legacyLeftBottomRect.Initialize();
            //legacyLeftTopRect.Initialize();
            //legacyRightBottomRect.Initialize();
            //legacyRightTopRect.Initialize();

            uiLeftBottomRect.BeforeRendering += SimpleUIRect_BeforeRendering;
            //uiLeftTopRect.BeforeRendering += SimpleUIRect_BeforeRendering;
            //uiRightBottomRect.BeforeRendering += SimpleUIRect_BeforeRendering;
            //uiRightTopRect.BeforeRendering += SimpleUIRect_BeforeRendering;

            legacyLeftBottomRect.BeforeRendering += legacyUIRect_BeforeRendering;
            //legacyLeftTopRect.BeforeRendering += legacyUIRect_BeforeRendering;
            //legacyRightBottomRect.BeforeRendering += legacyUIRect_BeforeRendering;
            //legacyRightTopRect.BeforeRendering += legacyUIRect_BeforeRendering;

            uiLeftBottomRect.AfterRendering += SimpleUIRect_AfterRendering;
            //uiLeftTopRect.AfterRendering += SimpleUIRect_AfterRendering;
            //uiRightBottomRect.AfterRendering += SimpleUIRect_AfterRendering;
            //uiRightTopRect.AfterRendering += SimpleUIRect_AfterRendering;

            legacyLeftBottomRect.AfterRendering += legacyUIRect_AfterRendering;
            //legacyLeftTopRect.AfterRendering += legacyUIRect_AfterRendering;
            //legacyRightBottomRect.AfterRendering += legacyUIRect_AfterRendering;
            //legacyRightTopRect.AfterRendering += legacyUIRect_AfterRendering;

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
            GL.Ortho(args.left, args.right, args.bottom, args.top, element.Param.zNear, element.Param.zFar);

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


        void SimpleUIRect_AfterRendering(object sender, Objects.RenderEventArgs e)
        {
            SimpleUIRect element = sender as SimpleUIRect;

            element.shaderProgram.Unbind();
        }

        void SimpleUIRect_BeforeRendering(object sender, Objects.RenderEventArgs e)
        {
            SimpleUIRect element = sender as SimpleUIRect;

            mat4 projectionMatrix, viewMatrix, modelMatrix;

            element.GetMatrix(out projectionMatrix, out viewMatrix, out modelMatrix, this.camera);

            ShaderProgram shaderProgram = element.shaderProgram;

            shaderProgram.Bind();

            shaderProgram.SetUniformMatrix4(SimpleUIRect.strprojectionMatrix, projectionMatrix.to_array());
            shaderProgram.SetUniformMatrix4(SimpleUIRect.strviewMatrix, viewMatrix.to_array());
            shaderProgram.SetUniformMatrix4(SimpleUIRect.strmodelMatrix, modelMatrix.to_array());
        }

        void axisElement_AfterRendering(object sender, Objects.RenderEventArgs e)
        {
            AxisElement element = sender as AxisElement;

            element.shaderProgram.Unbind();
        }

        void axisElement_BeforeRendering(object sender, Objects.RenderEventArgs e)
        {
            AxisElement element = sender as AxisElement;

            mat4 projectionMatrix = camera.GetProjectionMat4();

            mat4 viewMatrix = camera.GetViewMat4();

            mat4 modelMatrix = mat4.identity();

            ShaderProgram shaderProgram = element.shaderProgram;

            shaderProgram.Bind();

            shaderProgram.SetUniformMatrix4(AxisElement.strprojectionMatrix, projectionMatrix.to_array());
            shaderProgram.SetUniformMatrix4(AxisElement.strviewMatrix, viewMatrix.to_array());
            shaderProgram.SetUniformMatrix4(AxisElement.strmodelMatrix, modelMatrix.to_array());
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

            uiLeftBottomRect.Render(Objects.RenderModes.Render);
            //uiLeftTopRect.Render(Objects.RenderModes.Render);
            //uiRightBottomRect.Render(Objects.RenderModes.Render);
            //uiRightTopRect.Render(Objects.RenderModes.Render);

            legacyLeftBottomRect.Render(Objects.RenderModes.Render);
            //legacyLeftTopRect.Render(Objects.RenderModes.Render);
            //legacyRightBottomRect.Render(Objects.RenderModes.Render);
            //legacyRightTopRect.Render(Objects.RenderModes.Render);
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

        private void FormDebugging_Load(object sender, EventArgs e)
        {
            byte x;
            x = GL.IsEnabled(GL.GL_DEBUG_OUTPUT_SYNCHRONOUS_ARB);// x is 0

            GL.Disable(GL.GL_DEBUG_OUTPUT_SYNCHRONOUS_ARB);
            x = GL.IsEnabled(GL.GL_DEBUG_OUTPUT_SYNCHRONOUS_ARB);// x is 0

            GL.Enable(GL.GL_DEBUG_OUTPUT_SYNCHRONOUS_ARB);
            x = GL.IsEnabled(GL.GL_DEBUG_OUTPUT_SYNCHRONOUS_ARB);// x is 1

            GL.DebugMessageCallback(callback, IntPtr.Zero);

            GL.DebugMessageControl(GL.GL_DONT_CARE, GL.GL_DONT_CARE, GL.GL_DONT_CARE, 0, null, true);
        }

        private void callback(CSharpGL.Enumerations.DebugSource source,
            CSharpGL.Enumerations.DebugType type,
            uint id,
            CSharpGL.Enumerations.DebugSeverity severity,
            int length,
            StringBuilder message,
            IntPtr userParam)
        {
            Console.WriteLine("hello debugging2!");
        }
    }
}
