using CSharpGL.Maths;
using CSharpGL.Objects;
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
        SimpleUIAxis uiAxis;

        uint[] TimerQueryName = new uint[1];
        uint[] Query = new uint[1];

        private FormWhiteBoard frmWhiteBoard;
        private TransformShaderProgram TransformProgramName;
        private ShaderProgram FeedbackProgram;
        private uint[] BufferName;
        private uint[] TransformArrayBufferName;
        private uint[] FeedbackArrayBufferName;
        private uint[] TransformVertexArrayName;
        const uint POSITION = 0;
        private uint[] FeedbackVertexArrayName;
        const uint COLOR = 3;
        private uint[] FeedbackName;

        public FormTransformFeedback()
        {
            InitializeComponent();
        }

        private void FormTransformFeedback_Load(object sender, EventArgs e)
        {
            IUILayoutParam param = new IUILayoutParam(AnchorStyles.Left | AnchorStyles.Bottom, 
                new Padding(10, 10, 10, 10), new Size(50, 50));
            this.uiAxis = new SimpleUIAxis(param);

            frmWhiteBoard = new FormWhiteBoard();
            frmWhiteBoard.Show();

            GL.Enable(GL.GL_DEBUG_OUTPUT);
            GL.Enable(GL.GL_DEBUG_OUTPUT_SYNCHRONOUS_ARB);
            GL.DebugMessageControl(
                Enumerations.DebugMessageControlSource.DONT_CARE,
                Enumerations.DebugMessageControlType.DONT_CARE,
                Enumerations.DebugMessageControlSeverity.DONT_CARE, 0, null, true);
            GL.DebugMessageCallback(this.CallbackProc, this.Handle);

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
            FeedbackName = new uint[1];
            GL.GenTransformFeedbacks(1, FeedbackName);
            GL.BindTransformFeedback(GL.GL_TRANSFORM_FEEDBACK, FeedbackName[0]);
            GL.BindBufferBase(GL.GL_TRANSFORM_FEEDBACK_BUFFER, 0, FeedbackArrayBufferName[0]);
            GL.BindTransformFeedback(GL.GL_TRANSFORM_FEEDBACK, 0);

            return true;
        }
        bool initVertexArray()
        {
            // Build a vertex array object
            TransformVertexArrayName = new uint[1];
            GL.GenVertexArrays(1, TransformVertexArrayName);
            GL.BindVertexArray(TransformVertexArrayName[0]);
            GL.BindBuffer(BufferTarget.ArrayBuffer, TransformArrayBufferName[0]);
            //GL.VertexAttribPointer(semantic::attr::POSITION, 4, GL_FLOAT, GL_FALSE, 0, 0);
            GL.VertexAttribPointer(POSITION, 4, GL.GL_FLOAT, false, 0, IntPtr.Zero);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            GL.EnableVertexAttribArray(POSITION);
            GL.BindVertexArray(0);

            // Build a vertex array object
            FeedbackVertexArrayName = new uint[1];
            GL.GenVertexArrays(1, FeedbackVertexArrayName);
            GL.BindVertexArray(FeedbackVertexArrayName[0]);
            GL.BindBuffer(BufferTarget.ArrayBuffer, FeedbackArrayBufferName[0]);
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

            //int[] UniformBufferOffset = new int[1];
            //GL.GetInteger(GetTarget.UniformBufferOffsetAlignment, UniformBufferOffset);
            //int UniformBlockSize = Math.Max(64/*Marshal.SizeOf(typeof(mat4))*/, UniformBufferOffset[0]);

            GL.BindBuffer(BufferTarget.UniformBuffer, BufferName[1]);
            var buffer = new UnmanagedArray<float>(16);
            GL.BufferData(BufferTarget.UniformBuffer, buffer, BufferUsage.DynamicDraw);
            GL.BindBuffer(BufferTarget.UniformBuffer, 0);

            TransformArrayBufferName = new uint[1];
            GL.GenBuffers(TransformArrayBufferName.Length, TransformArrayBufferName);
            GL.BindBuffer(BufferTarget.ArrayBuffer, TransformArrayBufferName[0]);
            UnmanagedArray<vec4> positionData = new UnmanagedArray<vec4>(6);
            positionData[0] = new vec4(-1.0f, -1.0f, 0.0f, 1.0f);
            positionData[1] = new vec4(1.0f, -1.0f, 0.0f, 1.0f);
            positionData[2] = new vec4(1.0f, 1.0f, 0.0f, 1.0f);
            positionData[3] = new vec4(1.0f, 1.0f, 0.0f, 1.0f);
            positionData[4] = new vec4(-1.0f, 1.0f, 0.0f, 1.0f);
            positionData[5] = new vec4(-1.0f, -1.0f, 0.0f, 1.0f);
            GL.BufferData(BufferTarget.ArrayBuffer, positionData, BufferUsage.StaticDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            FeedbackArrayBufferName = new uint[1];
            GL.GenBuffers(FeedbackArrayBufferName.Length, FeedbackArrayBufferName);
            GL.BindBuffer(BufferTarget.ArrayBuffer, FeedbackArrayBufferName[0]);
            UnmanagedArray<vec4> tmp = new UnmanagedArray<vec4>(2 * 6);
            GL.BufferData(BufferTarget.ArrayBuffer, tmp, BufferUsage.StaticDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        private void InitProgram()
        {
            {
                var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"TransformFeedback.transform.vert");
                TransformProgramName = new TransformShaderProgram();
                TransformProgramName.Create(vertexShaderSource);
                TransformProgramName.AssertValid();
            }
            {
                var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"TransformFeedback.feedback.vert");
                var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"TransformFeedback.feedback.frag");

                FeedbackProgram = new ShaderProgram();
                FeedbackProgram.Create(vertexShaderSource, fragmentShaderSource, null);
                FeedbackProgram.AssertValid();
            }
            {
                var index = GL.GetUniformBlockIndex(TransformProgramName.ShaderProgramObject, "transform");
                GL.UniformBlockBinding(FeedbackProgram.ShaderProgramObject, index, (uint)UniformType.TRANSFORM0);
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
            //
            //GL.m::vec2 WindowSize(this->getWindowSize());

            // Compute the MVP (Model View Projection matrix)
            {
                GL.BindBuffer(BufferTarget.UniformBuffer, BufferName[1]);//BufferName[TRANSFORM]
                //GL.m::mat4* Pointer = reinterpret_cast<GL.m::mat4*>(GL.MapBufferRange(GL_UNIFORM_BUFFER, 0, sizeof(GL.m::mat4), GL_MAP_WRITE_BIT | GL_MAP_INVALIDATE_BUFFER_BIT));
                var Pointer = GL.MapBufferRange(GL.GL_UNIFORM_BUFFER, 0, 64, (uint)(GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT));
                //GL.m::mat4 Projection = GL.m::perspective(GL.m::pi<float>() * 0.25f, WindowSize.x / WindowSize.y, 0.1f, 100.0f);
                mat4 projection = glm.perspective((float)Math.PI * 0.25f, (float)this.glCanvas1.Width / (float)this.glCanvas1.Height, 0.1f, 100.0f);
                mat4 Model = mat4.identity();
                var newMat4 = projection * this.view() * Model;

                UnmanagedArray<float> tmp = new UnmanagedArray<float>(16);
                var floats = newMat4.to_array();
                for (int i = 0; i < 16; i++)
                {
                    tmp[i] = floats[i];
                }
                //MemoryHelper.CopyMemory(Pointer, tmp.Header, 64);
                tmp.CopyTo(Pointer);

                GL.UnmapBuffer(GL.GL_UNIFORM_BUFFER);

                tmp.Dispose();
            }

            // Set the display viewport
            //GL.Viewport(0, 0, static_cast<GLsizei>(WindowSize.x), static_cast<GLsizei>(WindowSize.y));

            // Clear color buffer
            //GL.ClearBufferfv(GL_COLOR, 0, &GL.m.vec4(0.0f, 0.0f, 0.0f, 1.0f)[0]);
            GL.ClearBuffer(GL.GL_COLOR, 0, new float[] { 0.0f, 0.0f, 0.0f, 1.0f });

            // First draw, capture the attributes
            // Disable rasterisation, vertices processing only!
            GL.Enable(GL.GL_RASTERIZER_DISCARD);

            //GL.UseProgram(TransformProgramName);
            TransformProgramName.Bind();

            GL.BindVertexArray(TransformVertexArrayName[0]);
            //GL.BindBufferBase(GL.GL_UNIFORM_BUFFER, semantic.uniform.TRANSFORM0, BufferName[buffer.TRANSFORM]);
            GL.BindBufferBase(GL.GL_UNIFORM_BUFFER, 1, BufferName[1]);

            GL.BindTransformFeedback(GL.GL_TRANSFORM_FEEDBACK, FeedbackName[0]);
            GL.BeginTransformFeedback(GL.GL_TRIANGLES);
            GL.DrawArraysInstanced(GL.GL_TRIANGLES, 0, 6, 1);//VertexCount: 6
            GL.EndTransformFeedback();
            GL.BindTransformFeedback(GL.GL_TRANSFORM_FEEDBACK, 0);

            GL.Disable(GL.GL_RASTERIZER_DISCARD);

            // Second draw, reuse the captured attributes
            //GL.UseProgram(FeedbackProgram);
            FeedbackProgram.Bind();

            GL.BindVertexArray(FeedbackVertexArrayName[0]);
            GL.DrawTransformFeedback(GL.GL_TRIANGLES, FeedbackName[0]);

        }

        mat4 view()
        {
            translateZ += 0.1f;
            rotateX += 0.1f;
            rotateY += 0.1f;
            //mat4 ViewTranslate = glm.translate(mat4.identity(), new vec3(0.0f, 0.0f, -this->TranlationCurrent.y));
            mat4 ViewTranslate = glm.translate(mat4.identity(), new vec3(0.0f, 0.0f, translateZ));
            //mat4 ViewRotateX = glm.rotate(ViewTranslate, this->RotationCurrent.y, new vec3(1.f, 0.f, 0.f));
            mat4 ViewRotateX = glm.rotate(ViewTranslate, rotateY, new vec3(1.0f, 0.0f, 0.0f));
            //mat4 View = glm.rotate(ViewRotateX, this->RotationCurrent.x, glm.vec3(0.f, 1.f, 0.f));
            mat4 View = glm.rotate(ViewRotateX, rotateX, new vec3(0.0f, 1.0f, 0.0f));
            return View;
        }

        float translateZ;
        float rotateY;
        float rotateX;
    }
}
