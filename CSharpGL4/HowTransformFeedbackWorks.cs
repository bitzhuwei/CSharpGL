using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpGL
{
    public partial class HowTransformFeedbackWorks
    {
        private const string vertexShaderSrc = @"
    #version 150 core

    in float inValue;
    out float outValue;

    void main()
    {
        outValue = sqrt(inValue);
    }
";

        public static void Run()
        {
            // Compile shader
            var shader = new VertexShader(vertexShaderSrc, "inValue");
            shader.Initialize();

            // Create program and specify transform feedback variables
            var program = new ShaderProgram();
            var feedbackVaryings = new string[] { "outValue" };
            program.Initialize(feedbackVaryings, ShaderProgram.BufferMode.InterLeaved, shader);

            var data = new float[] { 1, 2, 3, 4, 5 };
            //var vbo = new uint[1];
            //VertexBuffer.glGenBuffers(1, vbo);
            //VertexBuffer.glBindBuffer(GL.GL_ARRAY_BUFFER, vbo[0]);
            //{
            //    GCHandle pinned = GCHandle.Alloc(data, GCHandleType.Pinned);
            //    IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(data, 0);
            //    VertexBuffer.glBufferData(GL.GL_ARRAY_BUFFER, sizeof(float) * data.Length, header, GL.GL_STATIC_DRAW);
            //    pinned.Free();
            //}
            VertexBuffer vbo = data.GenVertexBuffer(VBOConfig.Float, BufferUsage.StaticDraw);

            //var vao = new uint[1];
            //VertexArrayObject.glGenVertexArrays(1, vao);
            //VertexArrayObject.glBindVertexArray(vao[0]);
            //uint inputAttrib = (uint)ShaderProgram.glGetAttribLocation(program.ProgramId, "inValue");
            //vbo.Bind();
            //VertexBuffer.glEnableVertexAttribArray(inputAttrib);
            //VertexBuffer.glVertexAttribPointer(inputAttrib, 1, GL.GL_FLOAT, false, 0, IntPtr.Zero);
            var indexBuffer = ZeroIndexBuffer.Create(DrawMode.Points, 0, data.Length);
            var vao = new VertexArrayObject(indexBuffer, new VertexShaderAttribute(vbo, "inValue"));
            vao.Initialize(program);

            // Create transform feedback buffer
            //var tbo = new uint[1];
            //VertexBuffer.glGenBuffers(1, tbo);
            //VertexBuffer.glBindBuffer(GL.GL_ARRAY_BUFFER, tbo[0]);
            //{
            //    GCHandle pinned = GCHandle.Alloc(data, GCHandleType.Pinned);
            //    IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(data, 0);
            //    VertexBuffer.glBufferData(GL.GL_ARRAY_BUFFER, sizeof(float) * data.Length, IntPtr.Zero, GL.GL_STATIC_READ);
            //    pinned.Free();
            //}
            VertexBuffer tbo = VertexBuffer.Create(typeof(float), data.Length, VBOConfig.Float, BufferUsage.StaticRead);

            GL.Instance.Enable(GL.GL_RASTERIZER_DISCARD);

            program.Bind();

            TransformFeedbackObject.glBindBufferBase(GL.GL_TRANSFORM_FEEDBACK_BUFFER, 0, tbo.BufferId);

            TransformFeedbackObject.glBeginTransformFeedback(GL.GL_POINTS);


            //GL.Instance.DrawArrays(GL.GL_POINTS, 0, data.Length);
            vao.Render();

            TransformFeedbackObject.glEndTransformFeedback();

            GL.Instance.Disable(GL.GL_RASTERIZER_DISCARD);

            GL.Instance.Flush();

            // Fetch and print results
            var feedback = new float[data.Length]; // all are 0.
            {
                GCHandle pinned = GCHandle.Alloc(feedback, GCHandleType.Pinned);
                IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(feedback, 0);
                var glGetBufferSubData = GL.Instance.GetDelegateFor("glGetBufferSubData", GLDelegates.typeof_void_uint_uint_uint_IntPtr) as GLDelegates.void_uint_uint_uint_IntPtr;
                glGetBufferSubData(GL.GL_TRANSFORM_FEEDBACK_BUFFER, 0, (uint)(sizeof(float) * feedback.Length), header);
                pinned.Free();
            }

            Console.WriteLine(feedback); // values changed.
        }
    }
}
