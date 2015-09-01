using CSharpGL.Maths;
using CSharpGL.Objects;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.Demos.UIs;
using CSharpGL.Objects.Shaders;
using CSharpGL.Objects.UIs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.Winforms.Demo
{
    public partial class FormTransformFeedback : Form
    {
        FormWhiteBoard frmWhiteBoard;

        SimpleUIAxis uiAxis;
        Camera camera;
        SatelliteRotator satelliteRoration;

        uint[] TimerQueryName = new uint[1];
        uint[] Query = new uint[1];

        private TransformShaderProgram transformProgram;
        private ShaderProgram feedbackProgram;
        private uint[] BufferName;
        private uint[] transformBuffer;
        private uint[] feedBackBuffer;
        private uint[] transformArray;
        const uint POSITION = 0;
        const uint COLOR = 3;
        private uint[] feedbackArray;
        private uint[] feedbackObj;

        public FormTransformFeedback()
        {
            InitializeComponent();

            this.camera = new Camera(CameraType.Ortho, this.glCanvas1.Width, this.glCanvas1.Height);
            satelliteRoration = new SatelliteRotator(camera);

            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
            this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            this.glCanvas1.Resize += glCanvas1_Resize;
        }
        private void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            this.camera.MouseWheel(e.Delta);
        }

        private void glCanvas1_Resize(object sender, EventArgs e)
        {
            if (this.camera != null)
            {
                this.camera.Resize(this.glCanvas1.Width, this.glCanvas1.Height);
            }
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
        private void FormTransformFeedback_Load(object sender, EventArgs e)
        {
            IUILayoutParam param = new IUILayoutParam(AnchorStyles.Left | AnchorStyles.Bottom,
                new Padding(10, 10, 10, 10), new Size(50, 50));
            this.uiAxis = new SimpleUIAxis(param);

            //frmWhiteBoard = new FormWhiteBoard();
            //frmWhiteBoard.Show();

            //GL.Enable(GL.GL_DEBUG_OUTPUT);
            //GL.Enable(GL.GL_DEBUG_OUTPUT_SYNCHRONOUS_ARB);
            //GL.DebugMessageControl(
            //    Enumerations.DebugMessageControlSource.DONT_CARE,
            //    Enumerations.DebugMessageControlType.DONT_CARE,
            //    Enumerations.DebugMessageControlSeverity.DONT_CARE, 0, null, true);
            //GL.DebugMessageCallback(this.CallbackProc, this.Handle);

            GL.GenQueries(1, TimerQueryName);

            // begin
            GL.GenQueries(1, Query);

            InitProgram();

            InitBuffer();

            initVertexArray();

            initFeedback();
        }

        bool initFeedback()
        {
            // Generate a buffer object
            feedbackObj = new uint[1];
            GL.GenTransformFeedbacks(1, feedbackObj);
            GL.BindTransformFeedback(GL.GL_TRANSFORM_FEEDBACK, feedbackObj[0]);
            //GL.BindBufferBase(GL.GL_TRANSFORM_FEEDBACK_BUFFER, 0, feedBackBuffer[0]);
            GL.BindBufferBase(TransformFeedbackBufferTarget.TransformFeedbackBuffer, 0, feedBackBuffer[0]);
            GL.BindTransformFeedback(GL.GL_TRANSFORM_FEEDBACK, 0);

            return true;
        }
        bool initVertexArray()
        {
            // Build a vertex array object
            transformArray = new uint[1];
            GL.GenVertexArrays(1, transformArray);
            GL.BindVertexArray(transformArray[0]);
            GL.BindBuffer(BufferTarget.ArrayBuffer, transformBuffer[0]);
            GL.VertexAttribPointer(POSITION, 4, GL.GL_FLOAT, false, 0, IntPtr.Zero);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            GL.EnableVertexAttribArray(POSITION);
            GL.BindVertexArray(0);

            // Build a vertex array object
            feedbackArray = new uint[1];
            GL.GenVertexArrays(1, feedbackArray);
            GL.BindVertexArray(feedbackArray[0]);
            GL.BindBuffer(BufferTarget.ArrayBuffer, feedBackBuffer[0]);
            GL.VertexAttribPointer(POSITION, 4, GL.GL_FLOAT, false, 4 * 8, IntPtr.Zero);
            GL.VertexAttribPointer(COLOR, 4, GL.GL_FLOAT, false, 4 * 8, new IntPtr(16));
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            GL.EnableVertexAttribArray(POSITION);
            GL.EnableVertexAttribArray(COLOR);
            GL.BindVertexArray(0);

            return true;
        }

        private void InitBuffer()
        {
            BufferName = new uint[2];
            GL.GenBuffers(BufferName.Length, BufferName);

            int[] UniformBufferOffset = new int[1];
            GL.GetInteger(GetTarget.UniformBufferOffsetAlignment, UniformBufferOffset);
            int mat4Size = Marshal.SizeOf(typeof(mat4));
            int UniformBlockSize = Math.Max(mat4Size, UniformBufferOffset[0]);

            GL.BindBuffer(BufferTarget.UniformBuffer, BufferName[1]);
            var buffer = new UnmanagedArray<byte>(UniformBlockSize);
            GL.BufferData(BufferTarget.UniformBuffer, buffer, BufferUsage.DynamicDraw);
            GL.BindBuffer(BufferTarget.UniformBuffer, 0);

            transformBuffer = new uint[1];
            GL.GenBuffers(transformBuffer.Length, transformBuffer);
            GL.BindBuffer(BufferTarget.ArrayBuffer, transformBuffer[0]);
            UnmanagedArray<vec4> positionData = new UnmanagedArray<vec4>(6);
            positionData[0] = new vec4(-1.0f, -1.0f, 0.0f, 1.0f);
            positionData[1] = new vec4(1.0f, -1.0f, 0.0f, 1.0f);
            positionData[2] = new vec4(1.0f, 1.0f, 0.0f, 1.0f);
            positionData[3] = new vec4(1.0f, 1.0f, 0.0f, 1.0f);
            positionData[4] = new vec4(-1.0f, 1.0f, 0.0f, 1.0f);
            positionData[5] = new vec4(-1.0f, -1.0f, 0.0f, 1.0f);
            GL.BufferData(BufferTarget.ArrayBuffer, positionData, BufferUsage.StaticDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            feedBackBuffer = new uint[1];
            GL.GenBuffers(feedBackBuffer.Length, feedBackBuffer);
            GL.BindBuffer(BufferTarget.ArrayBuffer, feedBackBuffer[0]);
            UnmanagedArray<vec4> tmp = new UnmanagedArray<vec4>(2 * 6);
            GL.BufferData(BufferTarget.ArrayBuffer, tmp, BufferUsage.StaticDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        private void InitProgram()
        {
            {
                var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"TransformFeedback.transform.vert");
                transformProgram = new TransformShaderProgram();
                transformProgram.Create(vertexShaderSource);
                transformProgram.AssertValid();
            }
            {
                var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"TransformFeedback.feedback.vert");
                var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"TransformFeedback.feedback.frag");

                feedbackProgram = new ShaderProgram();
                feedbackProgram.Create(vertexShaderSource, fragmentShaderSource, null);
                feedbackProgram.AssertValid();
            }
            {
                var index = GL.GetUniformBlockIndex(transformProgram.ShaderProgramObject, "transform");
                GL.UniformBlockBinding(transformProgram.ShaderProgramObject, index, (uint)UniformType.TRANSFORM0);
            }
        }

        void CallbackProc(
            CSharpGL.Enumerations.DebugSource source,
            CSharpGL.Enumerations.DebugType type,
            uint id,
            CSharpGL.Enumerations.DebugSeverity severity,
            int length,
            StringBuilder message,
            IntPtr userParam)
        {
            FormTransformFeedback thisForm = FormTransformFeedback.FromHandle(userParam) as FormTransformFeedback;

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

            if (!this.frmWhiteBoard.IsDisposed)
            {
                this.frmWhiteBoard.AppendText(text);
            }
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            GL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

            var arg = new RenderEventArgs(RenderModes.Render, null);

            this.uiAxis.Render(arg);

            DoRender(sender, e);
        }

        private void DoRender(object sender, PaintEventArgs e)
        {
            // Compute the MVP (Model View Projection matrix)
            {
                GL.BindBuffer(BufferTarget.UniformBuffer, BufferName[1]);//BufferName[TRANSFORM]
                var mvpPointer = GL.MapBufferRange(GL.GL_UNIFORM_BUFFER, 0, 64, (uint)(GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT));

                var tmp = new UnmanagedArray<mat4>(1);
                mat4 projection = this.camera.GetProjectionMat4();
                mat4 view = this.camera.GetViewMat4();
                //tmp[0] = projection * view;
                //tmp.CopyTo(Pointer);
                unsafe
                {
                    mat4* array = (mat4*)mvpPointer.ToPointer();
                    array[0] = projection * view;
                }

                GL.UnmapBuffer(GL.GL_UNIFORM_BUFFER);

                tmp.Dispose();
            }

            // Clear color buffer
            //GL.ClearBufferfv(GL_COLOR, 0, &GL.m.vec4(0.0f, 0.0f, 0.0f, 1.0f)[0]);
            GL.ClearBuffer(GL.GL_COLOR, 0, new float[] { 0.0f, 0.0f, 0.0f, 1.0f });

            // First draw, capture the attributes
            // Disable rasterisation, vertices processing only!
            GL.Enable(GL.GL_RASTERIZER_DISCARD);

            transformProgram.Bind();

            GL.BindVertexArray(transformArray[0]);
            //GL.BindBufferBase(GL.GL_UNIFORM_BUFFER, semantic.uniform.TRANSFORM0, BufferName[buffer.TRANSFORM]);
            GL.BindBufferBase(GL.GL_UNIFORM_BUFFER, 1, BufferName[1]);

            GL.BindTransformFeedback(GL.GL_TRANSFORM_FEEDBACK, feedbackObj[0]);
            GL.BeginTransformFeedback(GL.GL_TRIANGLES);
            GL.DrawArraysInstanced(GL.GL_TRIANGLES, 0, 6, 1);//VertexCount: 6
            GL.EndTransformFeedback();
            GL.BindTransformFeedback(GL.GL_TRANSFORM_FEEDBACK, 0);

            GL.Disable(GL.GL_RASTERIZER_DISCARD);

            // Second draw, reuse the captured attributes
            feedbackProgram.Bind();

            GL.BindVertexArray(feedbackArray[0]);
            GL.DrawTransformFeedback(GL.GL_TRIANGLES, feedbackObj[0]);

        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);

            GL.DeleteVertexArrays(1, transformArray);
            GL.DeleteBuffers(1, transformBuffer);
            transformProgram.Delete();

            GL.DeleteVertexArrays(1, feedbackArray);
            GL.DeleteBuffers(1, feedBackBuffer);
            feedbackProgram.Delete();

            GL.DeleteQueries(1, Query);
            GL.DeleteTransformFeedbacks(1, feedbackObj);

        }
    }
}
