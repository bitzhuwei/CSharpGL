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

            // Create program and specify transform feedback variables
            var program = new ShaderProgram();
            var feedbackVaryings = new string[] { "outValue" };
            program.Initialize(feedbackVaryings, ShaderProgram.BufferMode.InterLeaved, shader);

            var data = new float[] { 1, 2, 3, 4, 5 };
            VertexBuffer vbo = data.GenVertexBuffer(VBOConfig.Float, BufferUsage.StaticDraw);

            var indexBuffer = ZeroIndexBuffer.Create(DrawMode.Points, 0, data.Length);
            var vao = new VertexArrayObject(indexBuffer, new VertexShaderAttribute(vbo, "inValue"));
            vao.Initialize(program);

            // Create transform feedback buffer
            VertexBuffer tbo = VertexBuffer.Create(typeof(float), data.Length, VBOConfig.Float, BufferUsage.StaticRead);

            var tfo = new TransformFeedbackObject();
            tfo.BindBuffer(0, tbo.BufferId);

            GL.Instance.Enable(GL.GL_RASTERIZER_DISCARD);

            program.Bind();

            tfo.Bind();

            tfo.Begin(DrawMode.Points);
            vao.Render();
            tfo.End();

            tfo.Unbind();

            program.Unbind();

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
