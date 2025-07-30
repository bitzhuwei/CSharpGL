using CSharpGL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace c14d00_HowTransformFeedbackWorks {
    class TransformFeedbackCalculator {
        private const string vertexCode = @"#version 150 core

in float inValue;
out float outValue;

void main()
{
    outValue = sqrt(inValue);
}
";

        public unsafe TransformFeedbackCalculator(int maxItemCount) {
            this.MaxItemCount = maxItemCount;

            //var program = new GLProgram();
            ////program.Initialize(varyings, ShaderProgram.BufferMode.InterLeaved, vertexShader);
            //var varyings = new string[] { "outValue" };
            //glTransformFeedbackVaryings(program.programId, varyings.Length, varyings, GL.GL_INTERLEAVED_ATTRIBS);
            //var vertexShader = new VertexShader(vertexCode);
            //vertexShader.Initialize();
            //glAttachShader(program.programId, vertexShader.shaderId);
            //glLinkProgram(program.programId);
            //program.CheckLinkStatus();

            var varyings = new string[] { "outValue" };
            var program = GLProgram.Create(varyings, GLProgram.BufferMode.InterLeaved,
                vertexCode); Debug.Assert(program != null);

            VertexBuffer vbo = VertexBuffer.Create(typeof(float), maxItemCount, VBOConfig.Float, GLBuffer.Usage.StaticDraw);
            var drawCmd = new DrawArraysCmd(CSharpGL.DrawMode.Points, maxItemCount);
            var vao = new VertexArrayObject(drawCmd, program, new VertexShaderAttribute[] { new VertexShaderAttribute(vbo, "inValue") });
            uint index = 0;
            VertexBuffer tbo = VertexBuffer.Create(typeof(float), maxItemCount, VBOConfig.Float, GLBuffer.Usage.StaticRead);
            var gl = GL.Current; Debug.Assert(gl != null);
            gl.glBindBufferBase(GL.GL_TRANSFORM_FEEDBACK_BUFFER, index, tbo.bufferId);

            {
                this.program = program;
                this.inputBuffer = vbo;
                this.outputBuffer = tbo;
                this.vao = vao;
                this.drawCommand = drawCmd;
            }
        }

        public int MaxItemCount { get; private set; }

        public unsafe void UpdateInput(params float[] values) {
            if (values.Length == 0) { return; }

            VertexBuffer buffer = this.inputBuffer;
            IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
            var array = (float*)pointer;
            for (int i = 0; i < values.Length && i < this.MaxItemCount; i++) {
                array[i] = values[i];
            }
            buffer.UnmapBuffer();
        }

        public unsafe void Calculate() {
            var gl = GL.Current; Debug.Assert(gl != null);
            gl.glEnable(GL.GL_RASTERIZER_DISCARD);

            this.program.Bind();
            gl.glBeginTransformFeedback(GL.GL_POINTS);
            this.vao.Draw();
            gl.glEndTransformFeedback();
            this.program.Unbind();

            gl.glDisable(GL.GL_RASTERIZER_DISCARD);
        }

        public unsafe float[] GetOutput(int count) {
            if (count < 0) { throw new ArgumentOutOfRangeException(); }
            if (count == 0) { return new float[0]; }
            var gl = GL.Current; Debug.Assert(gl != null);

            var array = new float[count];
            GCHandle pinned = GCHandle.Alloc(array, GCHandleType.Pinned);
            IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
            gl.glGetBufferSubData(GL.GL_TRANSFORM_FEEDBACK_BUFFER, 0, sizeof(float) * count, header);
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

        //private static readonly GLDelegates.void_uint_uint glAttachShader;
        //private static readonly GLDelegates.void_uint glLinkProgram;
        //private static readonly GLDelegates.void_uint_int_stringN_uint glTransformFeedbackVaryings;
        //private static readonly GLDelegates.void_uint_uint_uint glBindBufferBase;
        //private static readonly GLDelegates.void_uint glBeginTransformFeedback;
        //private static readonly GLDelegates.void_void glEndTransformFeedback;
        ////void glGetBufferSubData(GLenum target​, GLintptr offset​, GLsizeiptr size​, GLvoid * data​);
        //private static readonly GLDelegates.void_uint_int_int_IntPtr glGetBufferSubData;
        private VertexBuffer inputBuffer;
        private VertexBuffer outputBuffer;
        private DrawArraysCmd drawCommand;
        private GLProgram program;
        private VertexArrayObject vao;
        //static TransformFeedbackCalculator() {
        //    glAttachShader = GL.Current.GetDelegateFor("glAttachShader", GLDelegates.typeof_void_uint_uint) as GLDelegates.void_uint_uint;
        //    glLinkProgram = GL.Current.GetDelegateFor("glLinkProgram", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
        //    glTransformFeedbackVaryings = GL.Current.GetDelegateFor("glTransformFeedbackVaryings", GLDelegates.typeof_void_uint_int_stringN_uint) as GLDelegates.void_uint_int_stringN_uint;
        //    glBindBufferBase = GL.Current.GetDelegateFor("glBindBufferBase", GLDelegates.typeof_void_uint_uint_uint) as GLDelegates.void_uint_uint_uint;
        //    glBeginTransformFeedback = GL.Current.GetDelegateFor("glBeginTransformFeedback", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
        //    glEndTransformFeedback = GL.Current.GetDelegateFor("glEndTransformFeedback", GLDelegates.typeof_void_void) as GLDelegates.void_void;
        //    glGetBufferSubData = GL.Current.GetDelegateFor("glGetBufferSubData", GLDelegates.typeof_void_uint_int_int_IntPtr) as GLDelegates.void_uint_int_int_IntPtr;
        //}
    }
}
