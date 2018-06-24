using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace c14d00_HowTransformFeedbackWorks
{
    class TransformFeedbackCalculator
    {
        private const string vertexCode = @"#version 150 core

in float inValue;
out float outValue;

void main()
{
    outValue = sqrt(inValue);
}
";

        public TransformFeedbackCalculator(int maxItemCount)
        {
            this.MaxItemCount = maxItemCount;

            var program = new ShaderProgram();
            //program.Initialize(varyings, ShaderProgram.BufferMode.InterLeaved, vertexShader);
            var varyings = new string[] { "outValue" };
            glTransformFeedbackVaryings(program.ProgramId, 1, varyings, GL.GL_INTERLEAVED_ATTRIBS);
            var vertexShader = new VertexShader(vertexCode);
            vertexShader.Initialize();
            glAttachShader(program.ProgramId, vertexShader.ShaderId);
            glLinkProgram(program.ProgramId);
            program.CheckLinkStatus();

            VertexBuffer vbo = VertexBuffer.Create(typeof(float), maxItemCount, VBOConfig.Float, BufferUsage.StaticDraw);
            var drawCmd = new DrawArraysCmd(DrawMode.Points, maxItemCount);
            var vao = new VertexArrayObject(drawCmd, program, new VertexShaderAttribute[] { new VertexShaderAttribute(vbo, "inValue") });
            uint index = 0;
            VertexBuffer tbo = VertexBuffer.Create(typeof(float), maxItemCount, VBOConfig.Float, BufferUsage.StaticRead);
            glBindBufferBase(GL.GL_TRANSFORM_FEEDBACK_BUFFER, index, tbo.BufferId);

            {
                this.program = program;
                this.inputBuffer = vbo;
                this.outputBuffer = tbo;
                this.vao = vao;
                this.drawCommand = drawCmd;
            }
        }

        public int MaxItemCount { get; private set; }

        public unsafe void UpdateInput(params float[] values)
        {
            if (values.Length == 0) { return; }

            VertexBuffer buffer = this.inputBuffer;
            IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
            var array = (float*)pointer;
            for (int i = 0; i < values.Length && i < this.MaxItemCount; i++)
            {
                array[i] = values[i];
            }
            buffer.UnmapBuffer();
        }

        public void Calculate()
        {
            GL.Instance.Enable(GL.GL_RASTERIZER_DISCARD);

            this.program.Bind();
            glBeginTransformFeedback(GL.GL_POINTS);
            this.vao.Draw();
            glEndTransformFeedback();
            this.program.Unbind();

            GL.Instance.Disable(GL.GL_RASTERIZER_DISCARD);
        }

        public float[] GetOutput(int count)
        {
            if (count < 0) { throw new ArgumentOutOfRangeException(); }
            if (count == 0) { return new float[0]; }

            var array = new float[count];
            GCHandle pinned = GCHandle.Alloc(array, GCHandleType.Pinned);
            IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
            glGetBufferSubData(GL.GL_TRANSFORM_FEEDBACK_BUFFER, 0, sizeof(float) * count, header);
            pinned.Free();

            return array;
        }

        //public unsafe float[] GetOutput(int count)
        //{
        //    if (count < 0) { throw new ArgumentOutOfRangeException(); }
        //    if (count == 0) { return new float[0]; }

        //    var result = new float[count];
        //    VertexBuffer buffer = this.outputBuffer;
        //    IntPtr pointer = buffer.MapBuffer(MapBufferAccess.ReadOnly);
        //    var array = (float*)pointer;
        //    for (int i = 0; i < result.Length && i < this.MaxItemCount; i++)
        //    {
        //        result[i] = array[i];
        //    }
        //    buffer.UnmapBuffer();

        //    return result;
        //}

        private static readonly GLDelegates.void_uint_uint glAttachShader;
        private static readonly GLDelegates.void_uint glLinkProgram;
        private static readonly GLDelegates.void_uint_int_stringN_uint glTransformFeedbackVaryings;
        private static readonly GLDelegates.void_uint_uint_uint glBindBufferBase;
        private static readonly GLDelegates.void_uint glBeginTransformFeedback;
        private static readonly GLDelegates.void_void glEndTransformFeedback;
        //void glGetBufferSubData(GLenum target​, GLintptr offset​, GLsizeiptr size​, GLvoid * data​);
        private static readonly GLDelegates.void_uint_int_int_IntPtr glGetBufferSubData;
        private VertexBuffer inputBuffer;
        private VertexBuffer outputBuffer;
        private DrawArraysCmd drawCommand;
        private ShaderProgram program;
        private VertexArrayObject vao;
        static TransformFeedbackCalculator()
        {
            glAttachShader = GL.Instance.GetDelegateFor("glAttachShader", GLDelegates.typeof_void_uint_uint) as GLDelegates.void_uint_uint;
            glLinkProgram = GL.Instance.GetDelegateFor("glLinkProgram", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
            glTransformFeedbackVaryings = GL.Instance.GetDelegateFor("glTransformFeedbackVaryings", GLDelegates.typeof_void_uint_int_stringN_uint) as GLDelegates.void_uint_int_stringN_uint;
            glBindBufferBase = GL.Instance.GetDelegateFor("glBindBufferBase", GLDelegates.typeof_void_uint_uint_uint) as GLDelegates.void_uint_uint_uint;
            glBeginTransformFeedback = GL.Instance.GetDelegateFor("glBeginTransformFeedback", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
            glEndTransformFeedback = GL.Instance.GetDelegateFor("glEndTransformFeedback", GLDelegates.typeof_void_void) as GLDelegates.void_void;
            glGetBufferSubData = GL.Instance.GetDelegateFor("glGetBufferSubData", GLDelegates.typeof_void_uint_int_int_IntPtr) as GLDelegates.void_uint_int_int_IntPtr;
        }
    }
}
