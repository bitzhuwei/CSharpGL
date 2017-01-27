using System;
using System.IO;

namespace CSharpGL.Demos
{
    /// <summary>
    /// Demo of how to use uniform block and uniform buffer object.
    /// </summary>
    [DemoRenderer]
    internal class BufferBlockRenderer : Renderer
    {
        public static BufferBlockRenderer Create()
        {
            //var model = new Teapot();
            //var model = new ZeroAttributeModel(DrawMode.Triangles, 0, vertexCount);
            var model = new BufferBlockModel();
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\BufferBlockRenderer\BufferBlock.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\BufferBlockRenderer\BufferBlock.frag"), ShaderType.FragmentShader);
            var map = new AttributeMap();// no vertex attribute.
            var renderer = new BufferBlockRenderer(model, shaderCodes, map);
            renderer.ModelSize = new vec3(2, 2, 2);// model.Lengths;

            return renderer;
        }

        private GroundRenderer groundRenderer;

        //private ShaderStorageBuffer shaderStorageBuffer;
        private const int vertexCount = 4;

        private BufferBlockRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, params GLState[] switches)
            : base(model, shaderCodes, attributeMap, switches)
        {
            var groundRenderer = GroundRenderer.Create(new GroundModel(20));
            groundRenderer.Scale = new vec3(10, 10, 10);
            this.groundRenderer = groundRenderer;
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();
            {
                const int length = vertexCount;
                ShaderStorageBuffer buffer = ShaderStorageBuffer.Create(typeof(vec4), length, BufferUsage.StaticDraw);
                IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                unsafe
                {
                    var array = (vec4*)pointer;
                    array[0] = new vec4(0, 0, 1, 1);
                    array[1] = new vec4(1, 0, 0, 1);
                    array[2] = new vec4(-1, 0, 0, 1);
                    array[3] = new vec4(0, 1, 0, 1);
                }
                buffer.UnmapBuffer();
                buffer.Binding(this.Program, "PositionBuffer", 0);
                buffer.Unbind();
                //this.shaderStorageBuffer = buffer;
            }
            {
                const int length = vertexCount;
                ShaderStorageBuffer buffer = ShaderStorageBuffer.Create(typeof(vec4), length, BufferUsage.StaticDraw);
                IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                unsafe
                {
                    var array = (vec4*)pointer;
                    array[0] = new vec4(+1, +0, +0, 0);
                    array[1] = new vec4(+0, +1, +0, 0);
                    array[2] = new vec4(+0, +0, +1, 0);
                    array[3] = new vec4(+1, +1, +1, 0);
                }
                buffer.Binding(this.Program, "ColorBuffer", 1);
                buffer.Unbind();
                //this.shaderStorageBuffer = buffer;
            }

            this.groundRenderer.Initialize();
        }

        private long modelTicks;

        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            this.SetUniform("projectionMatrix", projection);
            this.SetUniform("viewMatrix", view);
            MarkableStruct<mat4> model = this.GetModelMatrix();
            if (this.modelTicks != model.UpdateTicks)
            {
                this.SetUniform("modelMatrix", model.Value);
                this.modelTicks = model.UpdateTicks;
            }

            base.DoRender(arg);

            this.groundRenderer.Render(arg);
        }
    }

    internal class BufferBlockModel : IBufferable
    {
        private IndexBuffer indexBuffer;

        public VertexBuffer GetVertexAttributeBuffer(string bufferName, string varNameInShader)
        {
            return null;
        }

        public IndexBuffer GetIndexBuffer()
        {
            if (this.indexBuffer == null)
            {
                OneIndexBuffer buffer = CSharpGL.GLBuffer.Create(IndexBufferElementType.UInt, 3 * 3, DrawMode.Triangles, BufferUsage.StaticDraw);
                unsafe
                {
                    IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                    var array = (uint*)pointer;
                    array[0] = 0; array[1] = 1; array[2] = 3;
                    array[3] = 0; array[4] = 3; array[5] = 2;
                    array[6] = 1; array[7] = 3; array[8] = 2;
                    buffer.UnmapBuffer();
                }
                this.indexBuffer = buffer;
            }

            return this.indexBuffer;
        }

        public bool UsesZeroIndexBuffer()
        {
            return false;
        }
    }
}