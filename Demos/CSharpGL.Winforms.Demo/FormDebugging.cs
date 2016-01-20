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

namespace CSharpGL.Winforms.Demo
{
    public partial class FormDebugging : Form
    {
        LegacySimpleUIRect legacyLeftBottomRect;

        SimpleUIRect uiLeftBottomRect;
        SimpleUIAxis uiLeftBottomAxis;

        AxisElement axisElement;

        Camera camera;

        SatelliteRotator satelliteRoration;

        public FormDebugging()
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

            Padding padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            Size size = new Size(100, 100);
            IUILayoutParam param;
            param = new IUILayoutParam(AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right, padding, size);
            uiLeftBottomRect = new SimpleUIRect(param);
            legacyLeftBottomRect = new LegacySimpleUIRect(param, new Objects.GLColor(1, 1, 1, 1));
            param = new IUILayoutParam(AnchorStyles.Left | AnchorStyles.Bottom, padding, size);
            uiLeftBottomAxis = new SimpleUIAxis(param);

            uiLeftBottomRect.Initialize();
            legacyLeftBottomRect.Initialize();
            uiLeftBottomAxis.Initialize();

            axisElement = new AxisElement();
            axisElement.Initialize();

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
            mat4 projectionMatrix = camera.GetProjectionMat4();
            mat4 viewMatrix = camera.GetViewMat4();
            mat4 modelMatrix = mat4.identity();
            mat4 mvp = projectionMatrix * viewMatrix * modelMatrix;

            axisElement.mvp = mvp;
            axisElement.Render(arg);

            uiLeftBottomRect.Render(arg);
            //uiLeftTopRect.Render(arg);
            //uiRightBottomRect.Render(arg);
            //uiRightTopRect.Render(arg);

            legacyUIRect_BeforeRendering(this.legacyLeftBottomRect, arg);
            legacyLeftBottomRect.Render(arg);
            legacyUIRect_AfterRendering(this.legacyLeftBottomRect, arg);
            //legacyLeftTopRect.Render(arg);
            //legacyRightBottomRect.Render(arg);
            //legacyRightTopRect.Render(arg);

            uiLeftBottomAxis.Render(arg);
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
        }

        //CSharpGL.GL.DebugProc callback;
        private FormWhiteBoard frmWhiteBoard;
        private System.Runtime.InteropServices.GCHandle userParamInstance;

        private void FormDebugging_Load(object sender, EventArgs e)
        {
            frmWhiteBoard = new FormWhiteBoard();
            frmWhiteBoard.Show();

            byte x;
            x = GL.IsEnabled(GL.GL_DEBUG_OUTPUT);// x is 1

            GL.Disable(GL.GL_DEBUG_OUTPUT);
            x = GL.IsEnabled(GL.GL_DEBUG_OUTPUT);// x is 0

            GL.Enable(GL.GL_DEBUG_OUTPUT);
            x = GL.IsEnabled(GL.GL_DEBUG_OUTPUT);// x is 1

            x = GL.IsEnabled(GL.GL_DEBUG_OUTPUT_SYNCHRONOUS_ARB);// x is 0

            GL.Disable(GL.GL_DEBUG_OUTPUT_SYNCHRONOUS_ARB);
            x = GL.IsEnabled(GL.GL_DEBUG_OUTPUT_SYNCHRONOUS_ARB);// x is 0

            GL.Enable(GL.GL_DEBUG_OUTPUT_SYNCHRONOUS_ARB);
            x = GL.IsEnabled(GL.GL_DEBUG_OUTPUT_SYNCHRONOUS_ARB);// x is 1

            // 必须是struct
            UserParamStruct data = new UserParamStruct() { integer = 123, handle = this.glCanvas1.Handle };
            this.userParamInstance = System.Runtime.InteropServices.GCHandle.Alloc(
                data, System.Runtime.InteropServices.GCHandleType.Pinned);
            IntPtr ptr = userParamInstance.AddrOfPinnedObject();

            GL.DebugMessageCallback(this.callbackProc, ptr);

            GL.DebugMessageControl(
                 Enumerations.DebugMessageControlSource.DONT_CARE,
                 Enumerations.DebugMessageControlType.DONT_CARE,
                  Enumerations.DebugMessageControlSeverity.DONT_CARE,
                  0, null, true);

            StringBuilder builder = new StringBuilder();
            builder.Append("hello, this is app!");
            GL.DebugMessageInsert(
                Enumerations.DebugSource.DEBUG_SOURCE_APPLICATION_ARB,
                Enumerations.DebugType.DEBUG_TYPE_OTHER_ARB,
                0x4752415A,
                //Enumerations.DebugSeverity.DEBUG_SEVERITY_NOTIFICATION_ARB,// not valid
                Enumerations.DebugSeverity.DEBUG_SEVERITY_HIGH_ARB,
                //Enumerations.DebugSeverity.DEBUG_SEVERITY_MEDIUM_ARB,
                //Enumerations.DebugSeverity.DEBUG_SEVERITY_LOW_ARB,
                -1,
                builder);
        }

        struct UserParamStruct
        {
            public int integer;
            public IntPtr handle;
        }
        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);

            this.userParamInstance.Free();
        }
        private void callbackProc(CSharpGL.Enumerations.DebugSource source,
            CSharpGL.Enumerations.DebugType type,
            uint id,
            CSharpGL.Enumerations.DebugSeverity severity,
            int length,
            StringBuilder message,
            IntPtr userParam)
        {
            var obj = System.Runtime.InteropServices.Marshal.PtrToStructure(userParam, typeof(UserParamStruct));

            DateTime now = DateTime.Now;

            StringBuilder builder = new StringBuilder();
            {
                builder.AppendLine(string.Format("{0:yyyy-MM-dd HH:mm:ss.ffff}:", now));
                builder.Append("source: ");
                builder.Append(source); builder.Append(", ");
                builder.Append("type: ");
                builder.Append(type); builder.Append(", ");
                builder.Append("id: ");
                builder.Append(id); builder.Append(", ");
                builder.Append("severity: ");
                builder.Append(severity); builder.Append(", ");
                builder.Append("length: ");
                builder.Append(length); builder.Append(", ");
                builder.Append("message: ");
                if (message != null)
                {
                    builder.Append(message.ToString()); builder.Append(", ");
                }
                else
                {
                    builder.Append("<null>"); builder.Append(", ");
                }
                builder.Append("userParam: ");
                builder.Append(userParam);
                builder.AppendLine();
            }

            string text = builder.ToString();
            this.frmWhiteBoard.AppendText(text);

            string filename = string.Format("debuggingAndProfiling{0:yyyyMMddHHmm}.txt", now);
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filename, true))
            {
                sw.Write(text);
            }
        }
    }
}
