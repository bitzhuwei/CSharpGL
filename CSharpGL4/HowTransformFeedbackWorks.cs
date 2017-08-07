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
        class DataModel : IBufferSource
        {
            public const string inValue = "inValue";
            private VertexBuffer vbo;

            private IndexBuffer indexBuffer;

            private static readonly float[] data = new float[] { 1, 2, 3, 4, 5 };

            #region IBufferSource 成员

            public VertexBuffer GetVertexAttributeBuffer(string bufferName)
            {
                if (bufferName == inValue)
                {
                    if (this.vbo == null)
                    {
                        this.vbo = data.GenVertexBuffer(VBOConfig.Float, BufferUsage.StaticDraw);
                    }

                    return this.vbo;
                }
                else
                {
                    throw new ArgumentException("bufferName");
                }
            }

            public IndexBuffer GetIndexBuffer()
            {
                if (this.indexBuffer == null)
                {
                    this.indexBuffer = ZeroIndexBuffer.Create(DrawMode.Points, 0, data.Length);
                }

                return this.indexBuffer;
            }

            #endregion
        }

        class DemoNode : ModernNode
        {
            private TransformFeedbackObject transformFeedBackObj;

            public static DemoNode Create(TransformFeedbackObject tfo)
            {
                var shader = new VertexShader(vertexShaderSrc, "inValue");
                var feedbackVaryings = new string[] { "outValue" };
                var provider = new ShaderArray(feedbackVaryings, ShaderProgram.BufferMode.InterLeaved, shader);

                var model = new DataModel();
                var map = new AttributeMap(); map.Add("inValue", DataModel.inValue);
                var builder = new RenderUnitBuilder(provider, map);
                var node = new DemoNode(model, builder);
                node.transformFeedBackObj = tfo;
                node.Initialize();

                return node;
            }
            private DemoNode(IBufferSource model, params RenderUnitBuilder[] builders)
                : base(model, builders)
            { }

            public override void RenderBeforeChildren(RenderEventArgs arg)
            {
                GL.Instance.Enable(GL.GL_RASTERIZER_DISCARD);

                RenderUnit unit = this.RenderUnits[0]; //  the only render unit of this node.
                unit.Render(this.transformFeedBackObj);

                GL.Instance.Disable(GL.GL_RASTERIZER_DISCARD);
            }

            public override void RenderAfterChildren(RenderEventArgs arg)
            {
            }

        }
        public static void Run()
        {
            var tfo = new TransformFeedbackObject();

            // Compile shader
            DemoNode node = DemoNode.Create(tfo);

            // Create transform feedback buffer
            const int length = 5;
            VertexBuffer tbo = VertexBuffer.Create(typeof(float), length, VBOConfig.Float, BufferUsage.StaticRead);

            tfo.BindBuffer(0, tbo.BufferId);

            node.RenderBeforeChildren(null);

            GL.Instance.Flush();

            // Fetch and print results
            var feedback = new float[length]; // all are 0.
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
